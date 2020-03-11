
namespace SOLID.Service.Policy.Serializer
{
    public interface IPolicySerializer
    {
        SOLID.Policy GetPolicyFromString(string policyString);
    }
}
