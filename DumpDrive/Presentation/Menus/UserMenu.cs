using System;
using Domain.Services;
using Data.Entities.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Presentation
{
    public class UserMenu
    {
        private User? _user;
        private readonly AuthenticationService _authService;
        private readonly MainMenu _mainMenu;
        private ProfileSettingsMenu _profileSettingsMenu;
        private DriveMenu _driveMenu;
        private DriveService _driveService;
        private CommandHandler commandHandler;

        private SharedWithMe _sharedWithMe;


        public UserMenu(AuthenticationService authService, MainMenu mainMenu)
        {
            _authService = authService;
            _mainMenu = mainMenu;
            _user = _authService.GetLoggedInUser();

            InitializeMenuItems();
        }
        private void InitializeMenuItems()
        {
            _user = _authService.GetLoggedInUser();

            if (_user == null)
            {
                Console.WriteLine("No user is logged in.");
                Console.ReadLine();
                _mainMenu.Show();
                return;
            }

            var options = new DbContextOptionsBuilder<DumpDriveDbContext>()
                .UseNpgsql("Host=127.0.0.1;Port=5433;Database=DumpDrive;Username=postgres;Password=postgres;")
                .Options;
            var dbContext = new DumpDriveDbContext(options);

            var folderRepository = new FolderRepository(dbContext);
            var fileRepository = new FileRepository(dbContext);
            var sharedItemRepository = new SharedItemRepository(dbContext);
            var userRepository = new UserRepository(dbContext);
            var commentRepository = new CommentRepository(dbContext);

            _driveService = new DriveService(folderRepository, fileRepository);

            var sharingItemService = new SharingItemService(
                sharedItemRepository,
                userRepository,
                fileRepository,
                folderRepository
            );

            var commentService = new CommentService(commentRepository, userRepository, fileRepository);

            _sharedWithMe = new SharedWithMe(sharingItemService, commentService, _user.Id);

            commandHandler = new CommandHandler(null, _driveService);
            _driveMenu = new DriveMenu(_driveService, _user.Id, commandHandler);
            commandHandler.SetDriveMenu(_driveMenu);
            var userSettingsService = new UserSettingsService(userRepository);
            _profileSettingsMenu = new ProfileSettingsMenu(userSettingsService, _user);
        }

        public void ShowUserMenu()
        {
            _user = _authService.GetLoggedInUser();

            if (_user == null)
            {
                Console.WriteLine("No user is logged in.");
                Console
                    .ReadLine();
                _mainMenu.Show();
                return;
            }

            Console.Clear();
            Console.WriteLine($"Welcome, {_user.FirstName} {_user.LastName}");
            Console.WriteLine("1. My Drive");
            Console.WriteLine("2. Shared with Me");
            Console.WriteLine("3. Profile Settings");
            Console.WriteLine("4. Logout");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowMyDrive();
                    break;
                case "2":
                    ShowSharedWithMe();
                    break;
                case "3":
                    ShowProfileSettings();
                    break;
                case "4":
                    Logout();
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    ShowUserMenu();
                    break;
            }
        }
        private void ShowMyDrive()
        {
            Console.Clear();
            Console.WriteLine("Displaying My Drive...");

            _user = _authService.GetLoggedInUser();
            if (_user == null)
            {
                Console.WriteLine("No user is logged in.");
                Console.ReadLine();
                _mainMenu.Show();
                return;
            }

            _driveMenu = new DriveMenu(_driveService, _user.Id, commandHandler);
            commandHandler.SetDriveMenu(_driveMenu);

            _driveMenu.InitializeDrive();
            _driveMenu.ShowDrive();

            ShowUserMenu();
        }

        private void ShowSharedWithMe()
        {
            InitializeMenuItems();
            Console.Clear();
            Console.WriteLine("Displaying Shared with Me...");
            _sharedWithMe.Show();
            ShowUserMenu();

        }
        private void ShowProfileSettings()
        {
            InitializeMenuItems();

            Console.Clear();
            Console.WriteLine("Profile Settings...");
            _profileSettingsMenu.Show();

            ShowUserMenu();
        }


        private void Logout()
        {
            _authService.Logout();
            _user = null;

            Console.Clear();
            Console.WriteLine("Logged out successfully. Returning to the login screen.");
            _mainMenu.Show();
        }
    }
}