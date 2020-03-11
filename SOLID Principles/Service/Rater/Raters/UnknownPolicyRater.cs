using SOLID.Service.Loggers;

namespace SOLID.Service.Rater.Raters
{
    public class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(ILogger logger)
            : base(logger)
        {
        }
        public override decimal Rate(SOLID.Policy policy)
        {
            Logger.Log("Unknown policy type");
            return 0m;
        }
    }
}
