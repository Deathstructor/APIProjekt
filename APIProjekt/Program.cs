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
Console.WriteLine("to choose from, and one of them is correct. To answer, simply");
Console.WriteLine("press the same number on the keyboard as the number in front of");
Console.WriteLine("the question.");
Console.WriteLine();
Thread.Sleep(6000);
Console.WriteLine("Ready?");
Console.WriteLine();
Thread.Sleep(3000);
Console.WriteLine("Here is your first question:");
Thread.Sleep(2000);
Console.Clear();

RestClient jeopardyClient = new("https://jservice.io");

// Skapar en lista där de tre frågorna läggs in
List<string> questionOrder = new List<string>();
string correctAnswer = "";

// For loop som gör 3 requests på "random" som slumpar fram en fråga, så jag får 3 frågor.
for (int i = 0; i < 3; i++)
{

    RestRequest request = new("/api/random");
    RestResponse response = jeopardyClient.GetAsync(request).Result;

    if (response.StatusCode == HttpStatusCode.OK)
    {
        // Svaret från API:n deserialiseras till Jeopardy klassen
        Jeopardy j = JsonSerializer.Deserialize<List<Jeopardy>>(response.Content).First();

        // Kollar så att svaret endast skrivs ut en gång
        if (i == 0)
        {
            Console.WriteLine(j.answer);
            Console.WriteLine();
            correctAnswer = j.question;
        }
        questionOrder.Add(j.question);
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Error: Could not fetch the information from the API");
    }
}



// Denna kod fick jag från StackOverflow och slumpar helt enkelt ordningen på allt i listan (https://stackoverflow.com/questions/273313/randomize-a-listt)
Random rdm = new Random();
int n = questionOrder.Count;
while (n > 1)
{
    n--;
    int k = rdm.Next(n + 1);
    string value = questionOrder[k];
    questionOrder[k] = questionOrder[n];
    questionOrder[n] = value;
}


Console.WriteLine("1) " + questionOrder[0]);
Console.WriteLine("2) " + questionOrder[1]);
Console.WriteLine("3) " + questionOrder[2]);
Console.WriteLine();

// Kollar vilken knapp man trycker på och kollar om man har valt rätt svar
ConsoleKey key = Console.ReadKey().Key;
if (key == ConsoleKey.D1 && questionOrder[0] == correctAnswer)
{
    Console.WriteLine();
    Console.WriteLine("Correct answer!");
} else if (key == ConsoleKey.D1 && questionOrder[0] != correctAnswer)
{
    Console.WriteLine();
    Console.WriteLine("Wrong answer");
    Console.WriteLine($"The correct answer is: {correctAnswer}");
}
if (key == ConsoleKey.D2 && questionOrder[1] == correctAnswer)
{
    Console.WriteLine();
    Console.WriteLine("Correct answer!");
}
else if (key == ConsoleKey.D2 && questionOrder[1] != correctAnswer)
{
    Console.WriteLine();
    Console.WriteLine("Wrong answer");
    Console.WriteLine($"The correct answer is: {correctAnswer}");
}
if (key == ConsoleKey.D3 && questionOrder[2] == correctAnswer)
{
    Console.WriteLine();
    Console.WriteLine("Correct answer!");
}
else if (key == ConsoleKey.D3 && questionOrder[2] != correctAnswer)
{
    Console.WriteLine();
    Console.WriteLine("Wrong answer");
    Console.WriteLine($"The correct answer is: {correctAnswer}");
}

Console.ReadLine();
