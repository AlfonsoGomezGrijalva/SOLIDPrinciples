using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SOLID_Principles.OCP;
using SOLID_Principles.SRP;
using System;
using System.IO;

namespace SOLIDPrinciples
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger(); // Logging is delegated
        public FilePolicySource PolicySource { get; set; } = new FilePolicySource(); // Persistence is delegated
        public PolicySerializer PolicySerializer { get; set; } = new PolicySerializer(); //Encoding Format is delegated
        public decimal Rating { get; set; }

        public void Rate()
        { 
            Logger.Log("Starting rate.");
            Logger.Log("Loading policy.");

            string policyJson = PolicySource.GetPolicyFromSource();
            var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            #region After implement Factory
            //switch (policy.Type)
            //{
            //    case PolicyType.Auto:
            //        var rater = new AutoPolicyRater(this, this.Logger);
            //        rater.Rate(policy);
            //        break;

            //    case PolicyType.Land:
            //        var rater2 = new LandPolicyRater(this, this.Logger);
            //        rater2.Rate(policy);
            //        break;

            //    case PolicyType.Life:
            //        var rater3 = new LifePolicyRater(this, this.Logger);
            //        rater3.Rate(policy);
            //        break;

            //    default:
            //        Logger.Log("Unknown policy type");
            //        break;
            //}

            #endregion

            var factory = new RaterFactory();

            var rater = factory.Create(policy, this);
            rater?.Rate(policy);

            Logger.Log("Rating completed.");
        }
    }
}
