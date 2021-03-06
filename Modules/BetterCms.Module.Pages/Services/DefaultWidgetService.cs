﻿using System;
using System.Collections.Generic;
using System.Linq;

using BetterCms.Core.DataAccess;
using BetterCms.Core.DataAccess.DataContext;
using BetterCms.Core.DataAccess.DataContext.Fetching;
using BetterCms.Core.DataContracts.Enums;
using BetterCms.Core.Exceptions;
using BetterCms.Core.Exceptions.Mvc;
using BetterCms.Core.Services;

using BetterCms.Module.Pages.Content.Resources;
using BetterCms.Module.Pages.Models;
using BetterCms.Module.Pages.ViewModels.Widgets;

using BetterCms.Module.Root.Models;
using BetterCms.Module.Root.Mvc;
using BetterCms.Module.Root.Services;

using FluentNHibernate.Conventions.AcceptanceCriteria;

using CategoryEntity = BetterCms.Module.Root.Models.Category;

namespace BetterCms.Module.Pages.Services
{
    public class DefaultWidgetService : IWidgetService
    {
        private readonly IRepository repository;
        
        private readonly IUnitOfWork unitOfWork;
        
        private readonly IOptionService optionService;
        
        private readonly IContentService contentService;
        
        private readonly ISecurityService securityService;

        public DefaultWidgetService(IRepository repository, IUnitOfWork unitOfWork, IOptionService optionService, IContentService contentService,
            ISecurityService securityService)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.optionService = optionService;
            this.contentService = contentService;
            this.securityService = securityService;
        }

        public void SaveHtmlContentWidget(EditHtmlContentWidgetViewModel model, out HtmlContentWidget widget, out HtmlContentWidget originalWidget,
            bool treatNullsAsLists = true, bool createIfNotExists = false)
        {
            if (model.Options != null)
            {
                optionService.ValidateOptionKeysUniqueness(model.Options);
            }

            unitOfWork.BeginTransaction();

            bool isCreatingNew;

            var widgetContent = GetHtmlContentWidgetFromRequest(model, treatNullsAsLists, !model.Id.HasDefaultValue());
            widget = GetWidgetForSave(widgetContent, model, createIfNotExists, out isCreatingNew);

            repository.Save(widget);
            unitOfWork.Commit();

            // Notify.
            if (widget.Status != ContentStatus.Preview)
            {
                if (isCreatingNew)
                {
                    Events.PageEvents.Instance.OnWidgetCreated(widget);
                }
                else
                {
                    Events.PageEvents.Instance.OnWidgetUpdated(widget);
                }
            }

            originalWidget = widget;
            if (model.DesirableStatus == ContentStatus.Draft && widget.History != null)
            {
                var draft = widget.History.FirstOrDefault(h => h is HtmlContentWidget && !h.IsDeleted && h.Status == ContentStatus.Draft) as HtmlContentWidget;
                if (draft != null)
                {
                    originalWidget = draft;
                }
            }
        }

        public ServerControlWidget SaveServerControlWidget(EditServerControlWidgetViewModel model, bool treatNullsAsLists = true, bool createIfNotExists = false)
        {
            if (model.DesirableStatus == ContentStatus.Draft)
            {
                throw new CmsException(string.Format("Server widget does not support Draft state."));
            }

            if (model.Options != null)
            {
                optionService.ValidateOptionKeysUniqueness(model.Options);
            }

            unitOfWork.BeginTransaction();

            bool isCreatingNew;

            var requestWidget = GetServerControlWidgetFromRequest(model, treatNullsAsLists, !model.Id.HasDefaultValue());
            var widget = GetWidgetForSave(requestWidget, model, createIfNotExists, out isCreatingNew);
            
            repository.Save(widget);
            unitOfWork.Commit();

            // Notify.
            if (widget.Status != ContentStatus.Preview)
            {
                if (isCreatingNew)
                {
                    Events.PageEvents.Instance.OnWidgetCreated(widget);
                }
                else
                {
                    Events.PageEvents.Instance.OnWidgetUpdated(widget);
                }
            }

            return widget;
        }

        private TEntity GetWidgetForSave<TEntity>(TEntity widgetContent, EditWidgetViewModel model, bool createIfNotExists, out bool isCreatingNew)
            where TEntity : Widget
        {
            TEntity widget, originalWidget = null;
            var createNewWithId = false;

            isCreatingNew = model.Id.HasDefaultValue();
            if (createIfNotExists || !isCreatingNew)
            {
                originalWidget = repository.FirstOrDefault<TEntity>(model.Id);
                isCreatingNew = originalWidget == null;
                createNewWithId = isCreatingNew && !model.Id.HasDefaultValue();
            }

            if (model.DesirableStatus == ContentStatus.Published)
            {
                if (isCreatingNew)
                {
                    if (model.PublishedOn.HasValue)
                    {
                        widgetContent.PublishedOn = model.PublishedOn;
                    }
                    if (!string.IsNullOrEmpty(model.PublishedByUser))
                    {
                        widgetContent.PublishedByUser = model.PublishedByUser;
                    }
                }
                else
                {
                    widgetContent.PublishedOn = originalWidget.PublishedOn;
                    widgetContent.PublishedByUser = originalWidget.PublishedByUser;
                }
            }

            if (createNewWithId)
            {
                widget = widgetContent;

                widget.Status = model.DesirableStatus;
                widget.Id = model.Id;
            }
            else
            {
                widget = (TEntity)contentService.SaveContentWithStatusUpdate(widgetContent, model.DesirableStatus);
            }

            return widget;
        }

