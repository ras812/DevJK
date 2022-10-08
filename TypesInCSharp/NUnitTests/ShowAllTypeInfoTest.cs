using System;
using System.Collections.Generic;
using NUnit.Framework;
using TypesInCSharp;

namespace NUnitTests
{
    [TestFixture]

    public class ShowAllTypeInfoTest
    {
        [Test]
        [TestCase(typeof(Int32), 0, 1, 0)]
        [TestCase(typeof(bool), 0, 1, 0)]
        [TestCase(typeof(string), 1, 0, 0)]
        public void Test_GetGetRefValInterTypesCount(Type t, int expected_1, int expected_2, int expected_3)
        {
            AssemblyInfo ai = new AssemblyInfo(t);
            int actual_1 = ai.ReferenceTypeCounts;
            int actual_2 = ai.ValueTypeCounts;
            int actual_3 = ai.InterfaceTypeCount;

            Assert.AreEqual(expected_1, actual_1);
            Assert.AreEqual(expected_2, actual_2);
            Assert.AreEqual(expected_3, actual_3);
        }

        [Test]
        [TestCase(typeof(int), "Int32", "GetTypeCode", "TryParse")]
        [TestCase(typeof(bool), "Boolean", "GetTypeCode", "TryParse")]
        [TestCase(typeof(string), "String", "GetPinnableReference", "Compare")]
        public void Test_GetMethodsProperties(Type t, string expected_1, string expected_2, string expected_3)
        {
            AssemblyInfo ai = new AssemblyInfo(t);
            string actual_1 = ai.TypeWithMaxMethodsCount;
            string actual_2 = ai.LongestMethodsName;
            string actual_3 = ai.MethodNameWithMaxArguments;

            Assert.AreEqual(expected_1, actual_1);
            Assert.AreEqual(expected_2, actual_2);
            Assert.AreEqual(expected_3, actual_3);
        }
    }
}

