using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegracaoSoftwareDotnet.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string? Class { get; set; }
        public string? activeSpecName { get; set; }
        public string? activeSpecRole { get; set; }
        public string? faction  { get; set; }
        public string? region { get; set; }
        public int itemLevelEquipped { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }
        [ForeignKey("Party")]
        public int? GroupId { get; set; }
        public Party? Party { get; set; }
    }
}
