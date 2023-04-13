using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSDK.ChatGPT
{
    internal class ChatGPTConst
    {
        /// <summary>
        /// OpenAi服务地址
        /// </summary>
        public const string ServiceUrlBase = "https://api.openai.com";

        /// <summary>
        /// completions model
        /// </summary>
        public const string Completions = "/v1/chat/completions";

        /// <summary>
        /// dalle model
        /// </summary>
        public const string Generations = "/v1/images/generations";
    }
}
