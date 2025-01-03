using System;
using System.Linq;
using Domain.Services;
using Domain.Repositories;

namespace Presentation
{
    public class CommandHandler
    {
        private DriveMenu _driveMenu;
        private readonly DriveService _driveService;

        public CommandHandler(DriveMenu driveMenu, DriveService driveService)
        {
            _driveMenu = driveMenu;
            _driveService = driveService;
        }
        public void SetDriveMenu(DriveMenu driveMenu)
        {
            _driveMenu = driveMenu ?? throw new ArgumentNullException(nameof(driveMenu));
        }

        public void ExecuteCommand(string command)
        {
            var commandParts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (commandParts.Length == 0)
                return;

            var mainCommand = commandParts[0].ToLower();

            switch (mainCommand)
            {
                case "help":
                    ShowHelp();
                    break;
                case "create":
                    if (commandParts.Length > 1)
                    {
                        Create(commandParts[1]);
                    }
                    break;
                case "enter":
                    if (commandParts.Length > 1)
                    {
                        EnterDirectory(commandParts[1]);
                    }
                    break;
                case "edit":
                    if (commandParts.Length > 1)
                    {
                        var fileEditor = new FileEditor(_driveService, _driveMenu);
                        fileEditor.StartEditing(commandParts[1]);
                    }
                    break;
                case "delete":
                    if (commandParts.Length > 1)
                    {
                        Delete(commandParts[1]);
                    }
                    break;
                case "rename":
                    if (commandParts.Length > 2)
                    {
                        Rename(commandParts[1], commandParts[2]);
                    }
                    break;
                default:
                    Console.WriteLine("Unknown command. Enter 'help' for the list of commands.");
                    break;
            }
        }

        private void ShowHelp()
        {
            Console.WriteLine("=== Help ===");
            Console.WriteLine("1. help - Shows the list of all commands");
            Console.WriteLine("2. Create 'folder/file name' - Create a new folder or file (File must have an extension like .txt, .docx, etc.)");
            Console.WriteLine("3. enter 'folder name' - Enter a folder");
            Console.WriteLine("4. edit 'file name' - Edit a file");
            Console.WriteLine("5. delete 'folder/file name' - Delete a folder/file");
            Console.WriteLine("6. rename 'old name' to 'new name' - Rename a folder/file");
        }

        private void Create(string name)
        {
            Console.WriteLine($"Are you sure you want to create '{name}'? (y/n)");
            var confirmation = Console.ReadLine()?.ToLower();
            if (confirmation == "y")
            {
                if (name.Contains('.'))
                {
                    Console.WriteLine("Enter the content of the file:");
                    string content = Console.ReadLine();

                    Console.WriteLine("Enter the folder name where you want to create the file:");
                    string folderName = Console.ReadLine();

                    var folder = _driveService.GetFolder(folderName, _driveMenu._userId);
                    if (folder == null)
                    {
                        Console.WriteLine("Folder not found. Please try again.");
                    }
                    else
                    {
                        _driveService.CreateFile(name, _driveMenu._userId, content, folder.Id);
                        Console.WriteLine($"File '{name}' was successfully created in folder '{folderName}'.");
                    }
                }
                else
                {
                    _driveService.CreateFolder(name, _driveMenu._userId);
                    Console.WriteLine($"Folder '{name}' was successfully created.");
                }
            }
            else
            {
                Console.WriteLine("Creation canceled.");
            }
        }

        private void EnterDirectory(string folderName)
        {
            var folder = _driveService.GetFolder(folderName, _driveMenu._userId);
            if (folder != null)
            {
                _driveMenu.EnterFolder(folder);
            }
            else
            {
                Console.WriteLine($"Folder '{folderName}' was not found.");
            }
        }




        private void Rename(string oldName, string newName)
        {
            Console.WriteLine($"Are you sure you want to rename '{oldName}' to '{newName}'? (y/n)");
            var confirmation = Console.ReadLine()?.ToLower();

            if (confirmation == "y")
            {
                bool result;
                if (oldName.Contains('.'))
                {
                    result = _driveService.RenameFile(oldName, newName, _driveMenu._userId);
                    if (result)
                    {
                        Console.WriteLine($"File '{oldName}' has been renamed to '{newName}'.");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to rename file '{oldName}' to '{newName}'.File doesn't exits.");
                    }
                }
                else
                {
                    result = _driveService.RenameFolder(oldName, newName, _driveMenu._userId);
                    if (result)
                    {
                        Console.WriteLine($"Folder '{oldName}' has been renamed to '{newName}'.");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to rename folder '{oldName}' to '{newName}'.Folder doesn't exist.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Renaming canceled.");
            }
        }

        private void Delete(string name)
        {
            Console.WriteLine($"Are you sure you want to delete '{name}'? (y/n)");
            var confirmation = Console.ReadLine()?.ToLower();

            if (confirmation == "y")
            {
                bool result;
                if (name.Contains('.'))
                {
                    result = _driveService.DeleteFile(name, _driveMenu._userId);
                    if (result)
                    {
                        Console.WriteLine($"File '{name}' has been deleted.");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to delete file '{name}'.It doesn't exist.");
                    }
                }
                else
                {
                    result = _driveService.DeleteFolder(name, _driveMenu._userId);
                    if (result)
                    {
                        Console.WriteLine($"Folder '{name}' has been deleted.");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to delete folder '{name}'.It doesn't exist.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Deletion canceled.");
            }
        }
    }
}
