using RestSharp;
using System.Text.Json;
using System.Net;



Console.WriteLine("Welcome to this easy version of Jeopardy!");
Thread.Sleep(3000);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("You will get the answer to a question, and your goal is to");
Console.WriteLine("find the correct question to the answer.");
Console.WriteLine();
Thread.Sleep(4000);
Console.WriteLine("In this version of Jeopardy, you will get 3 possible questions");
Console.WriteLine("to choose from, and one of them is correct.");
Console.WriteLine();
Thread.Sleep(5000);
Console.WriteLine("Ready?");
Console.WriteLine();
Thread.Sleep(3000);
Console.WriteLine("Here is your first question:");
Thread.Sleep(2000);
Console.Clear();


Random rdm = new Random();

RestClient jeopardyClient = new("https://jservice.io");

for (int i = 0; i < 3; i++)
{
    RestRequest request = new("/api/random");
    RestResponse response = jeopardyClient.GetAsync(request).Result;
    
    if (response.StatusCode == HttpStatusCode.OK)
    {
        Jeopardy j = JsonSerializer.Deserialize<List<Jeopardy>>(response.Content).First();

        if (i == 0)
        {
            rdm.Next(3) = ;
            Console.WriteLine(j.answer);
            Console.WriteLine();
        }
        Console.WriteLine($"{i+1}) {j.question}");
    }
    else
    {
        Console.WriteLine("Error: Could not fetch the information from the API");
    }
}



Console.ReadLine();
