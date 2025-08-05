using EtaEstimatorAPI.Data;
using EtaEstimatorAPI.Models;

namespace EtaEstimatorAPI.Services
{
    public class EtaEstimatorService
    {
        public OrderResponse EstimateOrderETA(OrderRequest request)
        {
            var productEtas = new List<ProductEta>();
            if (!DataStore.RegionDelays.TryGetValue(request.Region, out int baseDelay))
            {
                return new OrderResponse
                {
                    Message = "Invalid region.",
                    MaxEstimatedDays = -1,
                    ProductEtas = productEtas
                };
            }

            foreach (var id in request.ProductIds)
            {
                var product = DataStore.Products.FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    productEtas.Add(new ProductEta
                    {
                        ProductId = id,
                        Name = "Unknown",
                        EstimatedDays = -1
                    });
                    continue;
                }

                int delay = baseDelay + (product.InStock ? 0 : 5);
                productEtas.Add(new ProductEta
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    EstimatedDays = delay
                });
            }

            int maxEta = productEtas.Where(p => p.EstimatedDays >= 0).Select(p => p.EstimatedDays).DefaultIfEmpty(0).Max();

            string msg = maxEta > 7
                ? "Some items may take longer to arrive. We appreciate your patience."
                : $"Your order is expected to arrive in {maxEta} day(s).";

            return new OrderResponse
            {
                ProductEtas = productEtas,
                MaxEstimatedDays = maxEta,
                Message = msg
            };

        }
    }
}
