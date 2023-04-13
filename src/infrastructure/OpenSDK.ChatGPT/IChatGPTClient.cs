using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OpenSDK.ChatGPT
{
    public interface IChatGPTClient
    {
        Task<Stream> SendAsync(string messageBody);
    }
}
