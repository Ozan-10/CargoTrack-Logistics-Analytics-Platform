namespace DapperProjectDay.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }

        public string TrackingCode { get; set; }

        public string SenderCity { get; set; }

        public string ReceiverCity { get; set; }

        public int BranchId { get; set; }

        public int CourierId { get; set; }

        public string Status { get; set; }

        public decimal Weight { get; set; }

        public decimal ShippingPrice { get; set; }

        public DateTime ShipmentDate { get; set; }

        public DateTime? DeliveryDate { get; set; }
    }
}