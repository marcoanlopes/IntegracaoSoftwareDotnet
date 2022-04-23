using IntegacaoSoftwareDotnet.Interfaces;
using IntegracaoSoftwareDotnet.Controllers;
using IntegracaoSoftwareDotnet.Models;

namespace IntegacaoSoftwareDotnet.Services
{
    public class PartyService : IPartyService
    {
        private readonly DataContext _context;

        private readonly int tankMaxCount = 1;
        private readonly int healerMaxCount = 1;
        private readonly int dpsMaxCount = 3;

        public PartyService(DataContext context)
        {
            _context = context;
        }

        public Party CreateParty(Party party)
        {
            if (PartyValidator(party))
            {
                return _context.CreateParty(party);
            }
            throw new BadHttpRequestException("Formação do grupo inválida!");
        }

        public Party CreatePartyWithMaxGear(List<Character> characters, string partyName)
        {
            Party party = new Party();
            party.Name = partyName;
            party.Characters.AddRange(characters.Where(w => w.activeSpecRole == "Healer").OrderByDescending(o => o.itemLevelEquipped).Take(1));
            party.Characters.AddRange(characters.Where(w => w.activeSpecRole == "Tank").OrderByDescending(o => o.itemLevelEquipped).Take(1));
            party.Characters.AddRange(characters.Where(w => w.activeSpecRole == "dps").OrderByDescending(o => o.itemLevelEquipped).Take(3));

            if (PartyValidator(party))
            {
                return _context.CreateParty(party);
            }

            throw new BadHttpRequestException("Ocorreu algum problema, tente novamente e verifique os dados enviados!");
        }

        public string DeleteParty(int id)
        {
            var party = _context.GetPartyById(id);
            if (party == null)
            {
                throw new BadHttpRequestException("Id do grupo é inválido ou não existe!");
            }
            return _context.DeleteParty(party);
        }

        public IEnumerable<Party> GetParties()
        {
            return _context.GetPartyAll();
        }

        public Party GetPartyById(int id)
        {
            var party = GetPartyById(id);
            if(party == null)
            {
                throw new BadHttpRequestException("Id do grupo é inválido ou não existe!");
            }
            return party;
        }

        public Party UpdateParty(int id, Party party)
        {
            var oldParty = _context.GetPartyById(id);
            if (oldParty != null && PartyValidator(party))
            {
                return _context.UpdateParty(id, party);
            }
            throw new BadHttpRequestException("Id do grupo é inválido ou não existe!");
            
        }

        private bool PartyValidator(Party party)
        {
            var tankCount = party.Characters.Where(w => w.activeSpecRole == "Tank").Count();
            var healerCount = party.Characters.Where(w => w.activeSpecRole == "Healer").Count();
            var dpsCount = party.Characters.Where(w => w.activeSpecRole == "DPS").Count();

            if (tankCount > tankMaxCount || healerCount > healerMaxCount || dpsCount > dpsMaxCount)
            {
                return false;
            }

            return true;
        }
    }
}
