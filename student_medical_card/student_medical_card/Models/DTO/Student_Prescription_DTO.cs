﻿namespace student_medical_card.Models.DTO
{
    public class Student_Prescription_DTO
    {
        public string s_Id { get; set; }
        public string s_Name { get; set; }
        public string s_Dept { get; set; }
        public string s_Gender { get; set; }
        public string s_Email { get; set; }
        public DateTime b_Date { get; set; }

       public List<Prescription>? listPrescription { get; set; }



    }
}
