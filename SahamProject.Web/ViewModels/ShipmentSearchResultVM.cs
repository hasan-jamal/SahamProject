namespace SahamProject.Web.ViewModels
{
    public class ShipmentSearchResultVM
    {
        public double Price { get; set; }
        public string MerchanName { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string StatusName { get; set; }
        public string ShipmentTypeId { get; set; }
        public List<ShipmentsProductSearchVM> shipmentsProducts { get; set; } = new List<ShipmentsProductSearchVM>();
    }

    public class ShipmentsProductSearchVM
    {
        public string? Description { get; set; }
        public decimal? Width { get; set; }
        public decimal? SPLength { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public bool? IsBreakable { get; set; }
    }
}
