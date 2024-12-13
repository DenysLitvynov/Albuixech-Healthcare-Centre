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
            _patientService = new PatientService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Role"] == null || Session["Role"].ToString() != "doctor")
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void CreatePatientButton_Click(object sender, EventArgs e)
        {
            
                User newUser = new User
                {
                    UserName = UsernameTextBox.Text,
                    Password = PasswordTextBox.Text,
                    Role = RoleDropDown.SelectedValue
                };

                Patient newPatient = new Patient
                {
                    Name = NameTextBox.Text,
                    DateOfBirth = Convert.ToDateTime(DateOfBirthTextBox.Text),
                    Address = AddressTextBox.Text,
                    Mobile = MobileTextBox.Text,
                    PIN = PINTextBox.Text
                };


                _patientService.CreatePatient(newPatient, newUser);
            try
            {
                ClearForm();

                Response.Write("<script>alert('Patient created successfully!');</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }

        private void ClearForm()
        {
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
