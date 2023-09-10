public record ProcessOrderResult
{
    private ProcessOrderResult(long orderId, string message)
    {
        OrderId = orderId;
        Message = message;
    }

    public long OrderId { get; init; }
    public string Message { get; init; }

    public static ProcessOrderResult NotProcessable() =>
        new(default, "The order is not processable");

    public static ProcessOrderResult NotReadyForProcessing(long orderId) =>
        new(orderId, $"The order {orderId} has too many items");

    public static ProcessOrderResult HasTooManyLineItems(long orderId) =>
        new(orderId, $"The order {orderId} isn´t ready to process");

    public static ProcessOrderResult Successful(long orderId) =>
        new(orderId, $"The order {orderId} was successfully processed");
}
