using IntegracaoSoftwareDotnet.Models;

namespace IntegacaoSoftwareDotnet.Interfaces
{
    public interface IPartyRepository
    {
        Party CreateParty(Party party);
        Party UpdateParty(int id, Party party);
        void DeleteParty(Party party);
        IEnumerable<Party> GetParties();
        Party GetPartyById(int id);
    }
}
