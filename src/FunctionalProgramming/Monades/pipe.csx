Func<decimal, decimal> iva = (decimal amount) => amount + (amount * 0.16m);
Func<decimal, decimal> discount = (decimal amount) => amount - (amount * 0.1m);
Func<decimal, decimal> surcharge = (decimal amount) => amount + (amount * 0.2m);
Func<decimal, decimal> anualPartialities = (decimal amount) => amount / 12;

WriteLine(anualPartialities(discount(iva(surcharge(100))))); // 10,4400

decimal amount = 100;
decimal total = amount
    .Pipe(surcharge)
    .Pipe(iva)
    .Pipe(discount)
    .Pipe(anualPartialities);

WriteLine(total); // 10,4400

public static TOut Pipe<TIn, TOut>(this TIn value, Func<TIn, TOut> fnOut)
    where TIn : struct
    where TOut : struct
{
    return fnOut(value);
}
