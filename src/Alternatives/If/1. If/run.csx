decimal total = 1000;
decimal discount;
decimal tax;

if (total < 10)
{
    tax = total * 0.2m;
}
else if (total >= 10 && total < 100)
{
    tax = total * 0.1m;
}
else if (total >= 100 && total < 1000)
{
    discount = total * 0.2m;
}
else
{
    discount = total * 0.3m;
}

WriteLine(total + tax - discount); // 700
