Func<float, float> circlePerimeter = (b) => Mul(3.1416f, b);

var result = circlePerimeter(5);
WriteLine(result);

public float Mul(float a, float b) => a * b;
