using System;
using System.IO;
using DbUp;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TestTemplate11.Migrations
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var connectionString = string.Empty;
            var dbUser = string.Empty;
            var dbPassword = string.Empty;
            var scriptsPath = string.Empty;
            var sqlUsersGroupName = string.Empty;

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                ?? "Production";
            Console.WriteLine($"Environment: {env}.");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            InitializeParameters();
            var connectionStringBuilderTestTemplate11 = new SqlConnectionStringBuilder(connectionString);
            if (env.Equals("Development"))
            {
                connectionStringBuilderTestTemplate11.UserID = dbUser;
                connectionStringBuilderTestTemplate11.Password = dbPassword;
            }
            else
            {
                connectionStringBuilderTestTemplate11.UserID = dbUser;
                connectionStringBuilderTestTemplate11.Password = dbPassword;
                connectionStringBuilderTestTemplate11.Authentication = SqlAuthenticationMethod.ActiveDirectoryPassword;
            }
            var upgraderTestTemplate11 =
                DeployChanges.To
                    .SqlDatabase(connectionStringBuilderTestTemplate11.ConnectionString)
                    .WithVariable("SqlUsersGroupNameVariable", sqlUsersGroupName)    // This is necessary to perform template variable replacement in the scripts.
                    .WithScriptsFromFileSystem(
                        !string.IsNullOrWhiteSpace(scriptsPath)
                                ? Path.Combine(scriptsPath, "TestTemplate11Scripts")
                            : Path.Combine(Environment.CurrentDirectory, "TestTemplate11Scripts"))
                    .LogToConsole()
                    .Build();
            Console.WriteLine($"Now upgrading TestTemplate11.");
            if (env == "Development")
            {
                upgraderTestTemplate11.MarkAsExecuted("0000_AzureSqlContainedUser.sql");
            }
            var resultTestTemplate11 = upgraderTestTemplate11.PerformUpgrade();

            if (!resultTestTemplate11.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"TestTemplate11 upgrade error: {resultTestTemplate11.Error}");
                Console.ResetColor();
                return -1;
            }

            // Uncomment the below sections if you also have an Identity Server project in the solution.
            /*
            var connectionStringTestTemplate11Identity = string.IsNullOrWhiteSpace(args.FirstOrDefault())
                ? config["ConnectionStrings:TestTemplate11IdentityDb"]
                : args.FirstOrDefault();

            var upgraderTestTemplate11Identity =
                DeployChanges.To
                    .SqlDatabase(connectionStringTestTemplate11Identity)
                    .WithScriptsFromFileSystem(
                        scriptsPath != null
                            ? Path.Combine(scriptsPath, "TestTemplate11IdentityScripts")
                            : Path.Combine(Environment.CurrentDirectory, "TestTemplate11IdentityScripts"))
                    .LogToConsole()
                    .Build();
            Console.WriteLine($"Now upgrading TestTemplate11 Identity.");
            if (env != "Development")
            {
                upgraderTestTemplate11Identity.MarkAsExecuted("0004_InitialData.sql");
                Console.WriteLine($"Skipping 0004_InitialData.sql since we are not in Development environment.");
                upgraderTestTemplate11Identity.MarkAsExecuted("0005_Initial_Configuration_Data.sql");
                Console.WriteLine($"Skipping 0005_Initial_Configuration_Data.sql since we are not in Development environment.");
            }
            var resultTestTemplate11Identity = upgraderTestTemplate11Identity.PerformUpgrade();

            if (!resultTestTemplate11Identity.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"TestTemplate11 Identity upgrade error: {resultTestTemplate11Identity.Error}");
                Console.ResetColor();
                return -1;
            }
            */

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;

            void InitializeParameters()
            {
                // Local database, populated from .env file.
                if (args.Length == 0)
                {
                    connectionString = config["TestTemplate11Db_Migrations_Connection"];
                    dbUser = config["DbUser"];
                    dbPassword = config["DbPassword"];
                }

                // Deployed database
                else if (args.Length == 5)
                {
                    connectionString = args[0];
                    dbUser = args[1];
                    dbPassword = args[2];
                    scriptsPath = args[3];
                    sqlUsersGroupName = args[4];
                }
            }
        }
    }
}
