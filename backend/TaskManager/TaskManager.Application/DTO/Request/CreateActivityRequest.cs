namespace TaskManager.Application.DTO.Request
{
    public record CreateActivityRequest(
    int ProjectId,
    int UserId,
    string Status,
    string Title,
    string Description,
    string Priority
     );
}
