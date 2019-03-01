using System.ComponentModel.DataAnnotations;

namespace WebAppTesteDev.Models
{
    public class ViewModelCategory
    {
        public int Id { get; set; }
        [MaxLength(200)]
        [Required(ErrorMessageResourceType = typeof(Resources.ResourceCategory), ErrorMessageResourceName = "Required_Name")]
        [Display(Name = "Label_Name", ResourceType = typeof(Resources.ResourceCategory))]
        public string Name { get; set; }
        public int? IdParent { get; set; }

        [ScaffoldColumn(false)]
        public bool Selected { get; set; } = false;
    }
}