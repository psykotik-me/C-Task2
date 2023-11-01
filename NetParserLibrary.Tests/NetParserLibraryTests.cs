namespace NetParserLibrary.Tests
{
    public class NetParserLibraryTests
    {
        private FileParser fp;

        [SetUp]
        public void Setup()
        {
            fp = new FileParser();
        }


        [Test]
        [TestCase("data.txt", (8,806.065))]
        [TestCase("test1.txt", (0,0))]
        [TestCase("test2.txt", (8,125.64))]
        [TestCase("test3.txt", (5,127.46))]
        public void GetBiggestAmountOfRow_EqualTest(string input, (int row, float sum) expectedOutput)
        {
            Assert.Pass();
        }
        [Test]
        public void GetBiggestAmountOfRow_TestWhenFileDoesNotExist()
        {
            string nonExistentFile = "nonExistentFile.txt"; // Файл не існує
            (int row, float sum) result = fp.GetBiggestAmountOfRow(nonExistentFile);

            // Очікувані результати для випадку, коли файл не існує
            int expectedRow = -1;
            float expectedSum = 0;

            Assert.That(expectedRow, Is.EqualTo(result.row));
            Assert.That(expectedSum, Is.EqualTo(result.sum));
        }

    }
}