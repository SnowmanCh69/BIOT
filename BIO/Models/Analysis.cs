namespace BIO.Models
{
    public class Analysis
    {
        public int AnalysisID { get; set; }
        public string AnalysisType { get; set; }
        public DateTime AnalysisDate { get; set; }
        public string MethodUsed { get; set; }
        public string AnalysisResults { get; set; }

        // Navigation property
        public ICollection<GeneticVariant> GeneticVariants { get; set; }
    }
}
