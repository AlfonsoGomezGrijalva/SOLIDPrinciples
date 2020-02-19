using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID_Principles.SRP
{
    public class FilePolicySource
    {
        public string GetPolicyFromSource()
        {
            return File.ReadAllText("../../../policy.json");
        }
    }
}
