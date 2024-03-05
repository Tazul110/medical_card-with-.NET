using Azure;
using Microsoft.Data.SqlClient;
using student_medical_card.Models.DTO;

namespace student_medical_card.Repository.StudentRepo.Interfaces
{
    public interface s_IGetRepo
    {
        Student_Prescription_DTO GetById(string s_Id);
    }
}
