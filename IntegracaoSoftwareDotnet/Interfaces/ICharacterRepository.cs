using IntegracaoSoftwareDotnet.Models;

namespace IntegacaoSoftwareDotnet.Interfaces
{
    public interface ICharacterRepository
    {
        List<Character> GetAvailableCharacters();
        Character GetById(int id);
        void UpdateCharacter(Character character);
    }
}
