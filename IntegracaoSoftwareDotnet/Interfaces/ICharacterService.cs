using IntegracaoSoftwareDotnet.Models;

namespace IntegracaoSoftwareDotnet.Interfaces
{
    public interface ICharacterService
    {
        IEnumerable<Character> GetAll();
        Character CreateCharacter(Character character);
        void DeleteCharacter(int id);
        Character GetById(int id);

    }
}


// Compare this snippet from Services\CharacterService.cs: