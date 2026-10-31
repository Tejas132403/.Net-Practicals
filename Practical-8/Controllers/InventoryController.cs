using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using InventoryManagementMVC.Models;

namespace InventoryManagementMVC.Controllers
{
    public class InventoryController : Controller
    {
        private string cs =
            ConfigurationManager
            .ConnectionStrings["InventoryConnection"]
            .ConnectionString;

        // READ: Display all products
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT * FROM Products";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product();

                    p.Id = Convert.ToInt32(reader["Id"]);
                    p.Name = reader["Name"].ToString();
                    p.Quantity = Convert.ToInt32(reader["Quantity"]);
                    p.Price = Convert.ToDecimal(reader["Price"]);

                    products.Add(p);
                }

                reader.Close();
            }

            return View(products);
        }

        // CREATE: Display product form
        public ActionResult Create()
        {
            return View();
        }

        // CREATE: Save new product
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query =
                        "INSERT INTO Products (Name, Quantity, Price) " +
                        "VALUES (@Name, @Quantity, @Price)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100)
                        .Value = p.Name;

                    cmd.Parameters.Add("@Quantity", SqlDbType.Int)
                        .Value = p.Quantity;

                    cmd.Parameters.Add("@Price", SqlDbType.Decimal)
                        .Value = p.Price;

                    cmd.Parameters["@Price"].Precision = 10;
                    cmd.Parameters["@Price"].Scale = 2;

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

                return RedirectToAction("Index");
            }

            return View(p);
        }

        // UPDATE: Display existing product
        public ActionResult Edit(int id)
        {
            Product p = null;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query =
                    "SELECT * FROM Products WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    p = new Product();

                    p.Id = Convert.ToInt32(reader["Id"]);
                    p.Name = reader["Name"].ToString();
                    p.Quantity = Convert.ToInt32(reader["Quantity"]);
                    p.Price = Convert.ToDecimal(reader["Price"]);
                }

                reader.Close();
            }

            if (p == null)
            {
                return HttpNotFound();
            }

            return View(p);
        }

        // UPDATE: Save changes
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query =
                        "UPDATE Products SET Name = @Name, " +
                        "Quantity = @Quantity, Price = @Price " +
                        "WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add("@Id", SqlDbType.Int)
                        .Value = p.Id;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100)
                        .Value = p.Name;

                    cmd.Parameters.Add("@Quantity", SqlDbType.Int)
                        .Value = p.Quantity;

                    cmd.Parameters.Add("@Price", SqlDbType.Decimal)
                        .Value = p.Price;

                    cmd.Parameters["@Price"].Precision = 10;
                    cmd.Parameters["@Price"].Scale = 2;

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

                return RedirectToAction("Index");
            }

            return View(p);
        }

        // DELETE: Remove a product
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query =
                    "DELETE FROM Products WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                con.Open();

                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }
    }
}