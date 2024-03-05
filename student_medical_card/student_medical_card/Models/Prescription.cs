namespace student_medical_card.Models
{
    public class Prescription
    {
        public string p_Id { get; set; }
        public string s_Id { get; set; } // Foreign key referencing Student table
        public string health_condition { get; set; }
        public string prescribeBy { get; set; }
        public DateTime prescribe_date_time { get; set; }


    }
}
