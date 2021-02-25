using System;
using ClothesstoreProductsAPI;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace XUnitTestClothesstore
{
    class TestClientProvider : IDisposable
    {

        public HttpClient Client { get; private set; }
        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
        }

        public void Dispose()
        {

            Client?.Dispose();
        }

    }
}
