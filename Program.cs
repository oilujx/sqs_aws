using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Newtonsoft.Json;
using sqs_aws;
using static sqs_aws._envio;

RegionEndpoint ServiceRegion = RegionEndpoint.USEast2;
//string QueueName = "colaArqui";
IAmazonSQS client;

client = new AmazonSQSClient(ServiceRegion);

//aqui se crea la cola
//string queueUrl = await CreateQueue(client, QueueName);

//esta es la url de una cola existente
string queueUrl = "https://sqs.us-east-2.amazonaws.com/654654329634/micola";

for (int i = 0; i < 10; i++)
{
    responseInfo respuesta = new responseInfo();

    respuesta.Identificador = i;
    respuesta.Info = $"informacion obtenida {i}";

    string messageBody = JsonConvert.SerializeObject(respuesta);

    var sendMsgResponse = await SendMessage(client, queueUrl, messageBody);
}

Console.ReadKey();



