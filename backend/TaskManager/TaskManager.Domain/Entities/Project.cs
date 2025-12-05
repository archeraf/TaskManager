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
        public DateTime? CompletionDate { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public virtual ICollection<Activity> Activities { get; private set; }

        #region Methods
        public void Update(string name, string description, StatusEnum status)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));
            }

            if (!Enum.IsDefined(typeof(Enum), status))
            {
                throw new ArgumentException("Invalid status value.", nameof(status));
            }

            if (status == StatusEnum.InProgress && this.StartedAt == null)
            {
                this.StartedAt = DateTime.UtcNow;
            }

            this.Title = name;
            this.Description = description;
            this.Status = status;
            this.UpdatedAt = DateTime.UtcNow;
        }

        public void MarkAsFinished()
        {
            if (this.Status == StatusEnum.Done)
            {
                throw new InvalidOperationException("This project is already done.");
            }
            else if (this.Status == StatusEnum.Cancelled)
            {
                throw new InvalidOperationException("A cancelled project cannot be marked as done.");
            }


            this.Status = StatusEnum.Done;
            this.CompletionDate = DateTime.UtcNow;
            this.UpdatedAt = DateTime.UtcNow;
        }

        public void Start()
        {
            if (this.Status == StatusEnum.InProgress)
            {
                throw new InvalidOperationException("This project is already in progress.");
            }
            else if (this.Status == StatusEnum.Done)
            {
                throw new InvalidOperationException("A done project cannot be started again.");
            }
            else if (this.Status == StatusEnum.Cancelled)
            {
                throw new InvalidOperationException("A cancelled project cannot be started.");
            }

            this.Status = StatusEnum.InProgress;
            this.StartedAt = DateTime.UtcNow;
            this.UpdatedAt = DateTime.UtcNow;
        }

        public void Cancel()
        {
            if (this.Status == StatusEnum.Cancelled)
            {
                throw new InvalidOperationException("This project is already cancelled.");
            }
            else if (this.Status == StatusEnum.Done)
            {
                throw new InvalidOperationException("A done project cannot be cancelled.");
            }

            this.Status = StatusEnum.Cancelled;
            this.UpdatedAt = DateTime.UtcNow;
        }


        #endregion

    }
}
