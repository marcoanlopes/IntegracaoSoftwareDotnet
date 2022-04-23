using IntegracaoSoftwareDotnet.Models;
using System.ComponentModel.DataAnnotations;

namespace IntegracaoSoftwareDotnet.Controllers
{
    public class Party
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Character> Characters { get; set; }
    }
}
