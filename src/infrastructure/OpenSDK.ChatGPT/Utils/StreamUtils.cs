using Newtonsoft.Json;
using OpenSDK.ChatGPT.Model.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
    public static class StreamUtils
    {
        public static async Task<List<string?>> ReadToStringArrayAsync(this Stream stream)
        {
            var result = new List<string?>();

            using (StreamReader reader = new StreamReader(stream))
            {
                var readLine = string.Empty;
                while ((readLine = await reader.ReadLineAsync()) != null)
                {
                    if (readLine.StartsWith("data:"))
                        readLine = readLine.Substring("data:".Length).TrimStart();

                    if (readLine.Contains("[DONE]"))
                        break;

                    if (readLine.StartsWith(":") || string.IsNullOrWhiteSpace(readLine))
                        continue;

                    var completionsModel = JsonConvert.DeserializeObject<CompletionsResponse>(readLine);

                    result.Add(completionsModel?.choices[0].delta?.content);
                }
            }

            return result;
        }


    }
}
