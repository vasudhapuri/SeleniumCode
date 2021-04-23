using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Selenium
{
    [TestClass]
    public class _10MSTestAttributes
    {
        private TestContext testContext;

        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            Console.WriteLine("AssemblyInitialize executing");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Console.WriteLine("AssemblyCleanup executing");
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Console.WriteLine("ClassInitialize executing");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Console.WriteLine("ClassCleanup executing");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Console.WriteLine("TestInitialize executing");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Console.WriteLine("TestCleanup executing");
        }

        [TestMethod]
        public void Dummy1()
        {
            Console.WriteLine(TestContext.TestName);
            Console.WriteLine("Within test case dummy1");
        }
        [TestMethod]
        public void Dummy2()
        {
            Console.WriteLine(TestContext.TestName);
            Console.WriteLine("Within test case dummy2");
        }
    }
}