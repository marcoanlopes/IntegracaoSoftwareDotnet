using IntegacaoSoftwareDotnet.Interfaces;
using IntegacaoSoftwareDotnet.Models;
using IntegracaoSoftwareDotnet.Controllers;
using IntegracaoSoftwareDotnet.Models;

namespace IntegacaoSoftwareDotnet.Services
{
    public class PartyService : IPartyService
    {
        private readonly IPartyRepository _partyRepository;
        private readonly ICharacterRepository _characterRepository;

        private readonly int tankMaxCount = 1;
        private readonly int healerMaxCount = 1;
        private readonly int dpsMaxCount = 3;

        public PartyService(IPartyRepository partyRepository, ICharacterRepository characterRepository)
        {
            _partyRepository = partyRepository;
            _characterRepository = characterRepository;
        }

        public Party CreatePartyWithMaxGear(string partyName)
        {
            List<Character> charactersAvailableList = new List<Character>();
            charactersAvailableList = _characterRepository.GetAvailableCharacters();
            Party party = new Party();
            party.Characters = new List<Character>();
            party.Name = partyName;
            party.Characters.AddRange(charactersAvailableList.Where(w => w.activeSpecRole == "HEALING").OrderByDescending(o => o.itemLevelEquipped).Take(1).ToList());
            party.Characters.AddRange(charactersAvailableList.Where(w => w.activeSpecRole == "TANK").OrderByDescending(o => o.itemLevelEquipped).Take(1).ToList());
            party.Characters.AddRange(charactersAvailableList.Where(w => w.activeSpecRole == "DPS").OrderByDescending(o => o.itemLevelEquipped).Take(3).ToList());

            if (PartyValidator(party))
            {
                foreach(Character character in party.Characters)
                {
                    character.Available = false;
                }
                return _partyRepository.CreateParty(party);
            }

            return null;
        }

        public bool DeleteParty(int id)
        {
            var party = _partyRepository.GetPartyById(id);
            if (party == null)
            {
                return false;
            }

            foreach (var character in party.Characters)
            {
                character.Available = true;
            }

            _partyRepository.DeleteParty(party);
            return true;
        }
        public bool UpdateParty(int id, string partyName)
        {
            var oldParty = GetPartyById(id);
            if (oldParty == null)
            {
                return false;
            }
            oldParty.Name = partyName;            
            _partyRepository.UpdateParty(id, oldParty);
            return true;
        }

        public IEnumerable<Party> GetParties()
        {
            return _partyRepository.GetParties();
        }

        public Party GetPartyById(int id)
        {
            var party = _partyRepository.GetPartyById(id);
            if(party == null)
            {
                return party;
            }
            return party;
        }

        private bool PartyValidator(Party party)
        {
            var tankCount = party.Characters.Where(w => w.activeSpecRole == "TANK").Count();
            var healerCount = party.Characters.Where(w => w.activeSpecRole == "HEALING").Count();
            var dpsCount = party.Characters.Where(w => w.activeSpecRole == "DPS").Count();

            if (tankCount > tankMaxCount || healerCount > healerMaxCount || dpsCount > dpsMaxCount || party.Characters.Count() > 5 || party.Characters.Count() < 5)
            {
                return false;
            }

            return true;
        }
    }
}
