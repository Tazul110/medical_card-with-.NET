using Azure;
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
                var query = @"
                    SELECT *
                    FROM Student s
                    LEFT JOIN Prescription p ON s.s_Id = p.s_Id
                    WHERE s.s_Id = @s_Id
                ";

                var result = connection.Query<Student, Prescription, Student_Prescription_DTO>(
                    query,
                    (student, prescription) =>
                    {
                        var studentPrescription = new Student_Prescription_DTO
                        {
                            s_Id = student.s_Id,
                            s_Name = student.s_Name,
                            s_Dept = student.s_Dept,
                            s_Gender = student.s_Gender,
                            s_Email = student.s_Email,
                            b_Date = student.b_Date,
                            listPrescription = new List<Prescription>()
                        };

                        if (prescription != null)
                        {
                            studentPrescription.listPrescription.Add(prescription);
                        }

                        return studentPrescription;
                    },
                    new { s_Id },
                    splitOn: "p_Id"
                );

                return result.FirstOrDefault();
            }
            /* Student_Prescription_DTO response = new Student_Prescription_DTO();
             var query = @"
                     SELECT *
                     FROM Student s
                     LEFT JOIN Prescription p ON s.s_Id = p.s_Id
                     Where s.s_Id=@id
                 ";
             var lstAll = connection.Query<Student_Prescription_DTO, Prescription, Student_Prescription_DTO>(query, (s, p) =>
             {

                 s.listPrescription = s.listPrescription ?? new List<Prescription> { p };
                 if (p != null)
                     s.listPrescription.Add(p);
                 return s;
             },
             new { id = id },
             splitOn: "p_Id"


             ).GroupBy(s => s.s_Id)
 .Select(group => group.First()).ToList();


             foreach ( var p in lstAll)
             {

             }

             return response;*/

            /*
                        if (lstTodos.Count > 0)
                        {
                            response.StatusCode = 200;
                            response.StatusMessage = "Data found";
                            response.listTodo = lstTodos;
                        }
                        else
                        {
                            response.StatusCode = 100;
                            response.StatusMessage = "No Data found";
                            response.listTodo = null;
                        }*/


        }
    }
}
