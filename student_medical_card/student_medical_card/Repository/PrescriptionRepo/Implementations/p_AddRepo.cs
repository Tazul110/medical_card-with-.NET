using student_medical_card.Models.Responses;
using student_medical_card.Models;
using student_medical_card.Repository.PrescriptionRepo.Interfaces;
using Microsoft.Data.SqlClient;
using Azure;
using Dapper;

namespace student_medical_card.Repository.PrescriptionRepo.Implementations
{
    public class p_AddRepo : p_IAddRepo
    {
        public p_Response AddPrescription(SqlConnection connection, Prescription prescription)
        {
            p_Response p_response = new p_Response();

            //int i = connection.Execute("INSERT INTO medical_card (p_Id, s_Id, health_condition, prescribeBy,prescribe_date_time) VALUES (@p_Id, @s_Id, @health_condition, @prescribeBy, GETDATE())", prescription);
            int i = connection.Execute("INSERT INTO prescription (p_Id, s_Id, health_condition, prescribeBy, prescribe_date_time) VALUES (@p_Id, @s_Id, @health_condition, @prescribeBy, GETDATE())", prescription);

            if (i > 0)
            {

                p_response.StatusCode = 200;
                p_response.StatusMessage = "Prescription added.";
                p_response.Prescription = prescription;

            }
            else
            {
                p_response.StatusCode = 100;
                p_response.StatusMessage = "No Data inserted";


            }
            return p_response;
        }
    }
}
