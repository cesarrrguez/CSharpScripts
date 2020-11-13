#load "entities.csx"

// (6) --> (4) --> (5) --> (1)
//          |       |       ^
//          v       v       |
//         (3) --> (2) ----- 

var node1 = new Node<int>(1);
var node2 = new Node<int>(2);
var node3 = new Node<int>(3);
var node4 = new Node<int>(4);
var node5 = new Node<int>(5);
var node6 = new Node<int>(6);

node6.Nodes.Add(node4);
node4.Nodes.Add(node5);
node4.Nodes.Add(node3);
node3.Nodes.Add(node2);
node5.Nodes.Add(node2);
node5.Nodes.Add(node1);
node2.Nodes.Add(node1);

WriteLine(node6.GetPath());
