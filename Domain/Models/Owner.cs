namespace Domain.Models
{
    public class Owner 
    { 
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime? DateOfBirth { get; set; }

        public string? Address { get; set; }

    }
}
