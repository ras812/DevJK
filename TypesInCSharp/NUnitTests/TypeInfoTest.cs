using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NUnitTests
{
    [TestFixture]

    public class TypeInfoTest
    {
        [Test]
        [TestCase(typeof(int), "System.Int32")]
        [TestCase(typeof(bool), "System.Boolean")]
        [TestCase(typeof(string), "System.String")]
        public void Test_GetTypeNameTest(Type t, string expected)
        {
            TypesInCSharp.TypeInfo ti = new TypesInCSharp.TypeInfo(t);
            string actual = ti.TypeName;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(typeof(int), true)]
        [TestCase(typeof(bool), true)]
        [TestCase(typeof(string), false)]
        public void Test_GetIsValueType(Type t, bool expected)
        {
            TypesInCSharp.TypeInfo ti = new TypesInCSharp.TypeInfo(t);
            bool actual = ti.IsValueType;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(typeof(int), "System")]
        [TestCase(typeof(bool), "System")]
        [TestCase(typeof(string), "System")]
        public void Test_GetNamespace(Type t, string expected)
        {
            TypesInCSharp.TypeInfo ti = new TypesInCSharp.TypeInfo(t);
            string actual = ti.Namespace;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(typeof(int), "System.Private.CoreLib")]
        [TestCase(typeof(bool), "System.Private.CoreLib")]
        [TestCase(typeof(string), "System.Private.CoreLib")]
        public void Test_GetAssemblyName(Type t, string expected)
        {
            TypesInCSharp.TypeInfo ti = new TypesInCSharp.TypeInfo(t);
            string actual = ti.Assembly;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(typeof(int), 23)]
        [TestCase(typeof(bool), 16)]
        [TestCase(typeof(string), 157)]
        public void Test_GetElementsCount(Type t, int expected)
        {
            TypesInCSharp.TypeInfo ti = new TypesInCSharp.TypeInfo(t);
            int actual = ti.ElementsCount;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(typeof(int), 2)]
        [TestCase(typeof(bool), 2)]
        [TestCase(typeof(string), 1)]
        public void Test_GetFieldsCount(Type t, int expected)
        {
            TypesInCSharp.TypeInfo ti = new TypesInCSharp.TypeInfo(t);
            int actual = ti.FieldsCount;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(typeof(int), 0)]
        [TestCase(typeof(bool), 0)]
        [TestCase(typeof(string), 2)]
        public void Test_GetPropertiesCount(Type t, int expected)
        {
            TypesInCSharp.TypeInfo ti = new TypesInCSharp.TypeInfo(t);
            int actual = ti.PropertiesCount;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(typeof(int), 21)]
        [TestCase(typeof(bool), 14)]
        [TestCase(typeof(string), 154)]
        public void Test_GetMethodsCount(Type t, int expected)
        {
            TypesInCSharp.TypeInfo ti = new TypesInCSharp.TypeInfo(t);
            int actual = ti.MethodsCount;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(typeof(int), new string[] {"MaxValue", "MinValue"})]
        [TestCase(typeof(bool), new string[]{"TrueString", "FalseString"})]
        [TestCase(typeof(string), new string[]{"Empty"})]
        public void Test_GetFieldsInThisType(Type t, string[] expected)
        {
            TypesInCSharp.TypeInfo ti = new TypesInCSharp.TypeInfo(t);
            string[] actual = ti.FieldsInType;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(typeof(int), new string[] {})]
        [TestCase(typeof(bool), new string[]{})]
        [TestCase(typeof(string), new string[]{"Chars", "Length"})]
        public void Test_GetPropertiesInThisType(Type t, string[] expected)
        {
            TypesInCSharp.TypeInfo ti = new TypesInCSharp.TypeInfo(t);
            string[] actual = ti.PropertiesInType;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(typeof(int), "Equals", "Equals 2 1 1")]
        [TestCase(typeof(bool), "TryParse", "TryParse 2 2 2")]
        [TestCase(typeof(string), "CopyTo", "CopyTo 1 4 4")]
        public void Test_GetDictMethodsInType(Type typeOfElement, string methodName, string expected)
        {
            TypesInCSharp.TypeInfo ti = new TypesInCSharp.TypeInfo(typeOfElement);

            Dictionary<string, int[]> actual =  ti.DictMethodsInType;

            Assert.AreEqual(expected, $"{methodName} {string.Join(" ", actual[methodName])}");
        }
    }
}

