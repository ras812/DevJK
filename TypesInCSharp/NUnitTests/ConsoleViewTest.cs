using System;
using System.Collections.Generic;
using NUnit.Framework;
using TypesInCSharp;

namespace NUnitTests
{
    [TestFixture]

    public class ConsoleViewTest
    {
        [Test]
        [TestCase("Black", true)]
        [TestCase("White", true)]
        [TestCase("Cyanide", false)]
        public void GetTypeNameTest(string color, bool expected)
        {
            ConsoleView Colors = new ConsoleView();
            bool actual = false;

            for (int i = 0; i < Colors.SystemConsoleColors.Length; i++)
            {
                if (Colors.SystemConsoleColors[i] == color)
                {
                    actual = true;
                }
            }

            Assert.AreEqual(expected, actual);
        }
	}
}

