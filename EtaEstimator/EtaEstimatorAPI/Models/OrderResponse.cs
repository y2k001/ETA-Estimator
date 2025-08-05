namespace EtaEstimatorAPI.Models
{
    public class OrderResponse
    {
        public List<ProductEta> ProductEtas { get; set; }
        public int MaxEstimatedDays { get; set; }
        public string Message { get; set; }
    }
}
