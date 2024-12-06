using Abstractions.SmartEnum;

namespace Shared.Contracts.Topics;

public class Topics : Enumeration<Topics>
{
    private Topics(int value, string name) : base(value, name)
    {
    }

    public static readonly Topics ProductCreatedTopic = new Topics(1, "product-created-topic");
    public static readonly Topics ProductSoftDeleted = new Topics(2, "product-soft-deleted-topic");
    public static readonly Topics OrderEvents = new Topics(3, "order-events");
    public static readonly Topics InventoryEvents = new Topics(4, "inventory-events");
    public static readonly Topics PaymentEvents = new Topics(5, "payment-events");
    public static readonly Topics ProductEvents = new Topics(5, "product-events");
}