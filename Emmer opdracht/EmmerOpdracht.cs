namespace Emmer_opdracht
{
    internal class EmmerOpdracht
    {
        static void Main(string[] args)
        {
            //create list of various objects and showcase all implemented methods.
            //exception handling should be implemented for all of these methods.
            OilBarrel oil1 = new OilBarrel(100);
            RainBarrel rain1 = new RainBarrel(50, RainBarrel.RainBarrelCapacity.Value100);
            Bucket bucket1 = new Bucket(15, 15);
            Bucket bucket2 = new Bucket(10, 20);
            List<Container> list = new List<Container>();
            list.Add(oil1);
            list.Add(rain1);
            list.Add(bucket1);
            list.Add(bucket2);
            oil1.ChangeContents(-50);
            oil1.ChangeContents(50);
            bucket1.FillBucketWithBucket(bucket2);
            rain1.EmptyContents();
            Console.WriteLine();
            //print list of containers.
            foreach(Container container in list)
            {
                container.PrintContainer();
            }
        }
    }
}