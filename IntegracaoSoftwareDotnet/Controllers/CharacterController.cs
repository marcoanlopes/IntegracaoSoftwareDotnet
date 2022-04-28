using IntegracaoSoftwareDotnet.Interfaces;
using IntegracaoSoftwareDotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace IntegracaoSoftwareDotnet.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpPost("create-character")]
        public IActionResult CreateCharacter(Character character)
        {
            var newCharacter = _characterService.CreateCharacter(character);
            return Ok(newCharacter);
        }

        [HttpGet("get-all-characters")]
        public IActionResult GetAllCharacters()
        {
            var characters = _characterService.GetAll();
            return Ok(characters);
        }

        [HttpGet("get-character/{id}")]
        public IActionResult GetCharacterById(int id)
        {
            var character = _characterService.GetById(id);
            return Ok(character);
        }

        [HttpDelete("delete-character/{id}")]
        public IActionResult DeleteCharacter(int id)
        {
            _characterService.DeleteCharacter(id);
            return Ok(new { message = "Personagem deletado com sucesso." });
        }
    }
}