        private HtmlContentWidget GetHtmlContentWidgetFromRequest(EditHtmlContentWidgetViewModel request, bool treatNullsAsLists, bool isNew)
        {
            HtmlContentWidget content = new HtmlContentWidget();
            content.Id = request.Id;

            if (request.CategoryId.HasValue && !request.CategoryId.Value.HasDefaultValue())
            {
                content.Category = repository.AsProxy<CategoryEntity>(request.CategoryId.Value);
            }
            else
            {
                content.Category = null;
            }

            SetWidgetOptions(request, content, treatNullsAsLists, isNew);

            content.Name = request.Name;
            content.Html = request.PageContent ?? string.Empty;
            content.UseHtml = request.EnableCustomHtml;
            content.UseCustomCss = request.EnableCustomCSS;
            content.CustomCss = request.CustomCSS;
            content.UseCustomJs = request.EnableCustomJS;
            content.CustomJs = request.CustomJS;
            content.Version = request.Version;
            content.EditInSourceMode = request.EditInSourceMode;

            return content;
        }

        private ServerControlWidget GetServerControlWidgetFromRequest(EditServerControlWidgetViewModel request, bool treatNullsAsLists, bool isNew)
        {
            ServerControlWidget widget = new ServerControlWidget();
            widget.Id = request.Id;

            if (request.CategoryId.HasValue && !request.CategoryId.Value.HasDefaultValue())
            {
                widget.Category = repository.AsProxy<CategoryEntity>(request.CategoryId.Value);
            }
            else
            {
                widget.Category = null;
            }

            widget.Name = request.Name;
            widget.Url = request.Url;
            widget.Version = request.Version;
            widget.PreviewUrl = request.PreviewImageUrl;

            SetWidgetOptions(request, widget, treatNullsAsLists, isNew);

            return widget;
        }

        private void SetWidgetOptions(EditWidgetViewModel model, Widget content, bool treatNullsAsLists, bool isNew)
        {
            if (model.Options != null)
            {
                content.ContentOptions = new List<ContentOption>();

                // NOTE: Loading custom options before saving.
                // In other case, when loading custom options from option service, nHibernate updates version number (nHibernate bug)
                var customOptionsIdentifiers = model.Options.Where(o => o.Type == OptionType.Custom).Select(o => o.CustomOption.Identifier).Distinct().ToArray();
                var customOptions = optionService.GetCustomOptionsById(customOptionsIdentifiers);

                foreach (var requestContentOption in model.Options)
                {
                    var contentOption = new ContentOption
                                        {
                                            Content = content,
                                            Key = requestContentOption.OptionKey,
                                            DefaultValue =
                                                optionService.ClearFixValueForSave(
                                                    requestContentOption.OptionKey,
                                                    requestContentOption.Type,
                                                    requestContentOption.OptionDefaultValue),
                                            Type = requestContentOption.Type,
                                            CustomOption =
                                                requestContentOption.Type == OptionType.Custom
                                                    ? customOptions.First(o => o.Identifier == requestContentOption.CustomOption.Identifier)
                                                    : null
                                        };

                    optionService.ValidateOptionValue(contentOption);

                    content.ContentOptions.Add(contentOption);
                }
            }
            else if (!treatNullsAsLists)
            {
                // When calling from API with null list, options should be loaded before process
                // Null from API means, that list should be kept unchanged
                content.ContentOptions = repository
                    .AsQueryable<ContentOption>(pco => pco.Content.Id == model.Id)
                    .Fetch(pco => pco.CustomOption)
                    .ToList();
            }
        }

        public bool DeleteWidget(Guid widgetId, int widgetVersion)
        {
            unitOfWork.BeginTransaction();

            var widget = repository.First<Widget>(widgetId);
            if (widgetVersion > 0)
            {
                widget.Version = widgetVersion;
            }

            var isWidgetInUse = repository
                .AsQueryable<PageContent>()
                .Any(f => f.Content.Id == widgetId && !f.IsDeleted && !f.Page.IsDeleted);

            if (isWidgetInUse)
            {
                var message = string.Format(PagesGlobalization.Widgets_CanNotDeleteWidgetIsInUse_Message, widget.Name);
                var logMessage = string.Format("A widget {0}(id={1}) can't be deleted because it is in use.", widget.Name, widgetId);
                throw new ValidationException(() => message, logMessage);
            }

            repository.Delete(widget);

            if (widget.ContentOptions != null)
            {
                foreach (var option in widget.ContentOptions)
                {
                    repository.Delete(option);
                }
            }

            unitOfWork.Commit();

            // Notify.
            Events.PageEvents.Instance.OnWidgetDeleted(widget);

            return true;
        }
    }
}