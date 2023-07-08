using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;
using StressTesting;


namespace StressTestBenchmark
{
    internal class ShopStressTest
    {
        Counter testCounter;
        Shop shop;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            shop = new();
            testCounter = context.GetCounter("CheckoutCounter");
        }

        [PerfBenchmark(NumberOfIterations = 5, 
            RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 2000,
            TestMode = TestMode.Test)]
        // We assert that Checkout_Test can run more than 11000000 times pr. secound
        [CounterThroughputAssertion("CheckoutCounter", MustBe.GreaterThan, 11000000)]
        // The test shouldn't take more than 64kb
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.SixtyFourKb)]
        public void Checkout_Test()
        {
            shop.Checkout(new Product[]
            {
                new Product("Speakers",1000)
            });

            testCounter.Increment();
        }

        [PerfCleanup]
        public void CleanUp()
        {

        }


    }
}
