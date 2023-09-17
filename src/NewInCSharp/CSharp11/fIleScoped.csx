// File 1
// file interface IWidget
// {
//     int ProvideAnswer();
// }

// file class HiddenWidget
// {
//     public int Work() => 42;
// }

// public class Widget : IWidget
// {
//     public int ProvideAnswer()
//     {
//         var worker = new HiddenWidget();
//         return worker.Work();
//     }
// }

// File 2
// Doesn't conflict with HiddenWidget declared in file1
public class HiddenWidget
{
    public void RunTask()
    {
        // omitted
    }
}
