#load "entities.csx"

var tree = new BinaryTree<int>();

var root = tree.Add(null, 6);
tree.Add(root, 2);
tree.Add(root, 8);
tree.Add(root, 1);
tree.Add(root, 4);
tree.Add(root, 3);
tree.Add(root, 5);
tree.Add(root, 7);
tree.Add(root, 11);
tree.Add(root, 9);
tree.Add(root, 10);
tree.Add(root, 0);
tree.Add(root, -1);
tree.Add(root, 12);
tree.Add(root, 14);

// Traverse PreOrder
var traverse = tree.TraversePreOrder(tree.Root);
Console.WriteLine($"Traverse PreOrder:\n{traverse}");

// Traverse InOrder
traverse = tree.TraverseInOrder(tree.Root);
Console.WriteLine($"\nTraverse InOrder:\n{traverse}");

// Traverse PostOrder
traverse = tree.TraversePostOrder(tree.Root);
Console.WriteLine($"\nTraverse PostOrder:\n{traverse}");

// Tree depth
var treeDeph = tree.Depth(tree.Root);
Console.WriteLine($"\nTree depth: {treeDeph}");

// Min Value
var minValue = tree.Min(tree.Root);
Console.WriteLine($"Min value: {minValue}");

// Max Value
var maxValue = tree.Max(tree.Root);
Console.WriteLine($"Max value: {maxValue}");

// Find
var findValue = tree.Find(tree.Root, 11);
Console.WriteLine($"Find value 11: {findValue}");

// Remove
tree.Remove(tree.Root, 11);
findValue = tree.Find(tree.Root, 11);
Console.WriteLine($"Remove value 11. Find value 11: {findValue}");
