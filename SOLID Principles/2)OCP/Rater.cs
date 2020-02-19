using SOLID_Principles.SRP;
using SOLIDPrinciples;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Principles.OCP
{
    public abstract class Rater
    {
        protected readonly RatingEngine _engine;
        protected readonly ConsoleLogger _logger;

        public Rater(RatingEngine engine, ConsoleLogger logger)
        {
            _engine = engine;
            _logger = logger;
        }
        public abstract void Rate(Policy policy);
    }
}
