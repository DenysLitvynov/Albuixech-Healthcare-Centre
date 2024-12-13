using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using AlbuixechHealthcareCentre.models;
using AlbuixechHealthcareCentre.services;

namespace AlbuixechHealthcareCentre.pages
{
    public partial class Login : Page
    {
        private readonly UserService _userService;

        public Login()
        {
            // Inicializa el servicio de usuarios
            _userService = new UserService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = Request.Form["email"];
            string password = Request.Form["password"];
            string hashedPassword = HashPassword(password); // Hashea la contraseña ingresada

            User authenticatedUser = _userService.AuthUser(username, password);

            try
            {
                // Llama al servicio de autenticación
                //User authenticatedUser = _userService.AuthUser(username, password);

                if (authenticatedUser != null)
                {
                    // Si el usuario es válido, almacena la información en la sesión
                    Session["username"] = authenticatedUser.UserName;
                    Session["userId"] = authenticatedUser.UserId;
                    Session["Role"] = authenticatedUser.Role.ToLower();
                    // Redirige según el rol del usuario
                    RedirectBasedOnRole(authenticatedUser.Role);
                }
                else
                {
                    ShowAlert("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.StackTrace);
                ShowAlert("Error: " + ex.Message);
                // Debugging: Imprime el error en la consola del navegador
                Response.Write("<script>console.error('Exception occurred: " + ex.Message + "');</script>");
            }
        }

        private string HashPassword(string password)
        {
            // Hashea la contraseña con MD5
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(data).Replace("-", string.Empty).ToLower();
            }
        }

        private void RedirectBasedOnRole(string userRole)
        {
            try
            {
                switch (userRole.ToLower())
                {
                    case "patient":
                        Response.Redirect("PatientPage.aspx");
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