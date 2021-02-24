using ClothesstoreProductsAPI.Models;
using XUnitTestClothesstore.Fixture;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using Alba;

namespace XUnitTestClothesstore
{
    public class TestProductsEndPoints : IClassFixture<ApiClothesstoreFixture>
    {
        private readonly SystemUnderTest _system;

        public TestProductsEndPoints(ApiClothesstoreFixture app)
        {
            _system = app.systemUnderTest;
        }


        [Fact]
        public async Task Very_GetAll()
        {
            var results = await _system.GetAsJson<IList<Product>>("/products");
            results.Count.Should().Be(4);
        }
        [Fact]
        public async Task TestGetAll_Ok()
        {
            var client = new TestClientProvider().Client;
            var results = await client.GetAsync("/products");
            results.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, results.StatusCode);

        }


        [Fact]
        public async Task TestDetailProduct_Ok()
        {
            String[] Nids = { "SHIRT01", "SHIRT02", "SHIRT03" };
            var seed = Environment.TickCount;
            var random = new Random(seed);
            var value = random.Next(0, 2);
            var client = new TestClientProvider().Client;
            var results = await client.GetAsync("/products/" + Nids[value]);
            results.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, results.StatusCode);

        }

        [Fact]
        public async Task TestSearch_Ok()
        {
            String[] Nproducts = { "cami" };
            var seed = Environment.TickCount;
            var random = new Random(seed);
            var value = random.Next(0, 2);
            var client = new TestClientProvider().Client;
            var results = await client.GetAsync("/products/search" + "?name=" + Nproducts[value] + "&page=1&amount=1");
            results.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, results.StatusCode);

        }

    }
}
