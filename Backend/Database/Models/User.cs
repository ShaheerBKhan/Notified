namespace Backend.Database.Models 
{
    public class User
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int YearsOfExperience { get; set; }
        public string Education { get; set; }
        public string LocationPreference { get; set; }
        public bool IsRemotePreference { get; set; }
        public decimal SalaryPreference { get; set; }
    }
}