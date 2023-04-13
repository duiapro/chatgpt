using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSDK.ChatGPT.Model.Response
{
    public class ChoiceResponse
    {
        public int index { get; set; }

        public MessageResponse? delta { get; set; }

        public string? finish_reason { get; set; }
    }
}
