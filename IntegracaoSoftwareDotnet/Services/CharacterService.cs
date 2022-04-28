using IntegacaoSoftwareDotnet.Interfaces;
using IntegracaoSoftwareDotnet.Interfaces;
using IntegracaoSoftwareDotnet.Models;

namespace IntegracaoSoftwareDotnet.Services
{
    public class CharacterService : ICharacterService
    {

        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }
        public Character CreateCharacter(Character character)
        {
            character.Available = true;
            return _characterRepository.CreateCharacter(character);
        }

        public void DeleteCharacter(int id)
        {
            _characterRepository.DeleteCharacter(id);
        }

        public IEnumerable<Character> GetAll()
        {
            return _characterRepository.GetAll();
        }

        public Character GetById(int id)
        {
            return _characterRepository.GetById(id);
        }
    }
}