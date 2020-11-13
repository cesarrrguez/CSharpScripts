#load "entities.csx"

var tree = new Tree<char>();
var node_A = tree.Add(null, 'A');

var node_B = tree.Add(node_A, 'B');
var node_C = tree.Add(node_A, 'C');
var node_D = tree.Add(node_C, 'D');
var node_E = tree.Add(node_C, 'E');
var node_F = tree.Add(node_C, 'F');
var node_G = tree.Add(node_F, 'G');
var node_H = tree.Add(node_F, 'H');
var node_I = tree.Add(node_F, 'I');
var node_J = tree.Add(node_A, 'J');
var node_K = tree.Add(node_J, 'K');
var node_L = tree.Add(node_A, 'L');
var node_M = tree.Add(node_L, 'M');
var node_N = tree.Add(node_L, 'N');
var node_O = tree.Add(node_L, 'O');
var node_P = tree.Add(node_O, 'P');
var node_Q = tree.Add(node_O, 'Q');
var node_R = tree.Add(node_A, 'R');
var node_S = tree.Add(node_R, 'S');
var node_T = tree.Add(node_S, 'T');

// Root path
WriteLine("Root path:");
WriteLine(tree.GetPath(tree.Root));

// Find
WriteLine("\nFind F:");
var node = tree.Find(tree.Root, 'F');
WriteLine(tree.GetPath(node));
