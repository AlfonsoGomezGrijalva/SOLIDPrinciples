using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SOLID_Principles.DIP;
using SOLIDPrinciples;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Principles.SRP
{
    public class PolicySerializer : IPolicySerializer
    {
        public Policy GetPolicyFromString(string policyString)
        {
            try
            {
                return JsonConvert.DeserializeObject<Policy>(policyString, new StringEnumConverter());
            }
            catch
            {
                return null;
            }
            
        }
    }
}
