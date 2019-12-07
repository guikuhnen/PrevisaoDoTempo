using System.ComponentModel.DataAnnotations;

namespace API.PrevisaoDoTempo.WebAPI.DTOs
{
    public class CityDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O nome da cidade é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O nome da cidade deve possuir até 50 caracteres.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O código da cidade é obrigatório.")]
        [MaxLength(30, ErrorMessage = "O código da cidade deve possuir até 30 caracteres.")]
        public string CustomCode { get; set; }
        
        [MaxLength(3, ErrorMessage = "O código do país deve possuir até 3 caracteres.")]
        public string Country { get; set; }
    }
}
