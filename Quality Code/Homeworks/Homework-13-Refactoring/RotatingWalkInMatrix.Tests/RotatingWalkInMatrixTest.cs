namespace RotatingWalkInMatrix.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RotatingWalkInMatrixTest
    {
        [TestMethod]
        public void TestGenerateMatrixWithSize1()
        {
            int[,] matrix = WalkInMatrix.GenerateMatrix(1);

            int[,] expectedResult = { { 1 } };

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Assert.AreEqual(expectedResult[row, col], matrix[row, col]);
                }
            }
        }

        [TestMethod]
        public void TestGenerateMatrixWithSize2()
        {
            int[,] matrix = WalkInMatrix.GenerateMatrix(1);

            int[,] expectedResult = { { 1, 4 }, { 3, 2 } };

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Assert.AreEqual(expectedResult[row, col], matrix[row, col]);
                }
            }
        }

        [TestMethod]
        public void TestGenerateMatrixWithSize3()
        {
            int[,] matrix = WalkInMatrix.GenerateMatrix(1);

            int[,] expectedResult = { { 1, 7, 8 }, { 6, 2, 9 }, { 5, 4, 3 } };

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Assert.AreEqual(expectedResult[row, col], matrix[row, col]);
                }
            }
        }

        [TestMethod]
        public void TestGenerateMatrixWithSize6()
        {
            int[,] matrix = WalkInMatrix.GenerateMatrix(6);

            int[,] expectedResult =
            {
                { 1, 16, 17, 18, 19, 20 },
                { 15, 2, 27, 28, 29, 21 },
                { 14, 31, 3, 26, 30, 22 },
                { 13, 36, 32, 4, 25, 23 },
                { 12, 35, 34, 33, 5, 24 },
                { 11, 10, 9, 8, 7, 6 }
            };

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Assert.AreEqual(expectedResult[row, col], matrix[row, col]);
                }
            }
        }
    }
}
