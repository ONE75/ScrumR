using System.ComponentModel.DataAnnotations;

namespace ScrumR.Web.Models
{
    public class CreateBacklogItemModel
    {
        [Required]
        [Display(Description = "Typically in the format 'As a user of ScrumR I want to do something'")]
        public string Story { get; set; }

        [Required]
        [Display (Name = "Story points", Description = "Enter the estimated story points here")]
        public int StoryPoints { get; set; }

        public string Summary { get; set; }
    }
}