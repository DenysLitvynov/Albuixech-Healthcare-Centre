using AlbuixechHealthcareCentre.models;
using AlbuixechHealthcareCentre.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbuixechHealthcareCentre.services
{
    public class MedicalRecordService
    {
        private readonly Repository<MedicalRecord> recordRepo;

        public MedicalRecordService()
        {
            recordRepo = new Repository<MedicalRecord>();
        }

        // Get all records for a specific patient
        public IEnumerable<MedicalRecord> GetRecordsByPatient(int patientID)
        {
            string query = "SELECT * FROM MedicalRecords WHERE PatientID = @PatientID";
            return recordRepo.GetAll(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@PatientID", patientID);
            }, reader => new MedicalRecord
            {
                RecordID = Convert.ToInt32(reader["RecordID"]),
                PatientID = Convert.ToInt32(reader["PatientID"]),
                DoctorID = Convert.ToInt32(reader["DoctorID"]),
                AppointmentDate = DateTime.Parse(reader["AppointmentDate"].ToString()),
                Diagnosis = reader["Diagnosis"].ToString(),
                Treatment = reader["Treatment"].ToString()
            });
        }

        public MedicalRecord GetRecordById(int recordID)
        {
            string query = "SELECT * FROM MedicalRecords WHERE RecordID = @RecordID";
            var records = recordRepo.GetAll(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@RecordID", recordID);
            }, reader => new MedicalRecord
            {
                RecordID = Convert.ToInt32(reader["RecordID"]),
                PatientID = Convert.ToInt32(reader["PatientID"]),
                DoctorID = Convert.ToInt32(reader["DoctorID"]),
                AppointmentDate = DateTime.Parse(reader["AppointmentDate"].ToString()),
                Diagnosis = reader["Diagnosis"].ToString(),
                Treatment = reader["Treatment"].ToString()
            });

            // Return the first (and only) record or null if not found
            return records.FirstOrDefault();
        }
        // Create a new medical record
        public void CreateRecord(MedicalRecord record)
        {
            string query = "INSERT INTO MedicalRecords (PatientID, DoctorID, AppointmentDate, Diagnosis, Treatment) VALUES (@PatientID, @DoctorID, @AppointmentDate, @Diagnosis, @Treatment)";
            recordRepo.ExecuteCommand(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@PatientID", record.PatientID);
                cmd.Parameters.AddWithValue("@DoctorID", record.DoctorID);
                cmd.Parameters.AddWithValue("@AppointmentDate", record.AppointmentDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Diagnosis", record.Diagnosis);
                cmd.Parameters.AddWithValue("@Treatment", record.Treatment);
            });
        }

        // Update an existing medical record
        public void UpdateRecord(MedicalRecord record)
        {
            string query = "UPDATE MedicalRecords SET AppointmentDate = @AppointmentDate, Diagnosis = @Diagnosis, Treatment = @Treatment WHERE RecordID = @RecordID";
            recordRepo.ExecuteCommand(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@AppointmentDate", record.AppointmentDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Diagnosis", record.Diagnosis);
                cmd.Parameters.AddWithValue("@Treatment", record.Treatment);
                cmd.Parameters.AddWithValue("@RecordID", record.RecordID);
            });
        }

        // Delete a medical record
        public void DeleteRecord(int recordID)
        {
            string query = "DELETE FROM MedicalRecords WHERE RecordID = @RecordID";
            recordRepo.ExecuteCommand(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@RecordID", recordID);
            });
        }
    }
}