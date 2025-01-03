using Data.Entities.Models;
using Domain.Repositories;
using System;

namespace Domain.Services
{
    public class SharingItemService
    {
        private readonly SharedItemRepository _sharedItemRepository;
        private readonly UserRepository _userRepository;
        private readonly FileRepository _fileRepository;
        private readonly FolderRepository _folderRepository;

        public SharingItemService(SharedItemRepository sharedItemRepository,
                           UserRepository userRepository,
                           FileRepository fileRepository,
                           FolderRepository folderRepository)
        {
            _sharedItemRepository = sharedItemRepository ?? throw new ArgumentNullException(nameof(sharedItemRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _fileRepository = fileRepository ?? throw new ArgumentNullException(nameof(fileRepository));
            _folderRepository = folderRepository ?? throw new ArgumentNullException(nameof(folderRepository));
        }

        public bool ShareItem(int itemId, string itemType, string email, int ownerUserId)
        {
            var user = _userRepository.GetByEmail(email);
            if (user == null)
            {
                return false;
            }

            if (itemType == "file")
            {
                var file = _fileRepository.GetFileById(itemId, ownerUserId);
                if (file != null)
                {
                    var sharedItem = new SharedItem
                    {
                        OwnerUserId = ownerUserId,
                        SharedUserId = user.Id,
                        SharedAt = DateTime.UtcNow,
                        SharedItemType = Data.Enums.ItemType.File,
                        FileId = file.Id
                    };
                    _sharedItemRepository.Add(sharedItem);
                    return true;
                }
            }
            else if (itemType == "folder")
            {
                var folder = _folderRepository.GetFolderById(itemId, ownerUserId);
                if (folder != null)
                {
                    var sharedItem = new SharedItem
                    {
                        OwnerUserId = ownerUserId,
                        SharedUserId = user.Id,
                        SharedAt = DateTime.UtcNow,
                        SharedItemType = Data.Enums.ItemType.Folder,
                        FolderId = folder.Id
                    };
                    _sharedItemRepository.Add(sharedItem);
                    return true;
                }
            }
            return false;
        }

        public List<SharedItem> GetItemsSharedWithUser(int userId)
        {
            return _sharedItemRepository.GetSharedItemsByUserId(userId);
        }

        public string GetItemName(SharedItem sharedItem)
        {
            if (sharedItem.SharedItemType == Data.Enums.ItemType.File)
            {
                if (sharedItem.FileId.HasValue)
                {
                    var file = _fileRepository.GetFileById(sharedItem.FileId.Value, sharedItem.OwnerUserId);
                    return file?.Name ?? "(Unknown File)";
                }
                else
                {
                    return "(Invalid File)";
                }
            }
            else if (sharedItem.SharedItemType == Data.Enums.ItemType.Folder)
            {
                if (sharedItem.FolderId.HasValue)
                {
                    var folder = _folderRepository.GetFolderById(sharedItem.FolderId.Value, sharedItem.OwnerUserId);
                    return folder?.Name ?? "(Unknown Folder)";
                }
                else
                {
                    return "(Invalid Folder)";
                }
            }

            return "(Unknown Item)";
        }

        public bool StopSharingItem(int itemId, string itemType, string email, int ownerUserId)
        {
            var user = _userRepository.GetByEmail(email);
            if (user == null)
            {
                return false;
            }

            if (!IsOwnerOfItem(itemId, itemType, ownerUserId))
            {
                return false;
            }

            if (itemType == "file")
            {
                var sharedItem = _sharedItemRepository.GetSharedItemByFileId(itemId, ownerUserId, user.Id);
                if (sharedItem == null)
                {
                    return false;
                }

                _sharedItemRepository.Delete(sharedItem.Id, ownerUserId);
                return true;
            }

            if (itemType == "folder")
            {
                var sharedItem = _sharedItemRepository.GetSharedItemByFolderId(itemId, ownerUserId, user.Id);
                if (sharedItem == null)
                {
                    return false;
                }

                _sharedItemRepository.Delete(sharedItem.Id, ownerUserId);
                return true;
            }

            return false;
        }

        public bool IsOwnerOfItem(int itemId, string itemType, int userId)
        {
            if (itemType == "file")
            {
                var file = _fileRepository.GetFileById(itemId, userId);
                return file != null && file.OwnerId == userId;
            }

            if (itemType == "folder")
            {
                var folder = _folderRepository.GetFolderById(itemId, userId);
                return folder != null && folder.OwnerId == userId;
            }

            return false;
        }



        public bool UpdateSharedFileContent(int fileId, string newContent, int userId)
        {
            var sharedItem = _sharedItemRepository.GetSharedItemByFileId(fileId, userId, userId);
            if (sharedItem == null)
            {
                return false;
            }

            try
            {
                _fileRepository.UpdateFileContent(fileId, newContent);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void RemoveFromShared(int fileId, int userId)
        {
            var sharedItems = _sharedItemRepository.GetSharedItemsByUserId(userId);
            var sharedItem = sharedItems.FirstOrDefault(si => si.FileId == fileId);

            if (sharedItem != null)
            {
                _sharedItemRepository.Delete(sharedItem.Id, sharedItem.OwnerUserId);
            }
        }

        public string GetUserEmailById(int userId)
        {
            var user = _userRepository.GetById(userId);
            return user?.Email ?? "(Unknown User)";
        }

        public int? GetFileIdByName(string fileName)
        {
            var file = _fileRepository.GetFileByName(fileName);
            return file?.Id;
        }

        public int? GetFolderIdByName(string folderName, int userId)
        {
            var folder = _folderRepository.GetFolderByName(folderName, userId);
            return folder?.Id;
        }
    }
}
