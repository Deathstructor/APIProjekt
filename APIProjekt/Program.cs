using RestSharp;
using System.Text.Json;
using System.Net;



// Console.WriteLine("Welcome to this easy version of Jeopardy!");
// Thread.Sleep(3000);
// Console.WriteLine();
// Console.WriteLine();
// Console.WriteLine("You will get the answer to a question, and your goal is to");
// Console.WriteLine("find the correct question to the answer.");
// Console.WriteLine();
// Thread.Sleep(4000);
// Console.WriteLine("In this version of Jeopardy, you will get 3 possible questions");
// Console.WriteLine("to choose from, and one of them is correct.");
// Console.WriteLine();
// Thread.Sleep(5000);
// Console.WriteLine("Ready?");
// Console.WriteLine();
// Thread.Sleep(3000);
// Console.WriteLine("Here is your first question:");
// Thread.Sleep(2000);
// Console.Clear();

RestClient jeopardyClient = new("https://jservice.io");

List<string> questionOrder = new List<string>();

for (int i = 0; i < 3; i++)
{
    RestRequest request = new("/api/random");
    RestResponse response = jeopardyClient.GetAsync(request).Result;

    if (response.StatusCode == HttpStatusCode.OK)
    {
        Jeopardy j = JsonSerializer.Deserialize<List<Jeopardy>>(response.Content).First();

        if (i == 0)
        {
            Console.WriteLine(j.answer);
            Console.WriteLine("Correct: " + j.question);
            Console.WriteLine();
        }
        questionOrder.Add(j.question);

        // Console.WriteLine($"{i+1}) {j.question}");
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Error: Could not fetch the information from the API");
    }
}

Random rdm = new Random();

// questionOrder.OrderBy(x => rdm.Next());

int n = questionOrder.Count;
while (n > 1)
{
    n--;
    int k = rdm.Next(n + 1);
    String value = questionOrder[k];
    questionOrder[k] = questionOrder[n];
    questionOrder[n] = value;
}

Console.WriteLine("1) " + questionOrder[0]);
Console.WriteLine("2) " + questionOrder[1]);
Console.WriteLine("3) " + questionOrder[2]);



Console.ReadLine();
