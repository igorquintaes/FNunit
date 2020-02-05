using NUnit.Framework;

namespace TestsSample
{
    public class Tests : GlobalSetUp
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

        }

        [Test]
        public void Test2()
        {

        }

        [Test]
        public void TestValues1([Values(1, 2, 3)]int a)
        {

        }

        [Test]
        public void TestValues2([Values(1, 2, 3)]int a)
        {

        }

        [FTest]
        public void TestValuesF([Values(1, 2, 3)]int a)
        {

        }

        [FTest]
        public void TestF()
        {

        }

        [TestCase("abc", 1)]
        [TestCase("abc", 2)]
        [TestCase("def", 3)]
        public void TestCase1(string a, int b)
        {

        }

        [TestCase("abc", 1)]
        [TestCase("abc", 2)]
        [TestCase("def", 3)]
        public void TestCase2(string a, int b)
        {

        }

        [FTestCase("abc", 1)]
        [TestCase("abc", 2)]
        [TestCase("def", 3)]
        public void TestCaseF(string a, int b)
        {

        }
    }
}