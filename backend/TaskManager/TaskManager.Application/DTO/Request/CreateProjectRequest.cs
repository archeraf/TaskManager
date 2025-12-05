using System.ComponentModel.DataAnnotations;

namespace TaskManager.Application.DTO.Request
{
    public record CreateProjectRequest
    (
        [Required(ErrorMessage = "Title is required.")]
        [MinLength(3, ErrorMessage = "Title length must be at least 3.")]
        [MaxLength(100, ErrorMessage = "Title length must be lower then 100")]
        string Title,

        [MaxLength(500, ErrorMessage = "Description must have less then 500 characters")]
         string Description

    );
}
