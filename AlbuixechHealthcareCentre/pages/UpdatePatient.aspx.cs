using AlbuixechHealthcareCentre.models;
using AlbuixechHealthcareCentre.services;
using System;
using System.Linq;

namespace AlbuixechHealthcareCentre.pages
{
    public partial class UpdatePatient : System.Web.UI.Page
    {
        private readonly PatientService _patientService;
        private readonly UserService _userService;

        public UpdatePatient()
        {
            _patientService = new PatientService();
            _userService = new UserService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Role"] == null || Session["Role"].ToString() != "doctor")
                {
                    Response.Redirect("Login.aspx");
                }

                if (int.TryParse(Request.QueryString["PatientID"], out int patientID))
                {
                    LoadPatientData(patientID);
                }
                else
                {
                    Response.Write("<script>alert('Invalid Patient ID.');</script>");
                    Response.Redirect("Doctor.aspx");
                }
            }
        }

        private void LoadPatientData(int patientID)
        {
            // Cargar datos del paciente
            var patient = _patientService.GetPatients().FirstOrDefault(p => p.PatientID == patientID);

            if (patient != null)
            {
                // Asignar datos del paciente
                NameTextBox.Text = patient.Name;
                DateOfBirthTextBox.Text = patient.DateOfBirth.ToString("yyyy-MM-dd");
                AddressTextBox.Text = patient.Address;
                MobileTextBox.Text = patient.Mobile;
                PINTextBox.Text = patient.PIN;

                // Cargar datos del usuario si existe
                if (patient.UserID.HasValue)
                {
                    try
                    {
                        var user = _userService.AuthUserById(patient.UserID.Value);
                        if (user != null)
                        {
                            UsernameTextBox.Text = user.UserName;
                            RoleDropDown.SelectedValue = user.Role;
                        }
                        else
                        {
                            Response.Write("<script>alert('User associated with this patient not found.');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('Error loading user data: {ex.Message}');</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Patient not found.');</script>");
                Response.Redirect("Doctor.aspx");
            }
        }

        protected void UpdatePatientButton_Click(object sender, EventArgs e)
        {
            try
            {
                int patientID = Convert.ToInt32(Request.QueryString["PatientID"]);

                // Actualizar información del paciente
                var patient = _patientService.GetPatients().FirstOrDefault(p => p.PatientID == patientID);
                if (patient == null)
                {
                    Response.Write("<script>alert('Patient not found for update.');</script>");
                    return;
                }

                Patient updatedPatient = new Patient
                {
                    PatientID = patientID,
                    Name = NameTextBox.Text,
                    DateOfBirth = Convert.ToDateTime(DateOfBirthTextBox.Text),
                    Address = AddressTextBox.Text,
                    Mobile = MobileTextBox.Text,
                    PIN = PINTextBox.Text,
                    UserID = patient.UserID // Mantener el UserID actual
                };

                // Actualizar información del usuario si existe
                if (patient.UserID.HasValue)
                {
                    User updatedUser = new User
                    {
                        UserId = patient.UserID.Value,
                        UserName = UsernameTextBox.Text,
                        Password = PasswordTextBox.Text,
                        Role = RoleDropDown.SelectedValue
                    };

                    _patientService.UpdatePatient(updatedPatient, updatedUser);
                }
                else
                {
                    _patientService.UpdatePatient(updatedPatient, null);
                }

                Response.Write("<script>alert('Patient and user updated successfully!');</script>");
                Response.Redirect("Doctor.aspx");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }
    }
}
