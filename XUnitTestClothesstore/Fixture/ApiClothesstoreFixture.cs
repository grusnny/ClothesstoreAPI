using System;
using System.Collections.Generic;
using System.Text;
using Alba;

namespace XUnitTestClothesstore.Fixture
{
    public class ApiClothesstoreFixture : IDisposable
    {
        public readonly SystemUnderTest systemUnderTest;
        public ApiClothesstoreFixture()
        {
            systemUnderTest = SystemUnderTest.ForStartup<ClothesstoreProductsAPI.Startup>();
        }
        public void Dispose()
        {
            systemUnderTest?.Dispose();
        }
    }
}
