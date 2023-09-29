namespace Emmer_opdracht
{
    public class ExceptionClass
    {
        int InputValue { get; }
        int MinValue { get; }
        int MaxValue { get; }
        //class to throw expections as requested in requirements.
        //class is also used to throw exceptions when content of container exceed capacity due to it also being an outofrange exception.
        //chose for a method rather than including the error message in the class constructor as requested because it's more efficient to only write the error message once.
        public ExceptionClass(int input, int min, int max) {
            InputValue = input;
            MinValue = min;
            MaxValue = max;
        }
        public void ThrowException(string name)
        {
            Console.WriteLine($"Input of {InputValue} for {name} is invalid! Input must be at least {MinValue} and at most {MaxValue}");
            Exception ex = new ArgumentOutOfRangeException(nameof(InputValue), "Capacity not possible.");
            throw (ex);
        }
    }
    public class Container
    {
        // create getter for capacity but not setter to make readonly after constructor
        public int Capacity { get; }
        public int Content { get; set; }
        public string Name;
        // parent constructor
        public Container(int capacity)
        {
            Capacity = capacity;
        }

        //method to change contents.
        public void ChangeContents(int value)
        {
            if (value > 0)
            {
                Console.WriteLine($"Adding {value} to contents of {Name}.");
                Content = Content + value;
            }
            else
            {
                Console.WriteLine($"Removing {value} from contents of {Name}.");
                Content = Content + value;
                if(Content < 0)
                {
                    ExceptionClass ex = new ExceptionClass(Content, 0, Capacity);
                    ex.ThrowException("container");

                }
            }
            Console.WriteLine($"Value is now {Content}");
        }
        // empty container.
        public void EmptyContents()
        {
            Content = 0;
            Console.WriteLine($"{Name} has been emptied. Value is now {Content}");
        }
        // print container details
        public void PrintContainer()
        {
            Console.WriteLine($"Container type is {Name}, Content is {Content} and the Capacity is {Capacity} ");
        }

    }
    public class Bucket : Container
    {
        //constructor buckets & check if values are allowed. set 12 as default capacity.
        public Bucket(int content, int capacity) : base(capacity)
        {
            Name = "bucket";
            //check if content is valid
            if(content < 0 || content > capacity)
            {
                ExceptionClass ex = new ExceptionClass(content, 0, capacity);
                ex.ThrowException("bucket");
            }
            Content = content;
            // check if capacity is valid
            if (capacity < 10 || capacity > 2500)
            {
                ExceptionClass ex = new ExceptionClass(capacity, 10, 2500);
                ex.ThrowException("bucket");
            }
        }
        // fill bucket with bucket. t = target bucket to fill, method is called from bucket that will be used to do so.
        public void FillBucketWithBucket(Bucket t)
        {
            Console.WriteLine($"Filling target bucket that had {t.Content} by {Content}");
            t.Content = t.Content + Content;
            if(t.Content > t.Capacity)
            {
                ExceptionClass ex = new ExceptionClass(t.Content, 0, t.Capacity);
                ex.ThrowException("bucket");
            }
            Content = 0;
        }

    }
    public class RainBarrel : Container
    {
        //set allowed values for rain barrel.
        public enum RainBarrelCapacity
        {
            Value80 = 80,
            Value100 = 100,
            Value120 = 120,
        }
        // constructor for rain barrels where one of the default values has to be called.
        public RainBarrel(int content, RainBarrelCapacity c) : base((int)c)
        {
            Name = "Rain barrel";
            if (content < 0)
            {
                ExceptionClass ex = new ExceptionClass(content, 0, Convert.ToInt32(c));
                ex.ThrowException("rain barrel");
            }

            Content = content;
        }

    }
    public class OilBarrel : Container
    {
        //always set the capacity value in the parent constructor to be 159 so it cannot be changed.
        public OilBarrel(int content) : base(159)
        {
            Name = "Oil barrel";
            if(content >= 0 && content <= 159)
            {
                Content = content;
            } else
            {
                ExceptionClass ex = new ExceptionClass(content, 0, 159);
                ex.ThrowException("oil barrel");
            }
        }
    }
    internal class EmmerOpdracht
    {
        static void Main(string[] args)
        {
            //create list of various objects and showcase all implemented methods.
            //exception handling should be implemented for all of these methods.
            OilBarrel Oil1 = new OilBarrel(100);
            RainBarrel Rain1 = new RainBarrel(50, RainBarrel.RainBarrelCapacity.Value100);
            Bucket Bucket1 = new Bucket(15, 15);
            Bucket Bucket2 = new Bucket(5, 35);
            List<Container> list = new List<Container>();
            list.Add(Oil1);
            list.Add(Rain1);
            list.Add(Bucket1);
            list.Add(Bucket2);
            Oil1.ChangeContents(-50);
            Bucket1.FillBucketWithBucket(Bucket2);
            Bucket2.EmptyContents();
            Console.WriteLine();
            //print list of containers.
            foreach(Container container in list)
            {
                container.PrintContainer();
            }
        }
    }
}