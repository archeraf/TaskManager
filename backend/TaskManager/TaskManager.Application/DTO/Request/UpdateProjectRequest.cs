namespace TaskManager.Application.DTO.Request
{
    public record UpdateProjectRequest(
                int Id,
                string Title,
                string Description,
                string Status,
                int UserId,
                IEnumerable<int> Activities
                );
}
