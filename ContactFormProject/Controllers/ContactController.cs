using Microsoft.AspNetCore.Mvc;
using ContactFormProject.Models;
using System.Data.SqlClient;

namespace ContactFormProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly string connectionString = "Server=localhost;Database=Project;Trusted_Connection=True;";

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Kontakt (Imie, Email, Wiadomosc) VALUES (@Imie, @Email, @Wiadomosc)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Imie", model.Imie);
                        cmd.Parameters.AddWithValue("@Email", model.Email);
                        cmd.Parameters.AddWithValue("@Wiadomosc", model.Wiadomosc);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                ViewBag.Message = "Wiadomość została wysłana.";
            }
            return View();
        }
    }
}