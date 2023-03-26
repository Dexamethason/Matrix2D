using MatrixLib;
namespace Matrix2DTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDodawaniaMacierzy()
        {
            var m1 = new Matrix2D(1, 2, 3, 4);
            var m2 = new Matrix2D(0, 1, -1, 2);
            var m = m1 + m2;
            var expected = new  Matrix2D(1, 3, 2, 6);
            Assert.AreEqual(expected, m);
        }
        [TestMethod]
        public void TestOdejmowaniaMaciarzy()
        {
            var m1 = new Matrix2D(1, 2, 3, 4);
            var m2 = new Matrix2D(0, 1, -1, 2);
            var m = m1 - m2;
            var expected = new Matrix2D(1, 1, 4, 2);
            Assert.AreEqual(expected, m);
        }
        [DataTestMethod]
        [DataRow("[[1,2], [3,4]]", 1,2,3,4)]
        public void TestParsowanieMacierzy_OK(string s, int a, int b, int c, int d)
        {
            var m = Matrix2D.Parse(s);
            var expected = new Matrix2D(a,b,c,d);
            Assert.AreEqual(expected, m);
        }

        [DataTestMethod]
        [ExpectedException(typeof(FormatException))]
        [DataRow("[[1,2] [3,4]]")]
        [DataRow("[[1 2], [3,4]]")]
        [DataRow("[[1,2], [3 4]]")]
        [DataRow("[[1,2], [3,4]")]
        public void TestParsowaniaMacierzy_Wyjatek(string s)
        {
            var m = Matrix2D.Parse(s);
        }

        [TestMethod]
        public void TestMnozeniaMacierzy()
        {
            var m1 = new Matrix2D(1, 2, 3, 4);
            var m2 = new Matrix2D(0, 1, -1, 2);
            var m = m1 * m2;
            var expected = new Matrix2D(-2, 5, -4, 11);
            Assert.AreEqual(expected, m);
        }
    }
}