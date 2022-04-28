using IntegacaoSoftwareDotnet.Models;
using IntegracaoSoftwareDotnet.Controllers;
using IntegracaoSoftwareDotnet.Models;

namespace IntegacaoSoftwareDotnet.Interfaces
{
    public interface IPartyService
    {
        IEnumerable<Party> GetParties();
        Party GetPartyById(int id);
        bool DeleteParty(int id);
        Party CreatePartyWithMaxGear(string partyName);
    }
}
