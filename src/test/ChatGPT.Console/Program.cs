// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using OpenSDK.ChatGPT;
using OpenSDK.ChatGPT.Model.Response;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using Tavis.UriTemplates;
using static System.Runtime.InteropServices.JavaScript.JSType;

IServiceCollection serviceCollection = new ServiceCollection();
serviceCollection.AddChatGTPClient();
var bulud = serviceCollection.BuildServiceProvider();

var chatGPTClient = bulud.GetRequiredService<IChatGPTClient>();

string? value = null;
Console.WriteLine("请输入对话内容：");
while ((value = Console.ReadLine()) != null)
{
    var steam = await chatGPTClient.SendAsync(value);
    var readToStringArrayAsync = await steam.ReadToStringArrayAsync();
    Console.WriteLine(string.Join("", readToStringArrayAsync));
    Console.WriteLine("请输入对话内容：");
}
