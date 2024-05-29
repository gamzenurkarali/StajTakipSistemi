using AspNetCore;
using NBench;
using StajyerTakipSistemi.Web.Controllers;
using System.Net.Http.Headers;

namespace StressTests
{
    internal class LoginStressTest
    {
        Counter testCounter;
        HomeController homeController;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            homeController = new();
            testCounter = context.GetCounter("CheckoutCounter");
        }

        public void Checkout_Test()
        {
            homeController.Checkout(new Login[]
                )
        }
    }
}
