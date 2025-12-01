namespace TaskManager.Application.DTO.Request
{
    public record UpdateProjectRequest(
                int Id,
                string Name,
                string Description,
                string Status,
                int UserId,
                IEnumerable<int> Activities
                );
}
