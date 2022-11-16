using RestSharp;
using System.Text.Json;
using System.Net;

RestClient jeopardyClient = new("https://jservice.io");
RestRequest request = new("/api/random");
RestResponse response = jeopardyClient.GetAsync(request).Result;


if (response.StatusCode == HttpStatusCode.OK)
{
    Jeopardy j = JsonSerializer.Deserialize<List<Jeopardy>>(response.Content).First();

    Console.WriteLine(j.id);
    Console.WriteLine(j.question);
    Console.WriteLine(j.answer);
}
else
{
    Console.WriteLine("Error: The question does not exist");
}



Console.ReadLine();
