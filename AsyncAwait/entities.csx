using System.Threading;

public static class Chef
{
    public async static Task<bool> MakePizza()
    {
        Console.WriteLine("Put the pizza in the oven");

        await Task.Delay(4000);

        Console.WriteLine("Take the pizza out of the oven");

        return true;
    }

    public static void MakeDrink()
    {
        Console.WriteLine("Start making the drink");

        Thread.Sleep(2000);

        Console.WriteLine("Finish making the drink");
    }
}
