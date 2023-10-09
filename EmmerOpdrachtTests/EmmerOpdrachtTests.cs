using Emmer_opdracht;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace EmmerOpdrachtTests
{
    public class EmmerOpdrachtTests
        // tests for part 2:
        // negative values in content or capacity
        // content exceeding capacity
        // negative values or overflow after bucket transfer
    {
        //check content cannot be negative or created above capacity limit in constructor
        [TestCase(0, 5)]
        [TestCase(-5, 10)]
        [TestCase(10000,15)]
        [TestCase(0,-10)]
        public void BucketCreation_CheckLimits(int Content, int Capacity)
        {
            //Act & Assert
            Assert.That(() => new Bucket(Content, Capacity), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        // test that bucket contents are transferred correctly.
        [Test]
        public void FillingBucketWithBucket_CheckLimits()
        {
            //Arrange
            var a = new Bucket(15, 15);
            var b = new Bucket(5, 20);
            //Act & Assert
            a.FillBucketWithBucket(b); Assert.Multiple(() =>
            {
                Assert.That(b.Content, Is.EqualTo(20));
                Assert.That(a.Content, Is.EqualTo(0));
            });
        }

        //check content cannot be negative or created above capacity limit in constructor
        [TestCase(500000)]
        [TestCase(-1000)]
        public void OilBarrelCreation_CheckLimits(int Content)
        {
            //Act & Assert
            Assert.That(() => new OilBarrel(Content), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        //check content cannot be negative or created above capacity limit in constructor
        [TestCase(90, RainBarrel.RainBarrelCapacity.Value80)]
        [TestCase(-15, RainBarrel.RainBarrelCapacity.Value100)]
        public void RainBarrelCreation_CheckLimits(int Content, RainBarrel.RainBarrelCapacity capacity)
        {
            //Act & Assert
            //Check negative content
            Assert.That(() => new RainBarrel(Content, capacity), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        //part 3 tests
        // set up bool and event handler so we can test if the events take place.
        private bool eventTriggered;
        [Test]
        public void CheckIsFullEvent()
        {
            // Arrange
            var BucketToFill = new Bucket(10, 15);
            BucketToFill.ContainerFull += HandleEvent;
            //Act
            BucketToFill.ChangeContents(5);
            //Assert
            Assert.That(eventTriggered, Is.True);
        }
        private void HandleEvent(object sender, EventArgs e)
        {
            eventTriggered = true;
        }
        [Test]
        public void CheckOverflowEventCancelled()
        {
            // Arrange
            var BucketToFill = new Bucket(10, 15);
            BucketToFill.ContainerOverflow += HandleEvent;
            //arrange test console input
            var input = new StringReader("Y");
            Console.SetIn(input);
            //Act
            BucketToFill.ChangeContents(10);
            //Assert that the event has triggered, and that the overflow was cancelled / content is still 20
            Assert.Multiple(() =>
            {
                Assert.That(eventTriggered, Is.True);
                Assert.That(BucketToFill.Content, Is.EqualTo(20));
            });
        }
        [Test]
        public void CheckOverflowEventNotCancelled()
        {
            // Arrange
            var BucketToFill = new Bucket(10, 15);
            BucketToFill.ContainerOverflow += HandleEvent;
            var inputLines = new List<string> { "N", "5" };
            var multiLineInput = new MultiLineStringReader(inputLines);
            Console.SetIn(multiLineInput);
            //Act
            BucketToFill.ChangeContents(10);
            //Assert that the event has triggered, and that the overflow was not cancelled / content was reduced by input2
            Assert.Multiple(() =>
            {
                Assert.That(eventTriggered, Is.True);
                Assert.That(BucketToFill.Content, Is.EqualTo(15));
            });

        }
    }
    //this class is used in the above method.
    //i had to make the class to simulate multiple lines of console input correctly.
    //i thought simulating console input for the unit tests was quite challenging so i found this method on the internet but i think i understand it & can explain it.
    public class MultiLineStringReader : TextReader
    {
        private Queue<string> InputLines { get; }

        public MultiLineStringReader(IEnumerable<string> inputLines)
        {
            InputLines = new Queue<string>(inputLines);
        }

        public override string? ReadLine()
        {
            if (InputLines.Count > 0)
            {
                return InputLines.Dequeue();
            }
            return null;
        }
    }
}