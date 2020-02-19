using SOLID_Principles.SRP;
using SOLIDPrinciples;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Principles.OCP
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(RatingEngine engine, ConsoleLogger logger)
        : base(engine, logger)
        {
        }

        public override void Rate(Policy policy)
        {
            _logger.Log("Rating AUTO policy...");
            _logger.Log("Validating policy.");

            if (String.IsNullOrEmpty(policy.Make))
            {
                _logger.Log("Auto policy must specify Make");
                return;
            }

            if(policy.Make == "BMW")
            {
                if(policy.Deductible < 500)
                {
                    _engine.Rating = 1000m;
                    return;
                }
                _engine.Rating = 900m;
            }
        }
    }
}
