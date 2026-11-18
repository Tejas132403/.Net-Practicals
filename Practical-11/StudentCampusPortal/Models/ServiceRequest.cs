using System;
using System.ComponentModel.DataAnnotations;

namespace StudentCampusPortal.Models
{
    public class ServiceRequest
    {
        public int RequestId { get; set; }

        [Required(ErrorMessage = "Student Name is required")]
        [Display(Name = "Student Name")]
        [StringLength(100)]
        public string StudentName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department is required")]
        [StringLength(100)]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Service Type is required")]
        [Display(Name = "Service Type")]
        [StringLength(100)]
        public string ServiceType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Priority is required")]
        [StringLength(50)]
        public string Priority { get; set; } = "Medium";

        [StringLength(50)]
        public string Status { get; set; } = "Pending";

        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}
