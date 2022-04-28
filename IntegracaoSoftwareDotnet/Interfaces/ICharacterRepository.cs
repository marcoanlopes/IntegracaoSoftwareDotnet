using IntegracaoSoftwareDotnet.Models;

namespace IntegacaoSoftwareDotnet.Interfaces
{
    public interface ICharacterRepository
    {

        IEnumerable<Character> GetAll();
        Character CreateCharacter(Character character);
        Character DeleteCharacter(int id);
        List<Character> GetAvailableCharacters();
        Character GetById(int id);
        void UpdateCharacter(Character character);
    }
}
