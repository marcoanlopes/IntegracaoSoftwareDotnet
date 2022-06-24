using IntegacaoSoftwareDotnet.Interfaces;
using IntegacaoSoftwareDotnet.Models;
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

        [HttpGet("parties")]
        public IActionResult GetParties()
        {
            var parties = _partyService.GetParties();
            return Ok(parties);
        }

        [HttpGet("get-party/{id}")]
        public IActionResult GetPartyById(int id)
        {
            var party = _partyService.GetPartyById(id);
            if (party == null)
            {
                return BadRequest(new { message = "Grupo não encontrado!" });
            }
            return Ok(party);
        }

        [HttpDelete("delete-party/{id}")]
        public IActionResult DeleteParty(int id)
        {
            var deletedParty = _partyService.DeleteParty(id);
            if (!deletedParty)
            {
                return BadRequest(new { message = "Grupo não encontrado!" });
            }
            return Ok(new { message = "Grupo deletado com sucesso. Todos os jogadores voltaram para a fila." });
        }
        [HttpPut("update-party/{id}/{partyName}")]
        public IActionResult UpdateParty(int id, string partyName)
        {
            var updatedParty = _partyService.UpdateParty(id, partyName);
            if (!updatedParty)
            {
                return BadRequest(new { message = "Grupo não encontrado!" });
            }
            return Ok(new { message = "Grupo atualizado com sucesso." });
        }

        [HttpPost("create-party-max-gear")]
        public IActionResult CreatePartyWithMaxGear(string partyName)
        {
            var newParty = _partyService.CreatePartyWithMaxGear(partyName);
            if(newParty == null)
            {
                return BadRequest(new { message = "Todos os grupos possiveis já foram formados! Aguarde mais jogadores." });
            }
            return Ok(newParty);
        }


    }
}
