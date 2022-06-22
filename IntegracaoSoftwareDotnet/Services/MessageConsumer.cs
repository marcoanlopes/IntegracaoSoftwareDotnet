using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IntegacaoSoftwareDotnet.Interfaces;
using IntegacaoSoftwareDotnet.Models;
using IntegracaoSoftwareDotnet.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace IntegacaoSoftwareDotnet.Services
{
    public class MessageConsumer : BackgroundService
    {
        
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string QUEUE = "characterInfosQueue";
        public MessageConsumer()
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: QUEUE,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                //var message = JsonConvert.DeserializeObject<Character>(Encoding.UTF8.GetString(body));
                Console.WriteLine(" [x] Received {0}", message);
                var payload = JsonConvert.DeserializeObject<ICharacterDTO>(message);
                Console.WriteLine(payload);

                var envio = JsonConvert.SerializeObject(payload.Data);
                var reqBody = new StringBuilder();
                reqBody.Append(envio);
           
                var data = new StringContent(envio, Encoding.UTF8, "application/json");
                var url = "http://localhost:5034/api/Character/create-character";
                using var client = new HttpClient();
                
                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
            };
            
            _channel.BasicConsume(queue: QUEUE,
                                autoAck: true,
                                consumer: consumer);
            return Task.CompletedTask;
        }        

    }
}


//var factory = new ConnectionFactory() { HostName = "localhost" };
//using (var connection = factory.CreateConnection())
//using (var channel = connection.CreateModel())
//{
//    channel.QueueDeclare(queue: "characterInfosQueue",
//                         durable: true,
//                         exclusive: false,
//                         autoDelete: false,
//                         arguments: null);
//    var consumer = new EventingBasicConsumer(channel);
//    consumer.Received += (model, ea) =>
//    {
//        var body = ea.Body.ToArray();
//        var message = Encoding.UTF8.GetString(body);

//        //var message = JsonConvert.DeserializeObject<Character>(Encoding.UTF8.GetString(body));
//        Console.WriteLine(" [x] Received {0}", message);
//        var payload = JsonConvert.DeserializeObject<ICharacterDTO>(message);
//        var newCharacter = _characterService.CreateCharacter(payload.Data);
//    };
//    channel.BasicConsume(queue: "characterInfosQueue",
//                               autoAck: true,
//                               consumer: consumer);
//    //Console.ReadLine();
//    Thread.Sleep(5000);