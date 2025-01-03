using System;
using Data.Entities.Models;
using Domain.Repositories;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Presentation
{
    internal class SharedItemCommands
    {
        private readonly SharingItemService _sharingItemService;
        private readonly int _userId;
        private CommentService _commentService;
        private CommentPresentation _commentPresentation;
        private UserRepository _userRepository;

        public SharedItemCommands(SharingItemService sharingItemService, int userId)
        {
            _sharingItemService = sharingItemService ?? throw new ArgumentNullException(nameof(sharingItemService));
            _userId = userId;
        }

        public void SetCommentService(CommentService commentService)
        {
            var options = new DbContextOptionsBuilder<DumpDriveDbContext>()
                  .UseNpgsql("Host=127.0.0.1;Port=5433;Database=DumpDrive;Username=postgres;Password=postgres;")
                  .Options;

            var dbContext = new DumpDriveDbContext(options);
            var userRepository = new UserRepository(dbContext);

            _commentService = commentService;
            _commentPresentation = new CommentPresentation(_commentService, userRepository);
            Console.WriteLine("SetCommentService called.");
        }

        public void ExecuteCommand(string command)
        {
            var commandParts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (commandParts.Length == 0)
                return;

            var mainCommand = commandParts[0].ToLower();

            switch (mainCommand)
            {
                case ":share":
                    HandleShareCommand(commandParts);
                    break;

                case ":stop":
                    HandleStopSharingCommand(commandParts);
                    break;

                case ":edit":
                    HandleEditFileCommand(commandParts);
                    break;

                case ":remove":
                    HandleRemoveFromSharedCommand(commandParts);
                    break;
                case ":comments":
                    HandleCommentCommand(commandParts);
                    break;

                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }

        private void HandleShareCommand(string[] commandParts)
        {
            if (commandParts.Length == 4)
            {
                var itemName = commandParts[1];
                var itemType = commandParts[2].ToLower();
                var email = commandParts[3];

                int? itemId = null;

                if (itemType == "file")
                {
                    itemId = _sharingItemService.GetFileIdByName(itemName);
                }
                else if (itemType == "folder")
                {
                    itemId = _sharingItemService.GetFolderIdByName(itemName, _userId);
                }

                if (itemId == null)
                {
                    Console.WriteLine("Item not found.");
                    Console.ReadLine();
                    return;
                }

                var result = _sharingItemService.ShareItem(itemId.Value, itemType, email, _userId);
                Console.WriteLine(result ? "Item shared successfully." : "Item sharing failed.");
            }
        }

        private void HandleStopSharingCommand(string[] commandParts)
        {
            if (commandParts.Length == 4)
            {
                var itemName = commandParts[1];
                var itemType = commandParts[2].ToLower();
                var email = commandParts[3];

                int? itemId = null;

                if (itemType == "file")
                {
                    itemId = _sharingItemService.GetFileIdByName(itemName);
                }
                else if (itemType == "folder")
                {
                    itemId = _sharingItemService.GetFolderIdByName(itemName, _userId);
                }

                if (itemId == null)
                {
                    Console.WriteLine("Item not found.");
                    Console.ReadLine();
                    return;
                }

                if (!_sharingItemService.IsOwnerOfItem(itemId.Value, itemType, _userId))
                {
                    Console.WriteLine("You are not the owner of this item. Only the owner can stop sharing.");
                    Console.ReadLine();
                    return;
                }

                var result = _sharingItemService.StopSharingItem(itemId.Value, itemType, email, _userId);
                Console.WriteLine(result ? "Sharing successfully stopped." : "Stopping sharing failed.");
            }
        }

        private void HandleEditFileCommand(string[] commandParts)
        {
            if (commandParts.Length == 2)
            {
                var fileName = commandParts[1];

                var fileId = _sharingItemService.GetFileIdByName(fileName);
                if (!fileId.HasValue)
                {
                    Console.WriteLine("File not found.");
                    Console.ReadLine();

                    return;
                }

                Console.WriteLine("Enter new file content:");
                var newContent = Console.ReadLine();

                if (string.IsNullOrEmpty(newContent))
                {
                    Console.WriteLine("Content cannot be empty.");
                    Console.ReadLine();

                    return;
                }

                Console.WriteLine($"Updating file content with ID: {fileId.Value}");

                var result = _sharingItemService.UpdateSharedFileContent(fileId.Value, newContent, _userId);
                Console.WriteLine(result ? "File content successfully updated." : "Updating file failed.");
            }
            else
            {
                Console.WriteLine("Invalid command format for editing the file.");
            }
        }

        private void HandleRemoveFromSharedCommand(string[] commandParts)
        {
            if (commandParts.Length == 2)
            {
                var fileName = commandParts[1];

                var fileId = _sharingItemService.GetFileIdByName(fileName);
                Console.WriteLine($"File name: {fileName}, File ID: {fileId}");

                if (!fileId.HasValue)
                {
                    Console.WriteLine("File not found in shared folder.");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine($"Removing file with ID: {fileId.Value} from shared folder.");

                try
                {
                    _sharingItemService.RemoveFromShared(fileId.Value, _userId);
                    Console.WriteLine("File successfully removed from shared folder.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid command format for removing file from shared folder.");
                Console.ReadLine();
            }
        }

        private void HandleCommentCommand(string[] commandParts)
        {
            if (commandParts.Length == 1)
            {
                Console.WriteLine("Enter a subcommand for comments (view, add, edit, delete):");
                var subCommand = Console.ReadLine()?.ToLower();

                switch (subCommand)
                {
                    case "view":
                        HandleShowComments();
                        break;

                    case "add":
                        HandleAddComment();
                        break;

                    case "edit":
                        HandleEditComment();
                        break;

                    case "delete":
                        HandleDeleteComment();
                        break;

                    default:
                        Console.WriteLine("Unknown subcommand for comments.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid command format for comments.");
            }
        }

        private void HandleShowComments()
        {
            if (_commentService == null)
            {
                Console.WriteLine("Error: CommentService is not initialized. Please ensure `SetCommentService` was called before using comment commands.");
                Console.ReadLine();
                return;
            }

            if (_commentPresentation == null)
            {
                Console.WriteLine("Error: CommentPresentation is not initialized. Please check the initialization in `SetCommentService`.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Enter the file name to display comments:");
            string fileName = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(fileName))
            {
                var fileId = _sharingItemService.GetFileIdByName(fileName);
                Console.WriteLine($"File: {fileName}, FileId: {fileId}");

                if (fileId.HasValue)
                {
                    _commentPresentation.ShowComments(fileId.Value);
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            else
            {
                Console.WriteLine("File name cannot be empty.");
            }
        }

        private void HandleAddComment()
        {
            if (_commentPresentation == null)
            {
                Console.WriteLine("Error: CommentService is not initialized.");
                return;
            }

            Console.WriteLine("Enter the name of the file you want to add a comment to:");
            string fileName = Console.ReadLine();

            var fileId = _sharingItemService.GetFileIdByName(fileName);

            if (fileId.HasValue)
            {
                _commentPresentation.AddComment(_userId, fileId.Value);
            }
            else
            {
                Console.WriteLine("File not found or invalid file name.");
            }
        }


        private void HandleEditComment()
        {
            if (_commentPresentation == null)
            {
                Console.WriteLine("Error: CommentService is not initialized.");
                return;
            }

            Console.WriteLine("Enter the ID of the comment you want to edit:");
            if (int.TryParse(Console.ReadLine(), out int commentId))
            {
                _commentPresentation.UpdateComment(commentId, _userId);
            }
            else
            {
                Console.WriteLine("Invalid comment ID.");
            }
        }

        private void HandleDeleteComment()
        {
            if (_commentPresentation == null)
            {
                Console.WriteLine("Error: CommentService is not initialized.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Enter the ID of the comment you want to delete:");

            if (int.TryParse(Console.ReadLine(), out int commentId))
            {
                _commentPresentation.DeleteComment(commentId, _userId);
            }
            else
            {
                Console.WriteLine("Invalid comment ID.");
                Console.ReadLine();
            }
        }
    }
}