using System;
using Domain.Repositories;
using Domain.Services;

namespace Presentation
{
    public class SharedWithMe
    {
        private readonly SharingItemService _sharingItemService;
        private readonly int _userId;
        private readonly SharedItemCommands _sharedItemCommands;

        public SharedWithMe(SharingItemService sharingItemService, CommentService commentService, int userId)
        {
            _sharingItemService = sharingItemService;
            _userId = userId;
            _sharedItemCommands = new SharedItemCommands(_sharingItemService, _userId);

            if (commentService == null)
            {
                Console.WriteLine("Error: CommentService is not initialized. Comment commands will not work.");
            }
            else
            {
                _sharedItemCommands.SetCommentService(commentService);
                Console.WriteLine("CommentService successfully set in SharedItemCommands.");
            }
        }

        public void Show()
        {
            Console.Clear();

            while (true)
            {
                Console.Clear();


                if (_sharingItemService == null)
                {
                    Console.WriteLine("Error: Service is not initialized!");
                    return;
                }

                var sharedItems = _sharingItemService.GetItemsSharedWithUser(_userId);

                if (sharedItems.Count == 0)
                {
                    Console.WriteLine("No items have been shared with you.");
                }
                else
                {
                    Console.WriteLine("Shared items:");
                    foreach (var item in sharedItems)
                    {
                        string itemName = _sharingItemService.GetItemName(item);
                        string itemType = item.SharedItemType == Data.Enums.ItemType.File ? "File" : "Folder";

                        string ownerEmail = _sharingItemService.GetUserEmailById(item.OwnerUserId);

                        Console.WriteLine($"- {itemType}: {itemName} (Owner: {ownerEmail})");
                    }
                }

                Console.WriteLine("\nCommands:");
                Console.WriteLine(":share [name] [type: file/folder] [email] - Share an item");
                Console.WriteLine(":stop [name] [type: file/folder] [email] - Stop sharing an item");
                Console.WriteLine(":edit [file name] - Edit a shared file");
                Console.WriteLine(":remove [file name] - Remove a shared file from your folder");
                Console.WriteLine(":comments [view/add/edit/delete] - Manage comments");
                Console.WriteLine(":back - Return to the main menu");

                var command = Console.ReadLine();
                if (string.IsNullOrEmpty(command)) continue;

                if (command.ToLower() == ":back") break;

                _sharedItemCommands.ExecuteCommand(command);
            }
        }
    }
}
