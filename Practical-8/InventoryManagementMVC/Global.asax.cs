using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Configuration;
using System.Data.SqlClient;

namespace InventoryManagementMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Ensure the database and required table exist before the app starts
            try
            {
                EnsureDatabaseAndTable();
            }
            catch
            {
                // Swallow exceptions here so app start can continue and errors are visible at runtime
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void EnsureDatabaseAndTable()
        {
            var connStr = ConfigurationManager.ConnectionStrings["InventoryConnection"]?.ConnectionString;
            if (string.IsNullOrWhiteSpace(connStr)) return;

            // Parse initial catalog (database) from connection string
            var builder = new SqlConnectionStringBuilder(connStr);
            var database = builder.InitialCatalog;
            var masterBuilder = new SqlConnectionStringBuilder(connStr)
            {
                InitialCatalog = "master"
            };

            using (var con = new SqlConnection(masterBuilder.ConnectionString))
            {
                con.Open();

                // Create database if it doesn't exist
                var checkDbCmd = new SqlCommand($"IF DB_ID(N'{database}') IS NULL CREATE DATABASE [{database}];", con);
                checkDbCmd.ExecuteNonQuery();
            }

            // Ensure Products table exists
            using (var con = new SqlConnection(connStr))
            {
                con.Open();

                var checkTableCmd = new SqlCommand(@"
IF OBJECT_ID(N'dbo.Products', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Products
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Name VARCHAR(100) NOT NULL,
        Quantity INT NOT NULL,
        Price DECIMAL(10,2) NOT NULL
    );
END
", con);

                checkTableCmd.ExecuteNonQuery();
            }
        }
    }
}
