using AlbuixechHealthcareCentre.models;
using AlbuixechHealthcareCentre.repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlbuixechHealthcareCentre.services
{
    public class PatientService
    {
        private readonly Repository<Patient> patientRepo;
        private readonly UserService userService;
        private readonly MedicalRecordService medicalRecordService;

        public PatientService()
        {
            patientRepo = new Repository<Patient>();
            userService = new UserService(); 
            medicalRecordService = new MedicalRecordService(); 
        }

        public IEnumerable<Patient> GetPatients()
        {
            string query = "SELECT * FROM Patients";
            return patientRepo.GetAll(query, null, reader => new Patient
            {
                PatientID = Convert.ToInt32(reader["PatientID"]),
                Name = reader["Name"].ToString(),
                DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString()),
                Address = reader["Address"].ToString(),
                Mobile = reader["Mobile"].ToString(),
                PIN = reader["PIN"].ToString(),
                UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : (int?)null
            });
        }

        public void CreatePatient(Patient patient, User user)
        {
            int userId = userService.RegisterUser(user);

            patient.UserID = userId;

            string query = "INSERT INTO Patients (Name, DateOfBirth, Address, Mobile, PIN, UserID) VALUES (@Name, @DateOfBirth, @Address, @Mobile, @PIN, @UserID)";
            patientRepo.ExecuteCommand(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Name", patient.Name);
                cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@Mobile", patient.Mobile);
                cmd.Parameters.AddWithValue("@PIN", patient.PIN);
                cmd.Parameters.AddWithValue("@UserID", patient.UserID);
            });
        }

        public void UpdatePatient(Patient patient, User user)
        {
            if (user != null)
            {
                userService.UpdateUser(user);
            }

            string query = "UPDATE Patients SET Name = @Name, DateOfBirth = @DateOfBirth, Address = @Address, Mobile = @Mobile, PIN = @PIN WHERE PatientID = @PatientID";
            patientRepo.ExecuteCommand(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Name", patient.Name);
                cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@Mobile", patient.Mobile);
                cmd.Parameters.AddWithValue("@PIN", patient.PIN);
                cmd.Parameters.AddWithValue("@PatientID", patient.PatientID);
            });
        }

        public void DeletePatient(int patientID)
        {
            var patient = GetPatients().FirstOrDefault(p => p.PatientID == patientID);

            if (patient == null)
            {
                throw new KeyNotFoundException("Patient not found.");
            }

            var medicalRecords = medicalRecordService.GetRecordsByPatient(patientID);
            foreach (var record in medicalRecords)
            {
                medicalRecordService.DeleteRecord(record.RecordID);
            }

            string query = "DELETE FROM Patients WHERE PatientID = @PatientID";
            patientRepo.ExecuteCommand(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@PatientID", patientID);
            });

            if (patient.UserID.HasValue)
            {
                userService.DeleteUser(patient.UserID.Value);
            }
        }

        public IEnumerable<Patient> SearchPatientsByName(string name)
        {
            string query = "SELECT * FROM Patients WHERE Name LIKE @Name";
            return patientRepo.GetAll(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Name", $"%{name}%");
            }, reader => new Patient
            {
                PatientID = Convert.ToInt32(reader["PatientID"]),
                Name = reader["Name"].ToString(),
                DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString()),
                Address = reader["Address"].ToString(),
                Mobile = reader["Mobile"].ToString(),
                PIN = reader["PIN"].ToString(),
                UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : (int?)null
            });
        }
    }
}
