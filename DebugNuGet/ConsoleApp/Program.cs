// See https://aka.ms/new-console-template for more information

using MyLibrary;
using Newtonsoft.Json;

//var helloWorld = "Hello, World!".ToRandomCase();
//Console.WriteLine(helloWorld);
//Console.WriteLine(GetMyIpAddress().GetAwaiter().GetResult());

var p = new Poco("property1", "property2");
var serialized = JsonConvert.SerializeObject(p);
Console.WriteLine(serialized);



async Task<string> GetMyIpAddress()
{
    var httpClient = new HttpClient();
    var response = await httpClient.GetAsync("https://api.ipify.org?format=json");

    var stringResponse = await response.Content.ReadAsStringAsync();

    return stringResponse;
}

record Poco(string Property1, string Property2);