using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Service.Policy
{
    public interface IPolicySource
    {
        string GetPolicyFromSource();
    }
}
