using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.DTO
{
   public enum OrderStatusDTO
    {
        New,
        Pending,
        Confirmed,
        PaymentReceived,
        Shipped,
        Delivered,
        Returned,
        Refund,
        Cancelled
    }
}
