decimal total = 1000;
decimal discount;
decimal tax;

switch (total)
{
    case decimal t when (t < 10):
        tax = total * 0.2m;
        break;
    case decimal t when (t >= 10 && t < 100):
        tax = total * 0.1m;
        break;
    case decimal t when (t >= 100 && t < 1000):
        discount = total * 0.2m;
        break;
    default:
        discount = total * 0.3m;
        break;
}

WriteLine(total + tax - discount); // 700
