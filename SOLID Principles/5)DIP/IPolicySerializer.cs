using SOLIDPrinciples;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Principles.DIP
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromString(string policyString);
    }
}
