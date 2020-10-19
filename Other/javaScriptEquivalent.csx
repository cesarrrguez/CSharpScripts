// var numbers = [1, 2, 3, 4];
var numbers = new int[] { 1, 2, 3, 4 };

// Map
// -----------------------------------------------------------
// var numbers2 = numbers.map((x) => x * 2);
// console.log(numbers2);
// -----------------------------------------------------------
var numbers2 = numbers.Select(x => x * 2).ToArray();
WriteLine($"Map {string.Join(", ", numbers2)}");

// Filter
// -----------------------------------------------------------
// var numbersGreater2 = numbers.filter((x) => x > 2);
// console.log(numbersGreater2);
// -----------------------------------------------------------
var numbersGreater2 = numbers.Where(x => x > 2).ToArray();
WriteLine($"Filter: {string.Join(", ", numbersGreater2)}");

// Reduce
// -----------------------------------------------------------
// var numbersSum = numbers.reduce((sum, x) => sum + x);
// console.log(numbersSum);
// -----------------------------------------------------------
var numbersSum = numbers.Aggregate((sum, x) => sum + x);
WriteLine($"Reduce: {string.Join(", ", numbersSum)}");
