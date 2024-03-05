using Microsoft.Data.SqlClient;
using student_medical_card.Models.DTO;

namespace student_medical_card.Service.StudentServ.Interfaces
{
    public interface s_IGetServ
    {
      Student_Prescription_DTO  sGetById(string s_Id);
    }
}
