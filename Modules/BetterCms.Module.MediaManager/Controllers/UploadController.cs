﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

using BetterCms.Core.Security;
using BetterCms.Module.MediaManager.Command.Upload;
using BetterCms.Module.MediaManager.Command.Upload.CheckFileStatuses;
using BetterCms.Module.MediaManager.Command.Upload.ConfirmUpload;
using BetterCms.Module.MediaManager.Command.Upload.GetMultiFileUpload;
using BetterCms.Module.MediaManager.Command.Upload.UndoUpload;
using BetterCms.Module.MediaManager.Command.Upload.Upload;
using BetterCms.Module.MediaManager.Content.Resources;
using BetterCms.Module.MediaManager.Helpers;
using BetterCms.Module.MediaManager.Models;
using BetterCms.Module.MediaManager.ViewModels.Upload;
using BetterCms.Module.Root;
using BetterCms.Module.Root.Models;
using BetterCms.Module.Root.Mvc;

namespace BetterCms.Module.MediaManager.Controllers
{
    /// <summary>
    /// Media upload manager.
    /// </summary>
    [BcmsAuthorize]
    public class UploadController : CmsControllerBase
    {
        /// <summary>
        /// Multi the file upload.
        /// </summary>
        /// <param name="folderId">The folder id.</param>
        /// <param name="folderType">Type of the folder.</param>
        /// <returns>File upload html.</returns>
        [BcmsAuthorize(RootModuleConstants.UserRoles.EditContent)]
        [HttpGet]
        public ActionResult MultiFileUpload(string folderId, string folderType)
        {
            var model = GetCommand<GetMultiFileUploadCommand>().ExecuteCommand(
                new GetMultiFileUploadRequest
                    {
                        FolderId = folderId.ToGuidOrDefault(),
                        Type = (MediaType)Enum.Parse(typeof(MediaType), folderType)
                    });

            return View(model);
        }

        /// <summary>
        /// Singles the file upload.
        /// </summary>
        /// <param name="folderId">The folder id.</param>
        /// <param name="folderType">Type of the folder.</param>
        /// <returns>File upload html.</returns>
        [BcmsAuthorize(RootModuleConstants.UserRoles.EditContent)]
        [HttpGet]
        public ActionResult SingleFileUpload(string folderId, string folderType)
        {
            var model = GetCommand<GetMultiFileUploadCommand>().ExecuteCommand(
                new GetMultiFileUploadRequest
                {
                    FolderId = folderId.ToGuidOrDefault(), 
                    Type = (MediaType)Enum.Parse(typeof(MediaType), folderType)
                });

            return View("SingleFileUpload", model);
        }

        /// <summary>
        /// Uploads the single file.
        /// </summary>
        /// <param name="uploadFile">The upload file.</param>
        /// <param name="SelectedFolderId">The selected folder id.</param>
        /// <param name="RootFolderType">Type of the root folder.</param>
        /// <returns>Json result.</returns>
        [BcmsAuthorize(RootModuleConstants.UserRoles.EditContent)]
        [HttpPost]
        public WrappedJsonResult UploadSingleFile(HttpPostedFileWrapper uploadFile, string SelectedFolderId, string RootFolderType)
        {
            var rootFolderType = (MediaType)Enum.Parse(typeof(MediaType), RootFolderType);
            if (uploadFile != null && FileFormatIsValid(rootFolderType, uploadFile.ContentType))
            {
                UploadFileRequest request = new UploadFileRequest
                    {
                        RootFolderId = SelectedFolderId.ToGuidOrDefault(),
                        Type = rootFolderType,
                        FileLength = uploadFile.ContentLength,
                        FileName = uploadFile.FileName,
                        FileStream = uploadFile.InputStream
                    };

                var media = GetCommand<UploadCommand>().ExecuteCommand(request);
                if (media != null)
                {
                    return new WrappedJsonResult
                    {
                        Data = new
                        {
                            Success = true,
                            Id = media.Id,
                            fileName = media.OriginalFileName,
                            fileSize = media.Size,
                            Version = media.Version,
                            Type = request.Type
                        }
                    };
                }
            }

            List<string> messages = new List<string>();
            messages.AddRange(Messages.Error);

            return new WrappedJsonResult
            {
                Data = new
                {
                    Success = false,
                    Messages = messages.ToArray()
                }
            };
        }

