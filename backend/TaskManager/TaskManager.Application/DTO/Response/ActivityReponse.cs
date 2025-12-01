namespace TaskManager.Application.DTO.Response
{
    public record ActivityReponse(
        int Id,
        string Title,
        int ProjectId,
        int UserId,
        string Description,
        string Priority,
        string Status,

        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt,

        DateTimeOffset? CompletionDate = null,
        string? ProjectName = null,
        string? UserName = null
    );
}
