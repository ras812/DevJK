using NUnit.Framework;
using WellcomeToLinq.WordsHandler;

namespace NUnitTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        //[TestCase(@"/Users/Aleks/Projects/DevGame/WellcomeToLinq/test", new string[] { "Project", "EBook" })]     // for MAC only
        [TestCase(@"D:\ProgC\PersonalRepo\WellcomeToLinq\test", new string[] { "Project", "EBook" })]

        public void Test_GetWordsFromFiles(string filePath, string[] expected)
        {
            string[] actual = Handler.GetWordsFromFiles(new Handler(filePath));
            Assert.AreEqual(expected, actual);
        }
    }
}