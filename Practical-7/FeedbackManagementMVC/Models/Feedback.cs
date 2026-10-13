using System.ComponentModel.DataAnnotations;

namespace FeedbackManagementMVC.Models
{
    public class Feedback
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select a rating.")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "Comments are required.")]
        [StringLength(200,
            ErrorMessage = "Comments cannot exceed 200 characters.")]
        public string Comments { get; set; }
    }
}