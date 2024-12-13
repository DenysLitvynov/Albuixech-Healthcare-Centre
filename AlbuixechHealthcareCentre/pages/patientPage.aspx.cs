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
            if (Session["Role"] == null || Session["Role"].ToString() != "patient")
            {
                Response.Redirect("Login.aspx");
                return;
            }

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
            var patient = _patientService.GetPatients().FirstOrDefault(p => p.UserID == userId);
            if (patient != null)
            {
                PatientNameLabel.Text = patient.Name;
                DateOfBirthLabel.Text = patient.DateOfBirth.ToString("yyyy-MM-dd");
                AddressLabel.Text = patient.Address;
                MobileLabel.Text = patient.Mobile;
                PINLabel.Text = patient.PIN;

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
