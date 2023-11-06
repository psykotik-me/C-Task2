namespace NetParserLibrary.Tests
{
    public class NetParserLibraryTests
    {
        private FileParser fp;
        private ResOut res;

        [SetUp]
        public void Setup()
        {
            fp = new FileParser();
            res = new ResOut();

        }


        [Test]
        [TestCase("data.txt", 9, 806.065f)]
        [TestCase("./TestData/test.txt", 0,0f)]
        public void AnalyseLines_ValidFileValidDataTest(string input, int expectedRow, float expectedSum)
        {
            res = fp.GetBiggestAmountOfRow(input);
            // Assert
            if (File.Exists(input))
            {
                Console.WriteLine($"���� {input} ����.");

            }
            else
            {
                string currentDirectory = Environment.CurrentDirectory;
                string projectRootDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(currentDirectory, @"../../../"));
                Console.WriteLine("���� �� �������� ����� ��������� �������: " + projectRootDirectory);

            }


            Assert.IsNotNull(res);
            Assert.That(res.resrow, Is.EqualTo(expectedRow));
            Assert.That(res.ressum, Is.EqualTo(expectedSum));
          
        }

        [Test]
        public void GetBiggestAmountOfRow_TestWhenFileDoesNotExist()
        {
            string nonExistentFile = "nonExistentFile.txt"; // ���� �� ����
            res = fp.GetBiggestAmountOfRow(nonExistentFile);

            // �������� ���������� ��� �������, ���� ���� �� ����
            int expectedRow = 0;
            float expectedSum = -1.0f;


            Assert.That(expectedRow, Is.EqualTo(res.resrow));
            Assert.That(expectedSum, Is.EqualTo(res.ressum));
        }

    }
}