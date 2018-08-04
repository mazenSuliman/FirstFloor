using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GroundFloor.Models;
using System.Data;
using System.Data.SqlClient;

namespace GroundFloor.Controllers
{

    public class HomeController : Controller
    {

        //private SqlConnection _conn;
        private string connstring = "Data Source=172.16.4.35;Initial Catalog=ALDar_Hospital;Persist Security Info=True;User ID=app;Password=ml1234";

        public IActionResult Index()
        {

            //Random rand = new Random();
            //var n = rand.Next(1, 100);

           SqlConnection conn = new SqlConnection(connstring);
           conn.Open();
        

            string query = "SELECT TOP(1) ISNULL(ID, 0) FROM Ticket1 ORDER BY ID";
            SqlCommand cmd = new SqlCommand(query, conn);

            var n = (Int32) cmd.ExecuteScalar();

            var model = new IndexViewModel();
            model.n = n;

            cmd.CommandText = "DELETE FROM Ticket1 WHERE ID = @n";
            cmd.Parameters.AddWithValue("@n", n);
            cmd.ExecuteNonQuery();

            return View(model);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
