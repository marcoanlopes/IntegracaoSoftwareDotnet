using IntegacaoSoftwareDotnet.Interfaces;
using IntegracaoSoftwareDotnet.Context;
using IntegracaoSoftwareDotnet.Models;

namespace IntegacaoSoftwareDotnet.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly DatabaseContext _context;

        public CharacterRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void UpdateCharacter(Character character)
        {
            _context.Characters.Update(character);
            _context.SaveChanges();
        }

        List<Character> ICharacterRepository.GetAvailableCharacters()
        {
            return _context.Characters.Where(w => w.Available.Equals(true)).ToList();
        }

        Character ICharacterRepository.GetById(int id)
        {
            return _context.Characters.Find(id);
        }
    }
}
