using System;
using System.Collections.Generic;
using System.Text;
using SOLID_Principles.ISP;
using SOLID_Principles.OCP;
using SOLID_Principles.SRP;
using SOLIDPrinciples;

namespace SOLID_Principles.LSP
{
    public class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(ILogger logger)
            : base(logger)
        {
        }
        public override decimal Rate(Policy policy)
        {
            Logger.Log("Unknown policy type");
            return 0m;
        }
    }
}
