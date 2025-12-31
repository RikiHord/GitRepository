using _2DMap;

namespace Test2DMap
{
    [TestClass]
    public sealed class Test2DMap
    {
        [TestMethod]
        public void Test_TwoPointOnMap()
        {
            string input = "XXXX,XXPX,XXXX,XPXX,XXXX";
            Map map = new Map(input);
            int moves = map.GetCountMovesBetweenTwoP();
            Assert.AreEqual(3, moves);
        }

        [TestMethod]
        public void Test_NoPointOnMap()
        {
            string input = "XXXX,XXXX,XXXX,XXXX,XXXX";
            Map map = new Map(input);
            int moves = map.GetCountMovesBetweenTwoP();
            Assert.AreEqual(-1, moves);
        }

        [TestMethod]
        public void Test_OnePointOnMap()
        {
            string input = "XXXX,XXPX,XXXX,XXXX,XXXX";
            Map map = new Map(input);
            int moves = map.GetCountMovesBetweenTwoP();
            Assert.AreEqual(-1, moves);
        }

        [TestMethod]
        public void Test_ThreePointOnMap()
        {
            string input = "XXXX,XPXX,XXXX,XPXX,XXPX";
            Map map = new Map(input);
            int moves = map.GetCountMovesBetweenTwoP();
            Assert.AreEqual(-1, moves);
        }

        [TestMethod]
        public void Test_PointsAdjacent()
        {
            string input = "XXXX,XXPX,XXPX,XXXX,XXXX";
            Map map = new Map(input);
            int moves = map.GetCountMovesBetweenTwoP();
            Assert.AreEqual(1, moves);
        }

        [TestMethod]
        public void Test_PointsDiagonal()
        {
            string input = "XXXX,XPXX,XXXX,XXPX,XXXX";
            Map map = new Map(input);
            int moves = map.GetCountMovesBetweenTwoP();
            Assert.AreEqual(3, moves);
        }

        [TestMethod]
        public void Test_LargeMap()
        {
            string input = new string('X', 30) + "P" + new string('X', 69) + "," +
                           new string('X', 100) + "," +
                           new string('X', 100) + "," +
                           new string('X', 98) + "PX";
            Map map = new Map(input);
            int moves = map.GetCountMovesBetweenTwoP();
            Assert.AreEqual(71, moves);
        }

        [TestMethod]
        public void Test_InvalidMap_RowsOfDifferentLengths()
        {
            string input = "XXXX,XXP,XXXX,XPXX,XXXX";
            Assert.ThrowsException<ArgumentException>(() => new Map(input));
        }

        [TestMethod]
        public void Test_EmptyMap()
        {
            string input = "";
            Map map = new Map(input);
            int moves = map.GetCountMovesBetweenTwoP();
            Assert.AreEqual(-1, moves);
        }
    }
}
