namespace TaskManager.Domain.Entities
{
    internal class Assignment
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public DateTime AssignedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
    }
}
