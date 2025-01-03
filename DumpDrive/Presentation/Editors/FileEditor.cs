using System;
using Domain.Services;
using Domain.Repositories;

namespace Presentation
{
    public class FileEditor
    {
        private readonly DriveService _driveService;
        private readonly DriveMenu _driveMenu;
        private string _currentFileName;
        private string _currentFileContent;

        public FileEditor(DriveService driveService, DriveMenu driveMenu)
        {
            _driveService = driveService;
            _driveMenu = driveMenu;
        }

        public void StartEditing(string fileName)
        {
            _currentFileName = fileName;
            var file = _driveService.GetFile(fileName, _driveMenu._userId);

            if (file != null)
            {
                _currentFileContent = file.Content;
                Console.WriteLine($"You have started editing the file: '{fileName}'");
                EditFileContent();
            }
            else
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
        }

        private void EditFileContent()
        {
            Console.WriteLine("For help, type 'help', to save type ':save', to exit type ':exit'.");
            Console.WriteLine("Current file content:\n");
            Console.WriteLine(_currentFileContent);
            Console.WriteLine("\nEnter new content or a command:");
            while (true)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    break;

                if (input.StartsWith(":"))
                {
                    var command = input.Substring(1).ToLower();

                    switch (command)
                    {
                        case "help":
                            ShowHelp();
                            break;
                        case "save":
                            SaveFile();
                            return;
                        case "exit":
                            ExitWithoutSaving();
                            return;
                        default:
                            Console.WriteLine("Unknown command. Type ':help' for a list of commands.");
                            break;
                    }
                }
                else
                {
                    _currentFileContent += input + "\n";
                    Console.WriteLine("File content has been updated.");
                }

                Console.WriteLine("\nCurrent file content:\n");
                Console.WriteLine(_currentFileContent);
                Console.WriteLine("\nEnter new content or a command:");
            }
        }

        private void ShowHelp()
        {
            Console.WriteLine("\n=== Help for editing the file ===");
            Console.WriteLine("1. help - Shows a list of commands");
            Console.WriteLine("2. save - Saves changes to the file");
            Console.WriteLine("3. exit - Exits the editor without saving changes");
            Console.WriteLine("To enter content, simply type the text.");
        }

        private void SaveFile()
        {
            Console.WriteLine($"Are you sure you want to save changes to the file '{_currentFileName}'? (y/n)");
            var confirmation = Console.ReadLine()?.ToLower();

            if (confirmation == "y")
            {
                _driveService.UpdateFileContent(_currentFileName, _driveMenu._userId, _currentFileContent);
                Console.WriteLine($"File '{_currentFileName}' has been successfully saved.");
            }
            else
            {
                Console.WriteLine("Saving cancelled.");
            }
        }

        private void ExitWithoutSaving()
        {
            Console.WriteLine("Exiting the editor without saving changes.");
            _driveMenu.ShowDrive();
        }
    }
}
