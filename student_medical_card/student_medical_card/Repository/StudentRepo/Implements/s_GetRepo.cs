
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using student_medical_card.Models;
using student_medical_card.Models.DTO;
using student_medical_card.Repository.StudentRepo.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;

namespace student_medical_card.Repository.StudentRepo.Implements
{
    public class s_GetRepo : s_IGetRepo
    {
        private readonly IConfiguration _configuration;

        public s_GetRepo(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        public Student_Prescription_DTO GetById(string s_Id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection")))
            {
                connection.Open();

                var query = @"
                    SELECT s.s_Id, s.s_Name, s.s_Dept, s.s_Gender, s.s_Email, s.b_Date,
                           p.p_Id, p.s_Id, p.health_condition, p.prescribeBy, p.prescribe_date_time
                    FROM Student s
                    LEFT JOIN Prescription p ON s.s_Id = p.s_Id
                    WHERE s.s_Id = @s_Id
                ";

                var studentPrescriptionDictionary = new Dictionary<string, Student_Prescription_DTO>();

                var result = connection.Query<Student, Prescription, Student_Prescription_DTO>(
                    query,
                    (student, prescription) =>
                    {
                        if (!studentPrescriptionDictionary.TryGetValue(student.s_Id, out var studentPrescription))
                        {
                            studentPrescription = new Student_Prescription_DTO();
                            studentPrescription.listPrescription = new List<Prescription>();
                            studentPrescriptionDictionary.Add(student.s_Id, studentPrescription);
                        }

                        if (prescription != null)
                        {
                            studentPrescription.listPrescription.Add(prescription);
                        }

                        return studentPrescription;
                    },
                    new { s_Id },
                    splitOn: "p_Id"
                ).Distinct();

                return result.FirstOrDefault();
            }
        }
    }
}