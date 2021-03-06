﻿using System.Linq;

using BetterCms.Core.DataContracts.Enums;

using BetterCms.Module.Pages.Models;
using BetterCms.Module.Pages.Services;
using BetterCms.Module.Pages.ViewModels.Widgets;

namespace BetterCms.Module.Pages.Command.Widget.SaveWidget
{
    public class SaveHtmlContentWidgetCommand : SaveWidgetCommandBase<EditHtmlContentWidgetViewModel>
    {
        public virtual IWidgetService WidgetService { get; set; }

        /// <summary>
        /// Executes the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public override SaveWidgetResponse Execute(EditHtmlContentWidgetViewModel request)
        {
            HtmlContentWidget widget;
            HtmlContentWidget originalWiget;
            WidgetService.SaveHtmlContentWidget(request, out widget, out originalWiget);

            return new SaveWidgetResponse
                    {
                        Id = widget.Id,
                        OriginalId = originalWiget.Id,
                        WidgetName = widget.Name,
                        CategoryName = widget.Category != null ? widget.Category.Name : null,
                        Version = widget.Version,
                        OriginalVersion = originalWiget.Version,
                        WidgetType = WidgetType.HtmlContent.ToString(),
                        IsPublished = originalWiget.Status == ContentStatus.Published,
                        HasDraft = originalWiget.Status == ContentStatus.Draft || originalWiget.History != null && originalWiget.History.Any(f => f.Status == ContentStatus.Draft),
                        DesirableStatus = request.DesirableStatus,
                        PreviewOnPageContentId = request.PreviewOnPageContentId
                    };
        }
    }
}