        /// <summary>
        /// Uploads the media.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>Json result.</returns>
        [BcmsAuthorize(RootModuleConstants.UserRoles.EditContent)]
        [HttpPost]
        public ActionResult UploadMedia(HttpPostedFileBase file)
        {
            var rootFolderId = Request.Form["rootFolderId"].ToGuidOrDefault();
            var rootFolderType = (MediaType)Enum.Parse(typeof(MediaType), Request.Form["rootFolderType"]);

            if (file != null && FileFormatIsValid(rootFolderType, file.ContentType))
            {
                UploadFileRequest request = new UploadFileRequest
                    {
                        RootFolderId = rootFolderId,
                        Type = rootFolderType,
                        FileLength = file.ContentLength,
                        FileName = file.FileName,
                        FileStream = file.InputStream
                    };

                var media = GetCommand<UploadCommand>().ExecuteCommand(request);

                if (media != null)
                {
                    return WireJson(true, new
                                              {
                                                  FileId = media.Id, 
                                                  Version = media.Version, 
                                                  Type = (int)rootFolderType, 
                                                  IsProcessing = !media.IsUploaded.HasValue,
                                                  IsFailed = media.IsUploaded == false,
                                              });
                }
            }

            return Json(new WireJson(false));
        }

        /// <summary>
        /// Removes the file upload.
        /// </summary>
        /// <param name="fileId">The file id.</param>
        /// <param name="version">The version.</param>
        /// <param name="type">The type.</param>
        /// <returns>Json result.</returns>
        [BcmsAuthorize(RootModuleConstants.UserRoles.EditContent)]
        [HttpPost]
        public ActionResult RemoveFileUpload(string fileId, string version, string type)
        {
            var result = GetCommand<UndoUploadCommand>().ExecuteCommand(new UndoUploadRequest
                                                                            {
                                                                                FileId = fileId.ToGuidOrDefault(),
                                                                                Version = version.ToIntOrDefault(),
                                                                                Type = (MediaType)type.ToIntOrDefault()
                                                                            });

            return Json(new { Success = result });
        }

        /// <summary>
        /// Saves the uploads.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Json result.</returns>
        [BcmsAuthorize(RootModuleConstants.UserRoles.EditContent)]
        [HttpPost]
        public ActionResult SaveUploads(MultiFileUploadViewModel model)
        {
            var result = GetCommand<ConfirmUploadCommand>().ExecuteCommand(model);

            if (result == null)
            {
                Messages.AddError(MediaGlobalization.MultiFileUpload_SaveFailed);
            }
            else if (result.FolderIsDeleted)
            {
                Messages.AddError(MediaGlobalization.MultiFileUpload_SaveFailed_FolderDeleted);
            }

            return Json(new WireJson(result != null && !result.FolderIsDeleted, result));
        }

        /// <summary>
        /// Files the format is valid.
        /// </summary>
        /// <param name="folderType">Type of the folder.</param>
        /// <param name="fileType">Type of the file.</param>
        /// <returns><c>true</c> if media format is supported, otherwise <c>false</c>.</returns>
        private bool FileFormatIsValid(MediaType folderType, string fileType)
        {
            if (folderType == MediaType.Image)
            {
                switch (fileType)
                {
                    case "image/png":
                    case "image/jpg":
                    case "image/jpeg":
                    case "image/gif":
                        break;
                    default:
                        Messages.AddError(MediaGlobalization.FileUpload_Failed_ImageFormatNotSuported);
                        return false;
                }
            }

            return true;
        }

        [HttpPost]
        public ActionResult CheckFilesStatuses(List<string> ids)
        {
            var result = GetCommand<CheckFilesStatusesCommand>().ExecuteCommand(ids);

            return WireJson(result != null, result);
        }
    }
}
