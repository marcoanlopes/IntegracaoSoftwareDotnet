namespace IntegracaoSoftwareDotnet.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string? Class { get; set; }
        public string? activeSpecName { get; set; }
        public string? activeSpecRole { get; set; }
        public string? faction  { get; set; }
        public string? region { get; set; }
        public int itemLevelEquipped { get; set; }
    }
}
