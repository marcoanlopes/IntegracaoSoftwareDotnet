using IntegracaoSoftwareDotnet.Controllers;
using IntegracaoSoftwareDotnet.Models;

namespace IntegacaoSoftwareDotnet.Interfaces
{
    public interface IPartyService
    {
        IEnumerable<Party> GetParties();
        Party GetPartyById(int id);
        Party CreateParty(Party Party);
        Party UpdateParty(int id, Party party);
        string DeleteParty(int id);
        Party CreatePartyWithMaxGear(List<Character> characters, string partyName);
    }
}
