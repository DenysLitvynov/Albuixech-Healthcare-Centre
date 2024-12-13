using AlbuixechHealthcareCentre.models;
using AlbuixechHealthcareCentre.services;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace AlbuixechHealthcareCentre.pages
{
    public partial class Doctor : System.Web.UI.Page
    {
        private readonly PatientService patientService = new PatientService();
        private readonly MedicalRecordService medicalRecordService = new MedicalRecordService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPatients();
                ShowNoPatientSelectedMessage();
            }
        }

        private void LoadPatients()
        {
            var patients = patientService.GetPatients();
            PatientGridView.DataSource = patients;
            PatientGridView.DataBind();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            var patients = string.IsNullOrEmpty(searchText)
                ? patientService.GetPatients()
                : patientService.SearchPatientsByName(searchText);

            PatientGridView.DataSource = patients;
            PatientGridView.DataBind();
        }

        protected void PatientGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PatientGridView.SelectedDataKey != null)
            {
                int patientId = Convert.ToInt32(PatientGridView.SelectedDataKey.Value);
                ViewState["SelectedPatientId"] = patientId;
                LoadMedicalRecords(patientId);
                CreateRecordButton.Visible = true;
            }
        }

        protected void PatientGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeletePatient")
            {
                int patientId = Convert.ToInt32(e.CommandArgument);
                try
                {
                    patientService.DeletePatient(patientId);
                    LoadPatients();
                    ShowNoPatientSelectedMessage();
                    Response.Write("<script>alert('Patient deleted successfully!');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                }
            }
        }

        private void LoadMedicalRecords(int patientId)
        {
            var records = medicalRecordService.GetRecordsByPatient(patientId);

            if (records.Any())
            {
                MedicalRecordGridView.DataSource = records;
                MedicalRecordGridView.DataBind();
                MedicalRecordGridView.Visible = true;
                NoPatientSelectedLabel.Visible = false;
            }
            else
            {
                ShowNoPatientSelectedMessage();
            }
        }

        protected void MedicalRecordGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRecord")
            {
                int recordId = Convert.ToInt32(e.CommandArgument);
                var record = medicalRecordService.GetRecordById(recordId);
                PopulateMedicalRecordForm(record);
                MedicalRecordForm.Visible = true;
            }
            else if (e.CommandName == "DeleteRecord")
            {
                int recordId = Convert.ToInt32(e.CommandArgument);
                medicalRecordService.DeleteRecord(recordId);
                int patientId = (int)ViewState["SelectedPatientId"];
                LoadMedicalRecords(patientId);
            }
        }

        protected void CreateRecordButton_Click(object sender, EventArgs e)
        {
            ClearMedicalRecordForm();
            MedicalRecordForm.Visible = true;
        }

        protected void SaveRecordButton_Click(object sender, EventArgs e)
        {
            int patientId = (int)ViewState["SelectedPatientId"];
            var record = new MedicalRecord
            {
                RecordID = string.IsNullOrEmpty(RecordIDHiddenField.Value) ? 0 : Convert.ToInt32(RecordIDHiddenField.Value),
                PatientID = patientId,
                DoctorID = GetCurrentDoctorId(),
                AppointmentDate = Convert.ToDateTime(AppointmentDateTextBox.Text),
                Diagnosis = DiagnosisTextBox.Text,
                Treatment = TreatmentTextBox.Text
            };

            if (record.RecordID == 0)
            {
                medicalRecordService.CreateRecord(record);
            }
            else
            {
                medicalRecordService.UpdateRecord(record);
            }

            LoadMedicalRecords(patientId);
            MedicalRecordForm.Visible = false;
        }

        protected void CancelEditButton_Click(object sender, EventArgs e)
        {
            MedicalRecordForm.Visible = false;
        }

        private void PopulateMedicalRecordForm(MedicalRecord record)
        {
            RecordIDHiddenField.Value = record.RecordID.ToString();
            AppointmentDateTextBox.Text = record.AppointmentDate.ToString("yyyy-MM-dd");
            DiagnosisTextBox.Text = record.Diagnosis;
            TreatmentTextBox.Text = record.Treatment;
        }

        private void ClearMedicalRecordForm()
        {
            RecordIDHiddenField.Value = string.Empty;
            AppointmentDateTextBox.Text = string.Empty;
            DiagnosisTextBox.Text = string.Empty;
            TreatmentTextBox.Text = string.Empty;
        }

        private void ShowNoPatientSelectedMessage()
        {
            MedicalRecordGridView.Visible = false;
            NoPatientSelectedLabel.Visible = true;
            CreateRecordButton.Visible = false;
        }

        private int GetCurrentDoctorId()
        {
            return Convert.ToInt32(Session["DoctorID"]);
        }
    }
}
