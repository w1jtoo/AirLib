using DiggerLib;
using NUnit.Framework;
using static DiggerLib.Vector;

namespace Tests
{
    public class Tests
    {
        private readonly Vector vNull = new Vector(vType.NULL);
        private readonly Vector vUp = new Vector(vType.UP);
        private readonly Vector vDown = new Vector(vType.DOWN);
        private readonly Vector vRight = new Vector(vType.RIGHT);
        private readonly Vector vLeft = new Vector(vType.LEFT);
        private readonly Vector vRundom = new Vector(vType.RANDOM);

        [Test]
        public void NullVectorTestOne()
        {
            Assert.IsTrue(vNull.IsNull());
        }
        [Test]
        public void NullVectorTestTwo()
        {
            var vResult = vRight + vLeft;
            Assert.IsTrue(vResult.IsNull());
        }
        [Test]
        public void MultVectorTest()
        {

            var vDouble = vRight + vRight;
            var vMult = vRight * 2;
            Assert.IsTrue(vDouble == vMult);
        }
        [Test] 
        public void Normalize()
        {
            var Vec = (vRight) * 2;
            Vec.Normalize();
            Assert.AreNotEqual(Vec,vRight);
        }
        [TestCase(-5,5)]
        [TestCase(0, 1)]
        [TestCase(0, 0)]
        public void NormalizeWithOperator(int min, int max)
        {
            var temp = new Vector(vType.RANDOM, min, max);
            Assert.IsTrue((!temp).Length() == 1);
        }
    }
}