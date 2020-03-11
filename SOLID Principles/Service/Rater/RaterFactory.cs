using SOLID.Service.Loggers;
using SOLID.Service.Rater.Raters;
using System;

namespace SOLID.Service.Rater
{
    public class RaterFactory
    {
        private readonly ILogger _logger;

        public RaterFactory(ILogger logger)
        {
            _logger = logger;
        }
        public Rater Create(SOLID.Policy policy)
        {
            try
            {
                return (Rater)Activator.CreateInstance(Type.GetType($"SOLID.Service.Rater.Raters.{policy.Type}PolicyRater"), new object[] { _logger });
            }
            catch
            {
                return new UnknownPolicyRater(_logger);
            }
        }
    }
}
