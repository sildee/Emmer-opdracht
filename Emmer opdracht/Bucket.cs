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
            Name = "Bucket";
            //check if content is valid
            if (content < 0 || content > capacity)
            {
                var ex = new ExceptionClass(content, 0, capacity);
                ex.ThrowException("bucket");
            }
            Content = content;
            // check if capacity is valid
            if (capacity < 10 || capacity > 2500)
            {
                var ex = new ExceptionClass(capacity, 10, 2500);
                ex.ThrowException("bucket");
            }
            //subscribe to events at the bottom of child constructors to prevent events proceeding before exceptions can be handled
            ContainerFull += ContainerFullAction;
            ContainerOverflow += ContainerOverflowAction;
        }
        // fill bucket with bucket. t = target bucket to fill, method is called from bucket that will be used to do so.
        public void FillBucketWithBucket(Bucket target)
        {
            Console.WriteLine($"Filling target bucket that had {target.Content} by {Content}");
            target.Content += Content;
           /* this code is no longer needed because of part 3 introducing an overflow handling event.
            if (target.Content > target.Capacity)
            {

                ExceptionClass ex = new ExceptionClass(target.Content, 0, target.Capacity);
                ex.ThrowException("bucket");
            } 
           */
            Content = 0;
        }
    }
}
