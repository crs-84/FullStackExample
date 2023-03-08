namespace WebApplication1.Models
{
    public class User
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
