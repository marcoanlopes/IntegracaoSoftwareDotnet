using IntegacaoSoftwareDotnet.Controllers;
using IntegacaoSoftwareDotnet.Interfaces;
using IntegracaoSoftwareDotnet.Interfaces;
using IntegracaoSoftwareDotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System.Text;

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

        //[HttpPost("send")]
        //public void SendCharacter()
        //{
        //    var factory = new ConnectionFactory() { HostName = "localhost" };
        //    using (var connection = factory.CreateConnection())
        //    using (var channel = connection.CreateModel())
        //    {
        //        channel.QueueDeclare(queue: "hello",
        //                             durable: false,
        //                             exclusive: false,
        //                             autoDelete: false,
        //                             arguments: null);

        //        Character c = new Character
        //        {
        //            itemLevelEquipped = 1313,
        //            Available = true,
        //            Name = "Nome Personagem"
        //        };
        //        var character = JsonConvert.SerializeObject(c);
        //        var body = Encoding.UTF8.GetBytes(character);
        //        channel.BasicPublish(exchange: "",
        //                             routingKey: "hello",
        //                             basicProperties: null,
        //                             body: body);
        //        Console.WriteLine(" [x] Sent {0}", character + "message sent <----");
        //    }
        //    //Console.WriteLine(" Press [enter] to exit.");
        //}


        //[HttpGet("consume")]
        //public void ConsumeCharacter()
        //{
        //    var factory = new ConnectionFactory() { HostName = "localhost" };
        //    using (var connection = factory.CreateConnection())
        //    using (var channel = connection.CreateModel())
        //    {
        //        channel.QueueDeclare(queue: "characterInfosQueue",
        //                             durable: true,
        //                             exclusive: false,
        //                             autoDelete: false,
        //                             arguments: null);
        //        var consumer = new EventingBasicConsumer(channel);
        //        consumer.Received += (model, ea) => 
        //        {
        //            var body = ea.Body.ToArray();
        //            var message = Encoding.UTF8.GetString(body);

        //            //var message = JsonConvert.DeserializeObject<Character>(Encoding.UTF8.GetString(body));
        //            Console.WriteLine(" [x] Received {0}", message);
        //            var payload = JsonConvert.DeserializeObject<ICharacterDTO>(message);
        //            var newCharacter = _characterService.CreateCharacter(payload.Data);
        //        };
        //        channel.BasicConsume(queue: "characterInfosQueue",
        //                                   autoAck: true,
        //                                   consumer: consumer);
        //        //Console.ReadLine();
        //        Thread.Sleep(5000);
        //    }
        //}
    }
}