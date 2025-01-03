using System;
using Domain.Services;
using Data.Entities.Models;
using Presentation;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<DumpDriveDbContext>()
                .UseNpgsql("Host=127.0.0.1;Port=5433;Database=DumpDrive;Username=postgres;Password=admin;")
                .Options;

            var dbContext = new DumpDriveDbContext(options);

            var userRepository = new UserRepository(dbContext);
            var userSettingsService = new UserSettingsService(userRepository);

            var folderRepository = new FolderRepository(dbContext);
            var fileRepository = new FileRepository(dbContext);
            var driveService = new DriveService(folderRepository, fileRepository);

            var sharedItemRepository = new SharedItemRepository(dbContext);
            var sharingItemService = new SharingItemService(sharedItemRepository, userRepository, fileRepository, folderRepository);



            var authService = new AuthenticationService(userRepository);

            var mainMenu = new MainMenu(authService);

            var loggedInUser = authService.GetLoggedInUser();
            if (loggedInUser == null)
            {
                Console.WriteLine("User is not logged in. Please login.");
                mainMenu.Show();
                return;
            }
            var commandHandler = new CommandHandler(null, driveService);
            var driveMenu = new DriveMenu(driveService, loggedInUser.Id, commandHandler);
            commandHandler.SetDriveMenu(driveMenu);

            var profileSettingsMenu = new ProfileSettingsMenu(userSettingsService, loggedInUser);
            var userMenu = new UserMenu(authService, mainMenu);
            mainMenu.SetUserMenu(userMenu);


            var commentRepository = new CommentRepository(dbContext);
            var commentService = new CommentService(commentRepository, userRepository, fileRepository);
            Console.WriteLine("CommentService postavljen.");
            var sharedItemCommands = new SharedItemCommands(sharingItemService, loggedInUser.Id);

            if (commentService == null)
            {
                Console.WriteLine("Greška: CommentService nije inicijalizovan. Proverite da li je CommentRepository pravilno postavljen.");
            }
            else
            {
                sharedItemCommands.SetCommentService(commentService);
                Console.WriteLine("CommentService uspešno postavljen u SharedItemCommands.");
            }

            mainMenu.Show();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter a command (or 'help' for a list of commands): ");
                var command = Console.ReadLine();
                if (string.IsNullOrEmpty(command)) continue;
                sharedItemCommands.ExecuteCommand(command);
            }
        }
    }
}
