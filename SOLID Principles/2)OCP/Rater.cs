using SOLID_Principles.ISP;
using SOLID_Principles.SRP;
using SOLIDPrinciples;

namespace SOLID_Principles.OCP
{
    public abstract class Rater
    {
        protected ILogger Logger { get; set; }

        public Rater(ILogger logger)
        {
            Logger = logger;
        }
        public abstract decimal Rate(Policy policy);
    }
}
