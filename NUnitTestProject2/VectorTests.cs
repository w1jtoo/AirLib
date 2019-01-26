using DiggerLib;
using NUnit.Framework;
using static DiggerLib.Vector;

namespace Tests
{
    public class Tests
    {
        private readonly Vector vNull = new Vector(VectorType.NULL);
        private readonly Vector vUp = new Vector(VectorType.UP);
        private readonly Vector vDown = new Vector(VectorType.DOWN);
        private readonly Vector vRight = new Vector(VectorType.RIGHT);
        private readonly Vector vLeft = new Vector(VectorType.LEFT);
        private readonly Vector vRundom = new Vector(VectorType.RANDOM);

        [Test]
        public void NullVectorTestOne()
        {
            Assert.IsTrue(vNull.IsZero());
        }
        [Test]
        public void NullVectorTestTwo()
        {
            var vResult = vRight + vLeft;
            Assert.IsTrue(vResult.IsZero());
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
            var Vec = (vRight + vUp) * 2;
            Vec.Normalize();
            Assert.AreNotEqual(Vec,vRight);
        }
        [TestCase(-5,5)]
        [TestCase(0, 1)]
        [TestCase(0, 0)]
        public void NormalizeWithOperator(int min, int max)
        {
            var temp = new Vector(VectorType.RANDOM, min, max);
            Assert.IsTrue((!temp).Length() == 1);
        }
    }
}