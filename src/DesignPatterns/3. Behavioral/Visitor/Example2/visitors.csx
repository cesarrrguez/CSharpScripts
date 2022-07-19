#load "entities.csx"

// Concrete Visitor A
public class DiscountVisitor : IVisitor
{
    private double _savings;

    public void VisitBook(Book book)
    {
        var discount = 0.0;

        if (book.Price < 20.00)
        {
            discount = book.GetDiscount(0.10);
            WriteLine($"DISCOUNTED: Book #{book.Id} is now {Math.Round(book.Price - discount, 2)}");
        }
        else
        {
            WriteLine($"FULL PRICE: Book #{book.Id} is {book.Price}");
        }

        _savings += discount;
    }

    public void VisitVinyl(Vinyl vinyl)
    {
        var discount = vinyl.GetDiscount(0.15);
        WriteLine($"SUPER SAVINGS: Vinyl #{vinyl.Id} is now {Math.Round(vinyl.Price - discount, 2)}");

        _savings += discount;
    }

    public void Print()
    {
        WriteLine($"\nYou saved a total of {Math.Round(_savings, 2)} on today´s order!");
    }

    public void Reset()
    {
        _savings = 0.0;
    }
}

// Concrete Visitor B
public class SalesVisitor : IVisitor
{
    private int _bookCount;
    private int _vinylCount;

    void IVisitor.VisitBook(Book book)
    {
        _bookCount++;
    }

    void IVisitor.VisitVinyl(Vinyl vinyl)
    {
        _vinylCount++;
    }

    public void Print()
    {
        WriteLine($"Books sold {_bookCount} \nVinyls sold: {_vinylCount}");
        WriteLine($"The store sold: {_bookCount + _vinylCount} units today!");
    }
}
