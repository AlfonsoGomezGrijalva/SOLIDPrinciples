using SOLID.Service.Loggers;

namespace SOLID.Service.Rater
{
    public abstract class Rater
    {
        protected ILogger Logger { get; set; }

        public Rater(ILogger logger)
        {
            Logger = logger;
        }
        public abstract decimal Rate(SOLID.Policy policy);
    }
}
