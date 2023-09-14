#load "../../packages.csx"

using HashidsNet;

Hashids hashids = new Hashids("this is my salt");

// Encode
string id = hashids.Encode(1, 2, 3);
WriteLine(id); // laHquq

// Decode
int[] numbers = hashids.Decode(id);
WriteLine(string.Join(", ", numbers)); // 1, 2, 3
