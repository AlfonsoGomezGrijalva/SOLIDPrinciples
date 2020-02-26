﻿using SOLID_Principles.DIP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID_Principles.SRP
{
    public class FilePolicySource : IPolicySource
    {
        public string GetPolicyFromSource()
        {
            return File.ReadAllText("../../../policy.json");
        }
    }
}
