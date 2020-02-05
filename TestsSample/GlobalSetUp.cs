using FNunit;
using NUnit.Framework;

namespace TestsSample
{
    public class GlobalSetUp
    {
        [SetUp]
        public void SetUp()
        {
            TestRunner.CheckIfShoudlRun();
        }
    }
}
