namespace TaskManager.Application.DTO.Response
{
    public record ProjectResponse(
                int Id,
                string Title,
                string Status,
                string Description,
                int[] ActivitiesIds
                );
}
