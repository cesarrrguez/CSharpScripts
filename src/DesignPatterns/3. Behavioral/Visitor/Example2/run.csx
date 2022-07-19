#load "visitors.csx"
#load "services.csx"

var items = new List<IVisitableElement>{
    new Book(12345, 11.99) ,
    new Book(78910, 22.79) ,
    new Vinyl(11198, 17.99) ,
    new Book(63254, 9.79)
};

var visitorService = new VisitorService(items);
var discountVisitor = new DiscountVisitor();
var salesVisitor = new SalesVisitor();

visitorService.ApplyVisitor(discountVisitor);
visitorService.ApplyVisitor(salesVisitor);

discountVisitor.Reset();
visitorService.RemoveItem(items[2]);
visitorService.ApplyVisitor(discountVisitor);
