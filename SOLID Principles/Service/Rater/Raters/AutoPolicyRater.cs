using SOLID.Service.Loggers;
using System;

namespace SOLID.Service.Rater.Raters
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(ILogger logger)
        : base(logger)
        {
        }

        public override decimal Rate(SOLID.Policy policy)
        {
            Logger.Log("Rating AUTO policy...");
            Logger.Log("Validating policy.");

            if (String.IsNullOrEmpty(policy.Make))
            {
                Logger.Log("Auto policy must specify Make");
                return 0m;
            }

            if(policy.Make == "BMW")
            {
                if(policy.Deductible < 500)
                {                    
                    return 1000m;
                }
                return 900m;
            }
            return 0m;
        }
    }
}
