using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenSDK.ChatGPT.Service
{
    public class ChatGPTClient : IChatGPTClient
    {
        private readonly HttpClient httpClient;

        public ChatGPTClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + "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");
        }

        public async Task<Stream> SendAsync(string messageBody)
        {
            List<object> messages = new List<object>();
            messages.Add(new
            {
                role = "user", // 角色
                content = messageBody // 发送内容
            });
            // ChatGpt需要的参数
            var values = new
            {
                model = "gpt-3.5-turbo", // 使用的模型
                temperature = 0.1,
                max_tokens = 2000,
                stream = true,
                user = "token",
                messages
            };

            return await this.PostAsync(ChatGPTConst.Completions, values);
        }


        private async Task<Stream> PostAsync(string url, object? body = null)
        {
            HttpContent? httpConten = null;

            if (body is HttpContent)
            {
                httpConten = (HttpContent)body;
            }
            else
            {
                var parameter = JsonConvert.SerializeObject(body);
                httpConten = new StringContent(parameter, Encoding.UTF8, "application/json");
            }

            var result = await httpClient.PostAsync(url, httpConten);

            return await result.Content.ReadAsStreamAsync();
        }
    }
}
