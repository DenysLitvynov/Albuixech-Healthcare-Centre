using AlbuixechHealthcareCentre.models;
using AlbuixechHealthcareCentre.services;
using System;

namespace AlbuixechHealthcareCentre.pages
{
    public partial class CreatePatient : System.Web.UI.Page
    {
        private readonly PatientService _patientService;

        public CreatePatient()
        {
            // Inicializa el servicio de pacientes
            _patientService = new PatientService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verifica si el usuario tiene rol de Doctor
                if (Session["Role"] == null || Session["Role"].ToString() != "doctor")
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void CreatePatientButton_Click(object sender, EventArgs e)
        {
            
                // Crea un nuevo usuario para el paciente
                User newUser = new User
                {
                    UserName = UsernameTextBox.Text,
                    Password = PasswordTextBox.Text,
                    Role = RoleDropDown.SelectedValue
                };

                // Crea un nuevo objeto paciente con los datos del formulario
                Patient newPatient = new Patient
                {
                    Name = NameTextBox.Text,
                    DateOfBirth = Convert.ToDateTime(DateOfBirthTextBox.Text),
                    Address = AddressTextBox.Text,
                    Mobile = MobileTextBox.Text,
                    PIN = PINTextBox.Text
                };

                // Llama al servicio para crear el paciente y el usuario asociado
                _patientService.CreatePatient(newPatient, newUser);
            try
            {
                // Limpia el formulario tras la creación
                ClearForm();

                // Muestra mensaje de éxito
                Response.Write("<script>alert('Patient created successfully!');</script>");
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }

        private void ClearForm()
        {
            // Limpia los campos del formulario
            NameTextBox.Text = string.Empty;
            DateOfBirthTextBox.Text = string.Empty;
            AddressTextBox.Text = string.Empty;
            MobileTextBox.Text = string.Empty;
            PINTextBox.Text = string.Empty;
            UsernameTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
            RoleDropDown.SelectedIndex = 0;
        }
    }
}
