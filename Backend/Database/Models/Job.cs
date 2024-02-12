namespace Backend.Database.Models 
{
    public class Job
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Title { get; set; }
        public string ApplicationUrl { get; set; }
        public string MinimumEducation { get; set; }
        public int MinimumYearsOfExperience { get; set; }
        public string PreferredEducation { get; set; }
        public int PreferredYearsOfExperience { get; set; }
        public string Location { get; set; }
        public bool IsRemote { get; set; }
        public decimal Salary { get; set; }

        public Company Company { get; set; } 
    }
}