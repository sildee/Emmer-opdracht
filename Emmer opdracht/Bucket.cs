using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emmer_opdracht
{
    public class Bucket : Container
    {
        //constructor buckets & check if values are allowed. set 12 as default capacity.
        public Bucket(int content, int capacity) : base(capacity)
        {
            Name = "bucket";
            //check if content is valid
            if (content < 0 || content > capacity)
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
            if (t.Content > t.Capacity)
            {
                ExceptionClass ex = new ExceptionClass(t.Content, 0, t.Capacity);
                ex.ThrowException("bucket");
            }
            Content = 0;
        }
    }
}
