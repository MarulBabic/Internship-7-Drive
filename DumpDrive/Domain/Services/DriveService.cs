using Domain.Repositories;
using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using File = Data.Entities.Models.File;

namespace Domain.Services
{
    public class DriveService
    {
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;

        public DriveService(FolderRepository folderRepository, FileRepository fileRepository)
        {
            _folderRepository = folderRepository ?? throw new ArgumentNullException(nameof(folderRepository));
            _fileRepository = fileRepository ?? throw new ArgumentNullException(nameof(fileRepository));
        }

        public (IEnumerable<Folder> Folders, IEnumerable<File> Files) GetUserDrive(int userId)
        {
            var folders = _folderRepository.GetFoldersByUser(userId).OrderBy(f => f.Name);
            var files = _fileRepository.GetFilesByUser(userId).OrderByDescending(f => f.UpdatedAt);
            return (folders, files);
        }

        public void CreateFolder(string folderName, int userId, int? parentFolderId = null)
        {
            var folder = new Folder
            {
                Name = folderName,
                OwnerId = userId,
                ParentFolderId = parentFolderId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _folderRepository.Add(folder);
        }


        public Folder? GetFolderById(int folderId)
        {
            return _folderRepository.GetFolderById(folderId);
        }

        public bool CreateFile(string fileName, int userId, string content, int folderId)
        {
            var folder = _folderRepository.GetFolderById(folderId, userId);
            if (folder == null)
            {
                return false; // Folder ne postoji ili korisnik nema pristup
            }

            var fileExists = _fileRepository.GetFileByNameInFolder(fileName, folderId) != null;
            if (fileExists)
            {
                return false; // Fajl sa istim imenom već postoji
            }

            var newFile = new File
            {
                Name = fileName,
                Content = content,
                FolderId = folderId,
                OwnerId = userId,
                CreatedAt = DateTime.UtcNow,
            };

            _fileRepository.Add(newFile);
            return true;
        }


        public Folder? GetFolder(string folderName, int userId)
        {
            var folders = _folderRepository.GetFoldersByUser(userId);
            return folders.FirstOrDefault(f => f.Name.Equals(folderName, StringComparison.OrdinalIgnoreCase));
        }

        public File? GetFile(string fileName, int userId)
        {
            var files = _fileRepository.GetFilesByUser(userId);
            return files.FirstOrDefault(f => f.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase));
        }

        public bool RenameFolder(string oldName, string newName, int userId)
        {
            var folder = _folderRepository.GetFoldersByUser(userId)
                .FirstOrDefault(f => f.Name.Equals(oldName, StringComparison.OrdinalIgnoreCase));

            if (folder != null)
            {
                folder.Name = newName;
                folder.UpdatedAt = DateTime.UtcNow;
                _folderRepository.Update(folder);
                return true;
            }

            return false;
        }

        public bool RenameFile(string oldName, string newName, int userId)
        {
            var file = _fileRepository.GetFilesByUser(userId)
                .FirstOrDefault(f => f.Name.Equals(oldName, StringComparison.OrdinalIgnoreCase));

            if (file != null)
            {
                file.Name = newName;
                file.UpdatedAt = DateTime.UtcNow;
                _fileRepository.Update(file);
                return true;
            }

            return false;
        }

        public bool DeleteFolder(string folderName, int userId)
        {
            var folder = _folderRepository.GetFoldersByUser(userId)
                .FirstOrDefault(f => f.Name.Equals(folderName, StringComparison.OrdinalIgnoreCase));

            if (folder != null)
            {
                _folderRepository.Delete(folder);
                return true;
            }

            return false;
        }

        public bool UpdateFileContent(string fileName, int userId, string newContent)
        {
            var file = _fileRepository.GetFilesByUser(userId)
                .FirstOrDefault(f => f.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase));

            if (file != null)
            {
                file.Content = newContent;
                file.UpdatedAt = DateTime.UtcNow;
                _fileRepository.Update(file);
                return true;
            }

            return false;
        }

        public bool DeleteFile(string fileName, int userId)
        {
            var file = _fileRepository.GetFilesByUser(userId)
                .FirstOrDefault(f => f.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase));

            if (file != null)
            {
                _fileRepository.Delete(file);
                return true;
            }

            return false;
        }
    }
}
