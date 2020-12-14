// Package/SubSystem 1
public class Warehouse
{
    public bool CheckStock() => true;
}

// Package/SubSystem 2
public class Payment
{
    public bool CheckPayment() => true;
}

// Package/SubSystem 3
public class Order
{
    public void Send() => WriteLine("Sending order");
}
