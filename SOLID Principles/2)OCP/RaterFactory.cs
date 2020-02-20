using SOLIDPrinciples;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Principles.OCP
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine engine)
        {
            #region before using reflection
            //switch (policy.Type)
            //{
            //    case PolicyType.Auto:
            //        return new AutoPolicyRater(engine, engine.Logger);

            //    case PolicyType.Land:
            //        return new LandPolicyRater(engine, engine.Logger);

            //    case PolicyType.Life:
            //        return new LifePolicyRater(engine, engine.Logger);

            //    case PolicyType.Flood:
            //        return new FloodPolicyRater(engine, engine.Logger);

            //    default:
            //        return new UnknownPolicyRater(engine, engine.Logger);

            //}
            #endregion

            try
            {
                return (Rater)Activator.CreateInstance(Type.GetType($"SOLID_Principles.OCP.{policy.Type}PolicyRater"), new object[] { engine, engine.Logger });
            }
            catch
            {
                return null;
            }
        }
    }
}
