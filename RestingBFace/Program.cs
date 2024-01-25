using RestSharp;
using System.Text.Json;
using System.IO;
using System.Drawing;


RestClient client = new RestClient("https://digi-api.com/api/v1/");

int randID;
Digimon digimon;

List<Digimon> digi = new();

while (digi.Count < 10)
{
    Console.ForegroundColor = ConsoleColor.White;
    randID = newID();
    RestRequest request = new RestRequest("digimon/" + randID.ToString());
    RestResponse response = client.GetAsync(request).Result;
    digimon = JsonSerializer.Deserialize<Digimon>(response.Content);
    digi.Add(digimon);
    Console.Clear();
    System.Console.WriteLine("Press ENTER for a random digimon");

    Console.ReadLine();
    foreach (var d in digi)
    {
        System.Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        System.Console.WriteLine("Name: " + d.Name);
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("ID: " + d.Id);
        Console.ForegroundColor = ConsoleColor.White;
        System.Console.WriteLine();

    }
    System.Console.WriteLine($"You have {10 - digi.Count} digimons to gather left");
    Console.ReadLine();

}
System.Console.ReadLine();




int newID()
{
    return Random.Shared.Next(0, 1000);
}