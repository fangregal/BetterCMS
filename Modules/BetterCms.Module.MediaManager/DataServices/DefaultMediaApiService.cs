﻿using System;
using System.Collections.Generic;
using System.Linq;

using BetterCms.Core.DataAccess;
using BetterCms.Core.DataAccess.DataContext;
using BetterCms.Module.MediaManager.Models;

using NHibernate.Linq;

namespace BetterCms.Module.MediaManager.DataServices
{
    public class DefaultMediaApiService : IMediaApiService
    {
        private readonly IRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultMediaApiService" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public DefaultMediaApiService(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets the list of folder media entities.
        /// </summary>
        /// <param name="mediaType">Type of the media.</param>
        /// <param name="folderId">The folder id.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="order">The order.</param>
        /// <param name="orderDescending">if set to <c>true</c> order by descending.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="itemsPerPage">The items per page.</param>
        /// <returns>
        /// The list of folder media entities
        /// </returns>
        public IList<Media> GetFolderMedias(MediaType mediaType, Guid? folderId = null, System.Linq.Expressions.Expression<Func<Media, bool>> filter = null, System.Linq.Expressions.Expression<Func<Media, dynamic>> order = null, bool orderDescending = false, int? pageNumber = null, int? itemsPerPage = null)
        {
            if (order == null)
            {
                order = p => p.Title;
            }

            var query = repository
                .AsQueryable<Media>()
                .Where(f => f.Type == mediaType);

            if (folderId.HasValue)
            {
                query = query.Where(f => f.Folder != null && f.Folder.Id == folderId.Value);
            }
            else
            {
                query = query.Where(f => f.Folder == null);
            }

            query = query.ApplyFilters(filter, order, orderDescending, pageNumber, itemsPerPage);

            return query.ToList();
        }

        /// <summary>
        /// Gets the list of media image entities.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="order">The order.</param>
        /// <param name="orderDescending">if set to <c>true</c> order by descending.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="itemsPerPage">The items per page.</param>
        /// <returns>
        /// The list of tag entities
        /// </returns>
        public IList<MediaImage> GetImages(System.Linq.Expressions.Expression<Func<MediaImage, bool>> filter = null, System.Linq.Expressions.Expression<Func<MediaImage, dynamic>> order = null, bool orderDescending = false, int? pageNumber = null, int? itemsPerPage = null)
        {
            if (order == null)
            {
                order = p => p.Title;
            }

            return repository
                .AsQueryable<MediaImage>()
                .Fetch(m => m.Folder)
                .ApplyFilters(filter, order, orderDescending, pageNumber, itemsPerPage).ToList();
        }

        /// <summary>
        /// Gets the list of media file entities.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="order">The order.</param>
        /// <param name="orderDescending">if set to <c>true</c> order by descending.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="itemsPerPage">The items per page.</param>
        /// <returns>
        /// The list of media file entities
        /// </returns>
        public IList<MediaFile> GetFiles(System.Linq.Expressions.Expression<Func<MediaFile, bool>> filter = null, System.Linq.Expressions.Expression<Func<MediaFile, dynamic>> order = null, bool orderDescending = false, int? pageNumber = null, int? itemsPerPage = null)
        {
            if (order == null)
            {
                order = p => p.Title;
            }

            return repository
                .AsQueryable<MediaFile>()
                .Fetch(m => m.Folder)
                .Where(m => m.Type == MediaType.File)
                .ApplyFilters(filter, order, orderDescending, pageNumber, itemsPerPage).ToList();
        }

        /// <summary>
        /// Gets the list of media folder entities.
        /// </summary>
        /// <param name="mediaType">Type of the media.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="order">The order.</param>
        /// <param name="orderDescending">if set to <c>true</c> order by descending.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="itemsPerPage">The items per page.</param>
        /// <returns>
        /// The list of folder entities
        /// </returns>
        public IList<MediaFolder> GetFolders(MediaType mediaType, System.Linq.Expressions.Expression<Func<MediaFolder, bool>> filter = null, System.Linq.Expressions.Expression<Func<MediaFolder, dynamic>> order = null, bool orderDescending = false, int? pageNumber = null, int? itemsPerPage = null)
        {
            if (order == null)
            {
                order = p => p.Title;
            }

            return repository
                .AsQueryable<MediaFolder>()
                .Fetch(m => m.Folder)
                .Where(f => f.Type == mediaType)
                .ApplyFilters(filter, order, orderDescending, pageNumber, itemsPerPage)
                .ToList();
        }

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>
        /// File entity
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public MediaFile GetFile(Guid id)
        {
            return repository
                .AsQueryable<MediaFile>()
                .Fetch(f => f.Folder)
                .FirstOrDefault(f => f.Id == id);
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>
        /// Image entity
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public MediaImage GetImage(Guid id)
        {
            return repository
                .AsQueryable<MediaImage>()
                .Fetch(f => f.Folder)
                .FirstOrDefault(f => f.Id == id);
        }
    }
}