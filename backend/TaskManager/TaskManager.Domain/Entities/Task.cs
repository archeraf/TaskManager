namespace TaskManager.Domain.Entities
{
    public class Task
    {
        public int Id { get; private set; }
        public int ProjectId { get; private set; }
        public Project Project { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public DateTime AssignedAt { get; private set; }
        public DateTime? RemovedAt { get; private set; }
    }
}
