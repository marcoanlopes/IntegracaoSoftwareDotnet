using IntegacaoSoftwareDotnet.Interfaces;
using IntegracaoSoftwareDotnet.Context;
using IntegracaoSoftwareDotnet.Controllers;
using IntegracaoSoftwareDotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegacaoSoftwareDotnet.Repository
{
    public class PartyRepository : IPartyRepository
    {
        private readonly DatabaseContext _context;

        public PartyRepository(DatabaseContext context)
        {
            _context = context;
        }
        public Party CreateParty(Party party)
        {            
            _context.Add(party);
            _context.SaveChanges();
            return party;   
        }

        public void DeleteParty(Party party)
        {
            _context.Party.Remove(party);
            _context.SaveChanges();
        }

        public IEnumerable<Party> GetParties()
        {
            return _context.Party.Include(i => i.Characters).ToList();
        }

        public Party GetPartyById(int id)
        {
            return _context.Party.Where(w => w.Id == id).Include(i => i.Characters).FirstOrDefault();
        }

        public Party UpdateParty(int id, Party party)
        {            
            _context.Update(party);
            _context.SaveChanges();
            return party;
        }
    }
}
