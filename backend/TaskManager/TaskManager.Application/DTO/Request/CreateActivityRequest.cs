using TaskManager.Domain.Enums;

namespace TaskManager.Application.DTO.Request
{
    public record CreateActivityRequest(
    int ProjectId,
    int UserId,
    StatusEnum Status,
    string Title,
    string Description,
    ActivityPriorityEnum Priority
     );
}
