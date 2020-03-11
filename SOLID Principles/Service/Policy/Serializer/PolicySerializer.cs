using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SOLID.Service.Policy.Serializer
{
    public class PolicySerializer : IPolicySerializer
    {
        public SOLID.Policy GetPolicyFromString(string policyString)
        {
            try
            {
                return JsonConvert.DeserializeObject<SOLID.Policy>(policyString, new StringEnumConverter());
            }
            catch
            {
                return null;
            }
            
        }
    }
}
