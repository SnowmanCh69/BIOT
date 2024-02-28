namespace BIO.Models
{
    public class GeneticVariant
    {
        public int GeneticVariantID { get; set; }
        public string Type { get; set; }
        public string Genotype { get; set; }
        public string GenomeLocation { get; set; }
        public string PredictedEffect { get; set; }

        // Foreign key
        public int AnalysisId { get; set; }
        public Analysis Analysis { get; set; }

    }
}
