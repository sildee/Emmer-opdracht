namespace Emmer_opdracht
{
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