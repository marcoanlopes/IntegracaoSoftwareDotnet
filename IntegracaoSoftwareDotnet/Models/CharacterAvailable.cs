namespace IntegacaoSoftwareDotnet.Models
{
    public class CharacterAvailable
    {
        public int Id { get; set; }
        public string? Class { get; set; }
        public string? activeSpecRole { get; set; }
        public int itemLevelEquipped { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }
    }
}
