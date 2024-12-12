using AlbuixechHealthcareCentre.classes;
using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlbuixechHealthcareCentre.pages
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pathDB = Server.MapPath("~/BDD.db");
            string username = Request.Form["email"];
            string password = Request.Form["password"];

            try
            {
                // Debug message to confirm input capture
                Response.Write("<script>console.log('Step 1: Captured inputs - Username: " + username + "');</script>");

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + pathDB + ";Version=3;"))
                {
                    conn.Open();
                    // Debug message to confirm database connection
                    Response.Write("<script>console.log('Step 2: Connected to the database');</script>");

                    string query = "SELECT UserID, Password, Role FROM Users WHERE Username = @username";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Debug message to confirm user found
                                Response.Write("<script>console.log('Step 3: User found in the database');</script>");
                                int userId = Convert.ToInt32(reader["UserID"]);
                                string storedHash = reader["Password"].ToString();
                                string userRole = reader["Role"].ToString();

                                // Debug message to display stored hash
                                Response.Write("<script>console.log('Stored Hash: " + storedHash + "');</script>");

                                if (VerifyPassword(password, storedHash))
                                {
                                    Session["username"] = username;
                                    Session["userId"] = userId;
                                    // Debug message to confirm password verified
                                    Response.Write("<script>console.log('Step 4: Password verified');</script>");
                                    RedirectBasedOnRole(userRole);
                                }
                                else
                                {
                                    ShowAlert("Invalid username or password (password mismatch).");
                                }
                            }
                            else
                            {
                                ShowAlert("Invalid username or password (user not found).");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowAlert("Error: " + ex.Message);
                // Debug message to display error
                Response.Write("<script>console.error('Exception occurred: " + ex.Message + "');</script>");
            }
        }

        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] enteredData = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
                string enteredHash = BitConverter.ToString(enteredData).Replace("-", string.Empty).ToLower(); // Convertir a minúsculas
                // Debug message to display entered hash
                Response.Write("<script>console.log('Entered Hash: " + enteredHash + "');</script>");
                return enteredHash.Equals(storedHash.ToLower()); // Convertir a minúsculas antes de comparar
            }
        }

        private void RedirectBasedOnRole(string userRole)
        {
            try
            {
                switch (userRole.ToLower())
                {
                    case "patient":
                        Response.Redirect("Patient.aspx");
                        break;
                    case "doctor":
                        Response.Redirect("Doctor.aspx");
                        break;
                    default:
                        ShowAlert("Invalid role.");
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowAlert("Error during redirection: " + ex.Message);
            }
        }

        private void ShowAlert(string message)
        {
            Response.Write($"<script>alert('{message}');</script>");
        }
    }
}
