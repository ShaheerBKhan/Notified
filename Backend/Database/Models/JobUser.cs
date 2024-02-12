namespace Backend.Database.Models 
{
    public class JobUser
    {
        public Guid JobId { get; set; }
        public Guid UserId { get; set; }
        public Job Job { get; set; }
        public User User { get; set; }
    }
}