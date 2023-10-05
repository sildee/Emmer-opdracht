using Emmer_opdracht;
namespace EmmerOpdrachtTests
{
    public class EmmerOpdrachtTests
        // tests for:
        // negative values in content or capacity
        // content exceeding capacity
        // negative values or overflow after bucket transfer
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1,-5)]
        [TestCase(-5, -5)]
        [TestCase(0, -554)]
        [TestCase(1, 0)]
        [TestCase(100,10)]
        public void BucketCreation_CheckLimits(int Content, int Capacity)
        {
            Assert.That(() => new Bucket(Content, Capacity), Throws.TypeOf<System.ArgumentOutOfRangeException>());
        }
        // test that bucket overflow is not permitted
        [Test]
        public void FillingBucketWithBucket_CheckLimits()
        {
            //Arrange
            Bucket a = new Bucket(15, 15);
            Bucket b = new Bucket(5, 15);
            //Act & Assert
            Assert.That(() => a.FillBucketWithBucket(b), Throws.TypeOf<System.ArgumentOutOfRangeException>());
        }
        //check content cannot be negative or larger than max capacity
        [TestCase(-5)]
        [TestCase(500000)]
        public void OilBarrelCreation_CheckLimits(int Content)
        {
            //Act & Assert
            Assert.That(() => new OilBarrel(Content), Throws.TypeOf<System.ArgumentOutOfRangeException>());
        }

        [TestCase(-5, RainBarrel.RainBarrelCapacity.Value80)]
        [TestCase(-5, RainBarrel.RainBarrelCapacity.Value100)]
        [TestCase(-5, RainBarrel.RainBarrelCapacity.Value120)]
        public void RainBarrelCreation_CheckLimits(int Content, RainBarrel.RainBarrelCapacity capacity)
        {
            //Act & Assert
            //Check negative content
            Assert.That(() => new RainBarrel(Content, RainBarrel.RainBarrelCapacity.Value80), Throws.TypeOf<System.ArgumentOutOfRangeException>());
        }
    }
}