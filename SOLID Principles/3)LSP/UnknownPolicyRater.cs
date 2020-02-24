using System;
using System.Collections.Generic;
using System.Text;
using SOLID_Principles.OCP;
using SOLID_Principles.SRP;
using SOLIDPrinciples;

namespace SOLID_Principles.LSP
{
    public class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(RatingEngine engine, ConsoleLogger logger)
        : base(engine, logger)
        {
        }
        public override void Rate(Policy policy)
        {
            _logger.Log("Unknown policy type");
        }
    }
}
