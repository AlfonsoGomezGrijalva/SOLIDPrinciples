using SOLID.Service.Loggers;
using SOLID.Service.Policy;
using SOLID.Service.Policy.Serializer;
using SOLID.Service.Rater;
using System;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insurance Rating System Starting...");
            var logger = new ConsoleLogger();

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
