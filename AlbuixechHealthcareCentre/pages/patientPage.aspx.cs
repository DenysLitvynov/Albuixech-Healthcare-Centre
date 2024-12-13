using AlbuixechHealthcareCentre.models;
using AlbuixechHealthcareCentre.services;
using System;
using System.Linq;

namespace AlbuixechHealthcareCentre.pages
{
    public partial class PatientPage : System.Web.UI.Page
    {
        private readonly PatientService _patientService;
        private readonly MedicalRecordService _medicalRecordService;

        public PatientPage()
        {
            _patientService = new PatientService();
            _medicalRecordService = new MedicalRecordService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si el rol en Session es "patient"
            if (Session["Role"] == null || Session["Role"].ToString() != "patient")
            {
                Response.Redirect("Login.aspx");
                return;
            }

            // Obtener el UserID del paciente desde la sesión
            if (Session["UserID"] != null && int.TryParse(Session["UserID"].ToString(), out int userId))
            {
                LoadPatientData(userId);
            }
            else
            {
                Response.Write("<script>alert('Invalid session data. Please log in again.');</script>");
                Response.Redirect("Login.aspx");
            }
        }

        private void LoadPatientData(int userId)
        {
            // Cargar la información personal del paciente
            var patient = _patientService.GetPatients().FirstOrDefault(p => p.UserID == userId);
            if (patient != null)
            {
                PatientNameLabel.Text = patient.Name;
                DateOfBirthLabel.Text = patient.DateOfBirth.ToString("yyyy-MM-dd");
                AddressLabel.Text = patient.Address;
                MobileLabel.Text = patient.Mobile;
                PINLabel.Text = patient.PIN;

                // Cargar registros médicos asociados al paciente
                var medicalRecords = _medicalRecordService.GetRecordsByPatient(patient.PatientID);
                MedicalRecordGridView.DataSource = medicalRecords;
                MedicalRecordGridView.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Patient not found.');</script>");
                Response.Redirect("Login.aspx");
            }
        }
    }
}
