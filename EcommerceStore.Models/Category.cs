using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EcommerceStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is Required")]
        [MaxLength(50)]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category Name is Required")]
        [DisplayName("Display Order")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }
    }
}
