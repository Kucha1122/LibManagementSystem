namespace LibManagementSystem.Infrastructure.DTO
{
    public class CreateIssueDto
    {
        public int BookId { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Phone { get; set; } 
        public int Days { get; set; }
    }
}