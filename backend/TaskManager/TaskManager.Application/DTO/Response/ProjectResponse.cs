namespace TaskManager.Application.DTO.Response
{
    public record ProjectResponse(
                int Id,
                string Name,
                string Status,
                string Description,
                int TotalTarefas
                );
}
