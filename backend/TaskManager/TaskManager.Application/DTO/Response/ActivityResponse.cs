namespace TaskManager.Application.DTO.Response
{
    public record ActivityResponse(


        int Id,
        string Title,
        int ProjectId,
        int UserId,
        string Description,
        string Priority,
        string Status,
        string ProjectName,
        string UserName,


        DateTimeOffset CreatedAt,
        DateTimeOffset? UpdatedAt,
        DateTimeOffset? CompletionDate
    );
}
