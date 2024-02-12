namespace Backend.Database.Models 
{
    public class CompanyUser
    {
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        public Company Company { get; set; }
        public User User { get; set; }
    }
}