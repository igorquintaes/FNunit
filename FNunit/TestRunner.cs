using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FNunit
{
    public static class TestRunner
    {
        private static List<MethodInfo> ForcingTestList;

        public static void CheckIfShoudlRun()
        {
            if (ForcingTestList == null)
                ForcingTestList = new List<MethodInfo>(
                    Assembly.GetCallingAssembly()
                        .GetTypes()
                        .SelectMany(t => t
                            .GetMethods()
                            .Where(m => m.CustomAttributes
                                .Any(a => a.AttributeType == typeof(FTestAttribute) ||
                                          a.AttributeType == typeof(FTestCaseAttribute))))
                        .ToList());

            if (!ForcingTestList.Any())
                return;

            var forcingTest = ForcingTestList.FirstOrDefault(methodInfo =>
                $"{methodInfo.DeclaringType.FullName}.{methodInfo.Name}" ==
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.MethodName}");

            if (forcingTest == null)
                Assert.Inconclusive();

            if (forcingTest.CustomAttributes.Any(a => a.AttributeType == typeof(FTestCaseAttribute)) &&
                GetAttributes(forcingTest).All(x => !JsonCompare(x, TestContext.CurrentContext.Test.Arguments.ToArray())))
                Assert.Inconclusive();
        }

        private static bool JsonCompare(object obj, object another) =>
            JsonConvert.SerializeObject(obj) ==
            JsonConvert.SerializeObject(another);

        private static IEnumerable<IEnumerable<object>> GetAttributes(MethodInfo method)
        {
            var atts = Attribute.GetCustomAttributes(method, typeof(FTestCaseAttribute))
                as FTestCaseAttribute[];

            return atts?.Select(x => x.Arguments).ToArray() ??
                   new List<IEnumerable<object>>().ToArray();
        }
    }
}
