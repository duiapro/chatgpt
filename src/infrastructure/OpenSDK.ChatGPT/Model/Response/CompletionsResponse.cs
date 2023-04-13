using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSDK.ChatGPT.Model.Response
{
    public class CompletionsResponse
    {
        public string? id { get; set; }
        public object? _object { get; set; }
        public int created { get; set; }
        public List<ChoiceResponse> choices { get; set; } = new List<ChoiceResponse>();
        public object? usage { get; set; }
    }
}
