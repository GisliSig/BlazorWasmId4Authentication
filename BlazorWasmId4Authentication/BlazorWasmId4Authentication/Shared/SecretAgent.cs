using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorWasmId4Authentication.Shared
{
    public class SecretAgent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public bool IsMissing { get; set; }
    }
}
