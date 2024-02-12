namespace Backend.Database.Models 
{
    public class CompanyJob
    {
        public Guid CompanyId { get; set; }
        public Guid JobId { get; set; }
        public Company Company { get; set; }
        public Job Job { get; set; }
    }
}