using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EcomerceStore_Razor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is Required")]
        [MaxLength(50)]
        [DisplayName(" Category Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category Name is Required")]
        [DisplayName("Display Order")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }
    }
}
