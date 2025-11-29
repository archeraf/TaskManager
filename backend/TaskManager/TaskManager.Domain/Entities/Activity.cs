using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities
{
    public class Activity
    {
        public int Id { get; private set; }
        public int ProjectId { get; private set; }
        public Project Project { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? CompletionDate { get; private set; }
        public StatusEnum Status { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public ActivityPriorityEnum Priority { get; set; }

        public Activity(string title, string description, ActivityPriorityEnum priority, int projectId, int userId)
        {

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            }

            if (projectId <= 0)
            {
                throw new ArgumentException("Invalid Project ID");
            }

            this.Title = title;
            this.Description = description;
            this.Priority = priority;
            this.UserId = userId;
        }

        #region Methods
        public void Add(Activity activity)
        {
            if (activity == null)
            {
                throw new ArgumentNullException(nameof(activity), "Activity cannot be null.");
            }
            this.ProjectId = activity.ProjectId;
            this.CreatedAt = DateTime.UtcNow;
            this.Status = StatusEnum.Pending;
        }

        public void Start()
        {
            if (this.Status == StatusEnum.Cancelled)
            {
                throw new InvalidOperationException("Activity already canceled.");
            }

            if (this.Status == StatusEnum.Done)
            {
                return;
            }



            this.Status = StatusEnum.InProgress;
        }

        public void MarkAsFinished()
        {
            if (this.Status == StatusEnum.Done)
            {
                throw new InvalidOperationException("This activity is already done.");
            }
            else if (this.Status == StatusEnum.Cancelled)
            {
                throw new InvalidOperationException("A cancelled activity cannot be marked as done.");
            }
            this.Status = StatusEnum.Done;
            this.CompletionDate = DateTime.UtcNow;

        }

        public void Cancel()
        {
            if (this.Status == StatusEnum.Done)
            {
                throw new InvalidOperationException("A completed activity cannot be cancelled.");
            }
            this.Status = StatusEnum.Cancelled;
            this.CompletionDate = null;
        }

        public void Update(string title, string description, ActivityPriorityEnum priority)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                this.Title = title;
            }

            if (!string.IsNullOrWhiteSpace(description))
            {
                this.Description = description;
            }
            if (priority != 0 && priority != this.Priority)
            {
                this.Priority = priority;
            }
        }

        #endregion
    }

}
