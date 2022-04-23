using IntegacaoSoftwareDotnet.Interfaces;
using IntegracaoSoftwareDotnet.Controllers;
using IntegracaoSoftwareDotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntegacaoSoftwareDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly IPartyService _partyService;

        public PartyController(IPartyService partyService)
        {
            _partyService = partyService;
        }

        [HttpGet]
        [Route("parties")]
        public IActionResult GetParties()
        {
            var parties = _partyService.GetParties();
            return Ok(parties);
        }

        [HttpGet("{id}")]
        [Route("parties")]
        public IActionResult GetPartyById(int id)
        {
            var party = _partyService.GetPartyById(id);
            return Ok(party);
        }

        [HttpPost]
        [Route("create-party")]
        public IActionResult CreateParty(Party party)
        {
            var newParty = _partyService.CreateParty(party);
            return Ok(newParty);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateParty(int id, Party party)
        {
            var updatedParty = _partyService.UpdateParty(id, party);
            return Ok(updatedParty);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteParty(int id)
        {
            var deletedPartyName = _partyService.DeleteParty(id);
            return Ok(new { message = "Party + " + deletedPartyName + " deleted" });
        }

        [HttpPost]
        [Route("create-party-max-gear")]
        public IActionResult CreatePartyWithMaxGear(List<Character> characters, string partyName)
        {
            var newParty = _partyService.CreatePartyWithMaxGear(characters, partyName);
            return Ok(newParty);
        }


    }
}
