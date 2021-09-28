using GCForSummerSchool.Models;
using System;

namespace GCForSummerSchool
{
    // GC.GetTotalMemory() - Returns the estimated amount of memory(in bytes) currently allocated
    // on the managed heap.A Boolean parameter specifies whether the call
    // should wait for garbage collection to occur before returning.

    // WaitForPendingFinalizers() - Suspends the current thread until all finalizable objects have been
    // finalized. This method is typically called directly after invoking GC.Collect().
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));
            Console.WriteLine("This OS has {0} object generations.\n", GC.MaxGeneration + 1);

            Point point = new Point(2021, 2022);
            Console.WriteLine(point);

            Console.WriteLine("Generation of refToMyCar is: {0}", GC.GetGeneration(point));

            Console.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));

            long memory1 = GC.GetTotalMemory(false);
            Console.WriteLine("Created tons of objects.");
            object[] tonsOfObjects = new object[50000];
            for (int i = 0; i < 50000; i++)
            {
                tonsOfObjects[i] = new object();
            }

            long memory2 = GC.GetTotalMemory(false);

            long memory = memory2 - memory1;
            Console.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            for (int i = 0; i < 50000; i++)
            {
                tonsOfObjects[i] = null;
            }
            // tonsOfObjects = null;
            //Console.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));

            // Force a garbage collection and wait for each object to be finalized.
            // Collect only gen 0 objects.
            Console.WriteLine("Force Garbage Collection");
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));

            // Print out generation of point.
            Console.WriteLine("\nGeneration of point is: {0}", GC.GetGeneration(point));
            // See if tonsOfObjects[9000] is still alive.
            if (tonsOfObjects[9000] != null)
            {
                Console.WriteLine("Generation of tonsOfObjects[9000] is: {0}", 
                    GC.GetGeneration(tonsOfObjects[9000]));
            }
            else
            {
                Console.WriteLine("tonsOfObjects[9000] is no longer alive.");
            }

            // Print out how many times a generation has been swept.
            Console.WriteLine("\nGen 0 has been swept {0} times", GC.CollectionCount(0));
            Console.WriteLine("Gen 1 has been swept {0} times", GC.CollectionCount(1));
            Console.WriteLine("Gen 2 has been swept {0} times", GC.CollectionCount(2));

            Console.ReadLine();
        }
    }
}