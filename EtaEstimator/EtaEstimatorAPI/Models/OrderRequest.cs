namespace EtaEstimatorAPI.Models
{
    public class OrderRequest
    {
        public string Region { get; set; }
        public List<string> ProductIds { get; set; }
    }
}
