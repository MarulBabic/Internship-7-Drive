# Drive Simulation Project

This project simulates a cloud drive system where users can share files and folders. It also includes user authentication and role management.

## Features
- User authentication and authorization.
- Sharing files and folders between users.
- PostgreSQL database integration for data storage.

---

## Prerequisites
1. **.NET SDK 8.0 or higher**
2. **PostgreSQL** (installed and running)

# Steps to Run the Project

1. Clone the repository:
   git clone https://github.com/your-repo.git
   cd your-repo

2. Restore dependencies:
   dotnet restore

3. Apply existing migrations:
   Note: If migrations already exist in the project (e.g., in the `Migrations` folder), there’s no need to run `Add-Migration`.
   Instead, generate the SQL script for the existing migrations:
   Script-Migration
   
   If you want to apply a migration that is not the latest one,
   you can specify the previous migration and the target migration in the following way:
   Script-Migration -From <PreviousMigrationName> -To <TargetMigrationName> -Output <OutputFileName>.sql

5. Apply the SQL script to the PostgreSQL database:
   Open the PostgreSQL Query Tool.
   Paste the generated SQL script.
   Run the script to generate all tables and seed data in the database.

6. Update the connection string in the `appsettings.json` file to match your PostgreSQL configuration:
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=DriveDB;Username=your-username;Password=your-password"
     }
   }

# Additional Notes
Ensure the PostgreSQL database is running and the connection string is correct before starting the application.
If you need to make changes to the database schema, use:
   Add-Migration MigrationName
   Update-Database
However, this is not required if migrations are already created.





