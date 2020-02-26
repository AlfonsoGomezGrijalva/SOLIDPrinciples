using SOLID_Principles.DIP;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject
{
    public class FakePolicySource : IPolicySource
    {
        public string PolicyString { get; set; } = "";

        public string GetPolicyFromSource()
        {
            return PolicyString;
        }
    }
}
