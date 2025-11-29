namespace TaskManager.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public virtual ICollection<Project> Projects { get; private set; } = new List<Project>();
    }
}
