using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SOLID_Principles.DIP;
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
        private readonly ILogger _logger; // DIP 
        private readonly IPolicySource _policySource;
        private readonly IPolicySerializer _policySerializer;
        private readonly RaterFactory _raterFactory;

        public decimal Rating { get; set; }

        public RatingEngine(ILogger logger, IPolicySource policySource, IPolicySerializer policySerializer, RaterFactory raterFactory)
        {            
            _logger = logger;
            _policySource = policySource;
            _policySerializer = policySerializer;
            _raterFactory = raterFactory;
        }
        public void Rate()
        {
            _logger.Log("Starting rate.");
            _logger.Log("Loading policy.");

            string policyJson = _policySource.GetPolicyFromSource();
            var policy = _policySerializer.GetPolicyFromString(policyJson);

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

            var rater = _raterFactory.Create(policy);

            rater.Rate(policy);

            _logger.Log("Rating completed.");
        }
    }
}
