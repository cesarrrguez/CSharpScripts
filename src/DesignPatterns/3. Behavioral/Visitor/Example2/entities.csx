// Visitor
public interface IVisitor
{
    void VisitBook(Book book);
    void VisitVinyl(Vinyl vinyl);
    void Print();
}

public interface IVisitableElement
{
    void Accept(IVisitor visitor);
}

// Element
public class Item
{
    public int Id { get; set; }
    public double Price { get; set; }

    public Item(int id, double price)
    {
        Id = id;
        Price = price;
    }

    public double GetDiscount(double percentage) => Math.Round(Price * percentage, 2);
}

// Concrete Element A
public class Book : Item, IVisitableElement
{
    public Book(int id, double price) : base(id, price) { }

    public void Accept(IVisitor visitor) => visitor.VisitBook(this);
}

// Concrete Element B
public class Vinyl : Item, IVisitableElement
{
    public Vinyl(int id, double price) : base(id, price) { }

    public void Accept(IVisitor visitor) => visitor.VisitVinyl(this);
}
