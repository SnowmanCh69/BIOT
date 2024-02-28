namespace BIO.Models
{
    public class GeneticTest
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
       
        // Relación con el paciente
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        // Relación con el realizador de la prueba
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
