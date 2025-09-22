using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceCloner.Shared.Models
{
    public class VoiceResponse
    {
        public bool Success { get; set; }
        public string? AudioBase64 { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
