using System.ComponentModel.DataAnnotations;

namespace QuizProject.Service.DTOs.Attachment
{
    public class AttachmentForCreateDtos
    {
        [Required]
        public string Path { get; set; }
    }
}
