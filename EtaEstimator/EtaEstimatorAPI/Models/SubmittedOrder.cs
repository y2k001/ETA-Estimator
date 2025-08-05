namespace EtaEstimatorAPI.Models
{
    public class SubmittedOrder
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public string Region { get; set; }
        public List<ProductEta> ProductEtas { get; set; }
        public int MaxEstimatedDays { get; set; }
        public string Message { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
