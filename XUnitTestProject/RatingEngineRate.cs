using Newtonsoft.Json;
using SOLID_Principles.OCP;
using SOLID_Principles.SRP;
using SOLIDPrinciples;
using System;
using System.IO;
using Xunit;

namespace XUnitTestProject
{
    public class RatingEngineRate
    {
        private RatingEngine _engine = null;
        private FakeLogger _logger;
        private FakePolicySource _policySource;
        private PolicySerializer _policySerializer;

        public RatingEngineRate()
        {
            _logger = new FakeLogger();
            _policySource = new FakePolicySource();
            _policySerializer = new PolicySerializer();
            _engine = new RatingEngine(_logger,
                _policySource,
                _policySerializer,
                new RaterFactory(_logger));
        }
        [Fact]
        public void ReturnsRatingOf10000For200000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 200000
            };
            string json = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", json);

            _engine.Rate();
            var result = _engine.Rating;

            Assert.Equal(0, result);
        }

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            string json = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", json);

            _engine.Rate();
            var result = _engine.Rating;

            Assert.Equal(0, result);
        }

        [Fact]
        public void ReturnsDefaultPolicyFromEmptyJsonString()
        {
            var inputJson = "";
            var serializer = new PolicySerializer();

            var result = serializer.GetPolicyFromString(inputJson);

            Assert.Null(result);
        }

        [Fact]
        public void LogsStartingLoadingAndCompleting()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            string json = JsonConvert.SerializeObject(policy);
            _policySource.PolicyString = json;

            _engine.Rate();
            var result = _engine.Rating;

            Assert.Contains(_logger.LoggedMessages, m => m == "Starting rate.");
            Assert.Contains(_logger.LoggedMessages, m => m == "Loading policy.");
            Assert.Contains(_logger.LoggedMessages, m => m == "Rating completed.");
        }
    }
}
