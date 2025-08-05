using EtaEstimatorAPI.Models;
using System.Collections.Concurrent;

namespace EtaEstimatorAPI.Services
{
    public static class OrderService
    {
        private static ConcurrentDictionary<Guid, SubmittedOrder> _orders = new();

        public static List<SubmittedOrder> GetAllSubmittedOrders()
        {
            return _orders.Values.ToList();
        }

        public static SubmittedOrder? GetById(Guid id)
        {
            if (_orders.TryGetValue(id, out var order))
            {
                return order;
            }
            else
            {
                return null;
            }
        }

        public static SubmittedOrder SaveOrder(string region, List<string> productIds, EtaEstimatorService service)
        {
            var orderRequest = new OrderRequest
            {
                Region = region,
                ProductIds = productIds
            };

            var response = service.EstimateOrderETA(orderRequest);

            var submitted = new SubmittedOrder
            {
                Region = region,
                ProductEtas = response.ProductEtas,
                MaxEstimatedDays = response.MaxEstimatedDays,
                Message = response.Message
            };

            _orders[submitted.OrderId] = submitted;
            return submitted;
        }
    }
}
