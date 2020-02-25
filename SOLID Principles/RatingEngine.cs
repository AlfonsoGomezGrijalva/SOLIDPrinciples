using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SOLID_Principles.ISP;
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
        #region before ISP
        //public ConsoleLogger Logger { get; set; } = new ConsoleLogger(); // Logging is delegated
        //public FilePolicySource PolicySource { get; set; } = new FilePolicySource(); // Persistence is delegated
        //public PolicySerializer PolicySerializer { get; set; } = new PolicySerializer(); //Encoding Format is delegated
        #endregion
        public IRatingContext _ratingContext { get; set; } = new DefaultRatingContext();
        public decimal Rating { get; set; }

        public RatingEngine()
        {
            _ratingContext.Engine = this;
        }
        public void Rate()
        {
            _ratingContext.Log("Starting rate.");
            _ratingContext.Log("Loading policy.");

            string policyJson = _ratingContext.LoadPolicyFromFile();
            var policy = _ratingContext.GetPolicyFromJsonString(policyJson);

            #region Before implement Factory
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

            #region before ISP
            //var factory = new RaterFactory();

            //var rater = factory.Create(policy, this);

            #endregion

            var rater = _ratingContext.CreateRaterForPolicy(policy, _ratingContext);

            rater.Rate(policy);

            _ratingContext.Log("Rating completed.");
        }
    }
}
