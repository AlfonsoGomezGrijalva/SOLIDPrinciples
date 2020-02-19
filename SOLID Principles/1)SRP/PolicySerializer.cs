using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SOLIDPrinciples;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Principles.SRP
{
    public class PolicySerializer
    {
        public Policy GetPolicyFromJsonString(string policyJson)
        {
            try
            {
                return JsonConvert.DeserializeObject<Policy>(policyJson, new StringEnumConverter());
            }
            catch
            {
                return null;
            }
            
        }
    }
}
