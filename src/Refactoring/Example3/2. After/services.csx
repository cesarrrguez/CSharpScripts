#load "entities.csx"
#load "exception.csx"
#load "records.csx"

public class OrderProcessor
{
    private const int ProcessableNumberOfLineItems = 15;

    public ProcessOrderResult Process(Order? order)
    {
        if (!IsOrderProcessable(order))
        {
            return ProcessOrderResult.NotProcessable();
        }

        if (order!.Items.Count > ProcessableNumberOfLineItems)
        {
            return ProcessOrderResult.HasTooManyLineItems(order.Id);
        }

        if (order.Status != OrderStatus.ReadyToProcess)
        {
            return ProcessOrderResult.NotReadyForProcessing(order.Id);
        }

        order.IsProcessed = true;
        return ProcessOrderResult.Successful(order.Id);
    }

    public static bool IsOrderProcessable(Order? order)
    {
        return order is not null &&
               order.IsVerified &&
               order.Items.Any();
    }
}
