using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using WebAppTesteDev.Interceptions;
using WebAppTesteDev.Resources;

namespace WebAppTesteDev.Models
{
    public class ViewModelProduct
    {
        public int Id { get; set; }
        [MaxLength(200)]
        [Display(Name = "Label_Name", ResourceType = typeof(ResourceProduct))]
        [Required(ErrorMessageResourceType = typeof(ResourceProduct), ErrorMessageResourceName = "Required_Name")]
        public string Name { get; set; }

        private int intIdCategory;
        [Display(Name = "Label_Category", ResourceType = typeof(ResourceProduct))]
        [Required(ErrorMessageResourceType = typeof(ResourceProduct), ErrorMessageResourceName = "Required_Category")]
        public int IdCategory {
            get
            {
                return intIdCategory;
            }
            set
            {
                intIdCategory = value;
            }
        }

        [ScaffoldColumn(false)]
        public ViewModelCategory Category { get; set; }


        [Display(Name = "Label_Price", ResourceType = typeof(ResourceProduct))]
        [Required(ErrorMessageResourceType = typeof(ResourceProduct), ErrorMessageResourceName = "Required_Price")]
        public decimal Price { get; set; }

        [ScaffoldColumn(false)]
        //Base64
        public string Image { get; set; }

        [Display(Name = "Label_Description", ResourceType = typeof(ResourceProduct))]
        [Required(ErrorMessageResourceType = typeof(ResourceProduct), ErrorMessageResourceName = "Required_Description")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Display(Name = "Label_Image", ResourceType = typeof(ResourceProduct))]
        [Required(ErrorMessageResourceType = typeof(ResourceProduct), ErrorMessageResourceName = "Required_Image")]
        [ValidateFile(ErrorMessageResourceType = typeof(ResourceProduct), ErrorMessageResourceName = "ValidateFile_Image")]
        public HttpPostedFileBase UploadedFile { get; set; }

        public List<ViewModelCategory> CategoriesSelect { get; set; }
    }
}