﻿using System.Collections.Generic;
using System.Security.Principal;

using BetterCms.Module.Blog.Models;
using BetterCms.Module.Blog.ViewModels.Blog;
using BetterCms.Module.Blog.ViewModels.Filter;
using BetterCms.Module.Root.Models;

using NHibernate;

namespace BetterCms.Module.Blog.Services
{
    public interface IBlogService
    {
        /// <summary>
        /// Creates the blog URL from the given blog title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="unsavedUrls">The list of not saved yet urls.</param>
        /// <returns>
        /// Created blog URL
        /// </returns>
        string CreateBlogPermalink(string title, List<string> unsavedUrls = null);

        /// <summary>
        /// Saves the blog post.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="principal">The principal.</param>
        /// <returns>
        /// Saved blog post entity
        /// </returns>
        BlogPost SaveBlogPost(BlogPostViewModel model, IPrincipal principal);

        /// <summary>
        /// Gets the filtered blog posts query.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="joinContents">if set to <c>true</c> join contents tables.</param>
        /// <returns>
        /// NHibernate query for getting filtered blog posts
        /// </returns>
        IQueryOver<BlogPost, BlogPost> GetFilteredBlogPostsQuery(BlogsFilter filter, bool joinContents = false);

        /// <summary>
        /// Loads the default layout and region.
        /// </summary>
        /// <param name="layout">The layout.</param>
        /// <param name="masterPage">The master page.</param>
        /// <param name="region">The region.</param>
        void LoadDefaultLayoutAndRegion(out Layout layout, out Page masterPage, out Region region);

        /// <summary>
        /// Adds the default access rules.
        /// </summary>
        /// <param name="blogPost">The blog post.</param>
        /// <param name="principal">The principal.</param>
        /// <param name="masterPage">The master page.</param>
        void AddDefaultAccessRules(BlogPost blogPost, IPrincipal principal, Page masterPage);
    }
}