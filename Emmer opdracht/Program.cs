namespace Emmer_opdracht
{
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
            Content = content;
            if (capacity < 10 || capacity > 2500)
            {
                Exception ex = new ArgumentOutOfRangeException(nameof(capacity), "Capacity not possible.");
                Console.WriteLine(ex);
                throw ex;
            }
        }
        // fill bucket with bucket. t = target bucket to fill, method is called from bucket that will be used to do so.
        public void FillBucketWithBucket(Bucket t)
        {
            Console.WriteLine($"Filling target bucket that had {t.Content} by {Content}");
            t.Content = t.Content + Content;
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
            Content = content;

        }

    }
    public class OilBarrel : Container
    {
        //always set the value in the parent constructor to be 159 so it cannot be changed.
        public OilBarrel(int content) : base(159)
        {
            Name = "Oil barrel";
            Content = content;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //create list of various objects and showcase all implemented methods. 

            OilBarrel Oil1 = new OilBarrel(100);
            RainBarrel Rain1 = new RainBarrel(50, RainBarrel.RainBarrelCapacity.Value100);
            Bucket Bucket1 = new Bucket(10, 150000);
            Bucket Bucket2 = new Bucket(5, 15);
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