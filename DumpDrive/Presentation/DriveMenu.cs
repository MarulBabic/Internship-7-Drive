using Domain.Services;
using Data.Entities.Models;
using File = Data.Entities.Models.File;

using System;
using System.Collections.Generic;

namespace Presentation
{
    public class DriveMenu
    {
        private readonly DriveService _driveService;
        private CommandHandler _commandHandler;

        public int _userId { get; private set; }

        public DriveMenu(DriveService driveService, int userId, CommandHandler commandHandler)
        {
            _driveService = driveService;
            _userId = userId;
            _commandHandler = commandHandler;
        }
        public void SetCommandHandler(CommandHandler commandHandler)
        {
            _commandHandler = commandHandler ?? throw new ArgumentNullException(nameof(commandHandler));
        }
        public void InitializeDrive()
        {
            // Ovdje možete pozvati metodu koja osvežava podatke
            // Ako treba nešto posebno da se osveži, možete to implementirati ovde
            Console.WriteLine("Initializing Drive data...");
            var (folders, files) = _driveService.GetUserDrive(_userId); // Učitaj podatke o folderima i fajlovima
        }

        public void ShowDrive()
        {
            InitializeDrive();

            Console.Clear();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== My Drive ===");

                var (folders, files) = _driveService.GetUserDrive(_userId);

                Console.WriteLine("=== Folders ===");
                foreach (var folder in folders)
                {
                    Console.WriteLine($"Folder: {folder.Name}");
                }

                Console.WriteLine("\n=== Files ===");
                foreach (var file in files)
                {
                    Console.WriteLine($"File: {file.Name}, Last Modified: {file.UpdatedAt}");
                }

                Console.WriteLine("\nEnter a command (or 'help' for a list of commands): ");
                string command = Console.ReadLine();
                if (_commandHandler == null)
                {
                    throw new InvalidOperationException("CommandHandler is not initialized.");
                }

                if (!string.IsNullOrEmpty(command))
                {
                    _commandHandler.ExecuteCommand(command);
                }

                Console.WriteLine("\nPress any key to refresh the menu or 'exit' to go back.");
                string exitCommand = Console.ReadLine();
                if (exitCommand?.ToLower() == "exit")
                {
                    break;
                }
            }
        }
        public void EditFile(File file)
        {
            Console.WriteLine($"Editing file: {file.Name}");

            Console.WriteLine("Current file content:");
            Console.WriteLine("... file content ...");

            Console.WriteLine("\nEnter the new content for the file:");
            string newContent = Console.ReadLine();

            Console.WriteLine($"File '{file.Name}' has been updated with the new content.");
        }


        public void EnterFolder(Folder folder)
        {
            Console.Clear();
            Console.WriteLine($"Entering the folder: {folder.Name}");

            // Prikaz sadržaja mape
            var (folders, files) = _driveService.GetUserDrive(_userId);

            Console.WriteLine("=== Folders ===");
            foreach (var subFolder in folders.Where(f => f.ParentFolderId == folder.Id))
            {
                Console.WriteLine($"Folder: {subFolder.Name}");
            }

            Console.WriteLine("\n=== Files ===");
            foreach (var file in files.Where(f => f.FolderId == folder.Id))
            {
                Console.WriteLine($"File: {file.Name}, Last Modified: {file.UpdatedAt}");
            }

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Create a new file");
            Console.WriteLine("2. Create a new folder");  // Nova opcija za kreiranje foldera
            Console.WriteLine("3. Return to the previous menu");

            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine()?.Trim();

            if (choice == "1")
            {
                // Dodavanje nove datoteke
                Console.Write("Enter the name of the file (with extension, e.g., file.txt): ");
                var fileName = Console.ReadLine();

                Console.Write("Enter the content of the file: ");
                var content = Console.ReadLine();

                var result = _driveService.CreateFile(fileName, _userId, content, folder.Id);
                if (result)
                {
                    Console.WriteLine($"File '{fileName}' was successfully created in folder '{folder.Name}'.");
                }
                else
                {
                    Console.WriteLine($"Failed to create file '{fileName}' in folder '{folder.Name}'.");
                }
            }
            else if (choice == "2")
            {
                // Dodavanje novog foldera
                Console.Write("Enter the name of the new folder: ");
                var newFolderName = Console.ReadLine();

                _driveService.CreateFolder(newFolderName, _userId, folder.Id);
                Console.WriteLine($"Folder '{newFolderName}' was successfully created inside '{folder.Name}'.");
            }
            else if (choice == "3")
            {
                // Povratak na prethodni meni
                ShowDrive();
                return;
            }
            else
            {
                Console.WriteLine("Invalid choice. Returning to the previous menu.");
            }

            // Povratak u prikaz trenutne mape
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            EnterFolder(folder);
        }



    }
}
