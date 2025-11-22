using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities
{
    public class Project
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public StatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public virtual ICollection<Assignment> Assignments { get; private set; }

        #region Methods
        public void Update(string title, string description, StatusEnum status)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));
            }

            if (!Enum.IsDefined(typeof(Enum), status))
            {
                throw new ArgumentException("Invalid status value.", nameof(status));
            }

            if (status == StatusEnum.InProgress && StartedAt == null)
            {
                StartedAt = DateTime.UtcNow;
            }

            Title = title;
            Description = description;
            Status = status;
            UpdatedAt = DateTime.UtcNow;
        }

        public void MarkAsFinished()
        {
            if (Status == StatusEnum.Done)
            {
                throw new InvalidOperationException("This project is already done.");
            }
            else if (Status == StatusEnum.Cancelled)
            {
                throw new InvalidOperationException("A cancelled project cannot be marked as done.");
            }


            Status = StatusEnum.Done;
            FinishedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Start()
        {
            if (Status == StatusEnum.InProgress)
            {
                throw new InvalidOperationException("This project is already in progress.");
            }
            else if (Status == StatusEnum.Done)
            {
                throw new InvalidOperationException("A done project cannot be started again.");
            }
            else if (Status == StatusEnum.Cancelled)
            {
                throw new InvalidOperationException("A cancelled project cannot be started.");
            }

            Status = StatusEnum.InProgress;
            StartedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Cancel()
        {
            if (Status == StatusEnum.Cancelled)
            {
                throw new InvalidOperationException("This project is already cancelled.");
            }
            else if (Status == StatusEnum.Done)
            {
                throw new InvalidOperationException("A done project cannot be cancelled.");
            }

            Status = StatusEnum.Cancelled;
            UpdatedAt = DateTime.UtcNow;
        }


        #endregion

    }
}
