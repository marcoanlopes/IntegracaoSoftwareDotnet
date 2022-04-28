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

        public Character CreateCharacter(Character character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();
            return character;
        }

        public Character DeleteCharacter(int id)
        {
            var character = _context.Characters.Find(id);
            if (character == null)
            {
                return null;
            }
            _context.Characters.Remove(character);
            _context.SaveChanges();
            return character;
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

        IEnumerable<Character> ICharacterRepository.GetAll()
        {
            return _context.Characters.ToList();
        }
    }
}
