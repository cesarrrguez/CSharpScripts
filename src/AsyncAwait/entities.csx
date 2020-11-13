using System.Threading;

public static class Chef
{
    public async static Task<bool> MakePizza()
    {
        WriteLine("Put the pizza in the oven");

        await Task.Delay(4000).ConfigureAwait(false);

        WriteLine("Take the pizza out of the oven");

        return true;
    }

    public static void MakeDrink()
    {
        WriteLine("Start making the drink");

        Thread.Sleep(2000);

        WriteLine("Finish making the drink");
    }
}
