using System.ComponentModel.DataAnnotations;

namespace API.PrevisaoDoTempo.Domain.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        // Id da cidade no serviço externo
        [Required]
        [MaxLength(30)]
        public string CustomCode { get; set; }

        [MaxLength(3)]
        public string Country { get; set; }
    }
}
