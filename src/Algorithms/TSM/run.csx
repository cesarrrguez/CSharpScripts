#load "algorithms.csx"

Node nodeA = new Node { City = "A" };
Node nodeB = new Node { City = "B" };
Node nodeC = new Node { City = "C" };
Node nodeD = new Node { City = "D" };

nodeA.Ways.AddRange(new List<Way>
{
    new Way { Node = nodeB, Distance = 5 },
    new Way { Node = nodeC, Distance = 15 },
    new Way { Node = nodeD, Distance = 7 }
});

nodeB.Ways.AddRange(new List<Way>
{
    new Way { Node = nodeA, Distance = 5 },
    new Way { Node = nodeC, Distance = 10 },
    new Way { Node = nodeD, Distance = 5 }
});

nodeC.Ways.AddRange(new List<Way>
{
    new Way { Node = nodeA, Distance = 15 },
    new Way { Node = nodeB, Distance = 10 },
    new Way { Node = nodeD, Distance = 3 }
});

nodeD.Ways.AddRange(new List<Way>
{
    new Way { Node = nodeA, Distance = 7 },
    new Way { Node = nodeB, Distance = 5 },
    new Way { Node = nodeC, Distance = 3 }
});

List<Node> graph = new List<Node>()
{
    nodeA, nodeB, nodeC, nodeD
};

Algorithm algorithm = new Algorithm(graph, nodeA, 5);
algorithm.Run();
WriteLine(algorithm.GetAllRoutes());
