using IntegacaoSoftwareDotnet.Models;
using IntegracaoSoftwareDotnet.Models;
using System.ComponentModel.DataAnnotations;

namespace IntegracaoSoftwareDotnet.Models
{
    public class Party
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Character> Characters { get; set; }
    }
}
