int[] numbers = { 1, 2, 3 };

WriteLine(numbers is [1, 2, 3]);  // True
WriteLine(numbers is [1, 2, 4]);  // False
WriteLine(numbers is [1, 2, 3, 4]);  // False
WriteLine(numbers is [0 or 1, <= 2, >= 3]);  // True
