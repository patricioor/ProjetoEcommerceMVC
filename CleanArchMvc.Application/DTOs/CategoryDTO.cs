using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Nam is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
