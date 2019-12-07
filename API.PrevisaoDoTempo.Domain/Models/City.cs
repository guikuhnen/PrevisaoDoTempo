using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.PrevisaoDoTempo.Domain.Models
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        // Id da cidade no serviço externo
        public string CustomCode { get; set; }

        [MaxLength(3)]
        public string Country { get; set; }
    }
}
