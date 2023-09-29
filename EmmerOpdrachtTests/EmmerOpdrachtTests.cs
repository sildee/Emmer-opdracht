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

        [Test]
        public void BucketCreation_CheckCapacityLimits()
        {
            //Act & Assert
            //Check negative capacity
            Assert.That(() => new Bucket(1, -5), Throws.TypeOf<System.ArgumentOutOfRangeException>());
        }
        [Test]
        public void BucketCreation_CheckContentLimits()
        {
            //Act & Assert
            //Check negative content
            Assert.That(() => new Bucket(-10, 15), Throws.TypeOf<System.ArgumentOutOfRangeException>());
            //Check content > capacity (not possible)
            Assert.That(() => new Bucket(150, 15), Throws.TypeOf<System.ArgumentOutOfRangeException>());
        }
        [Test]
        public void FillingBucketWithBucket_CheckValueLimits()
        {
            //Arrange
            Bucket a = new Bucket(15, 15);
            Bucket b = new Bucket(5, 15);
            //Act & Assert
            Assert.That(() => a.FillBucketWithBucket(b), Throws.TypeOf<System.ArgumentOutOfRangeException>());
        }
        [Test]
        public void OilBarrelCreation_CheckContentLimits()
        {
            //Act & Assert
            //Check negative content
            Assert.That(() => new OilBarrel(-5), Throws.TypeOf<System.ArgumentOutOfRangeException>());
        }
        [Test]
        public void OilBarrel_CheckCapacity()
        {
            //Check that capacity is 159
            Assert.That(() => new OilBarrel(50).Capacity == 159);
        }
        [Test]
        public void RainBarrelCreation_CheckContentLimits()
        {
            //Act & Assert
            //Check negative content
            Assert.That(() => new RainBarrel(-5, RainBarrel.RainBarrelCapacity.Value80), Throws.TypeOf<System.ArgumentOutOfRangeException>());
        }
    }
}