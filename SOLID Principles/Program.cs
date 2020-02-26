using SOLID_Principles.DIP;
using SOLID_Principles.OCP;
using SOLID_Principles.SRP;
using System;

namespace SOLIDPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insurance Rating System Starting...");
            var logger = new FileLogger();

            var engine = new RatingEngine(logger, new FilePolicySource(), new PolicySerializer(), new RaterFactory(logger));
            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }

        }
    }
}
