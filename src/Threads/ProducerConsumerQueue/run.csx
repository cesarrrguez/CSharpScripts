#load "entities.csx"

using System.Threading;

using (var queue = new PCQ())
{
    WriteLine("Main starts");

    for (var i = 0; i < 5; i++)
    {
        queue.AddValue(i);
    }

    WriteLine("Main continue its work meanwhile PCQ works");
}
