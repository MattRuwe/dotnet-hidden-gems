// See https://aka.ms/new-console-template for more information

using MyLibrary;
using Newtonsoft.Json;

var helloWorld = "Hello, World!";
helloWorld = helloWorld.ToRandomCase(); // Using the extension method from MyLibrary
Console.WriteLine(helloWorld);

// Demonstrates debugging into 3rd party libraries like Newtonsoft.Json
//var p = new Poco("property1", "property2");
//var serialized = JsonConvert.SerializeObject(p);
//Console.WriteLine(serialized);

//record Poco(string Property1, string Property2);