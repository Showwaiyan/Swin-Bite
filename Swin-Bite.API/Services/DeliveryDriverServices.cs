using SwinBite.Models;
using SwinBite.Reposiroties;

namespace SwinBite.Services
{
    public class DeliveryDriverServices
    {
        private readonly DeliveryDriverRepository _repo;

        public DeliveryDriverServices(DeliveryDriverRepository repo)
        {
            _repo = repo;
        }

        public async Task<DeliveryDriver> GetDeliveryDriver(int deliveryDriverId)
        {
            DeliveryDriver driver = await _repo.GetDeliveryDriverByIdAsync(deliveryDriverId);
            if (driver == null)
                throw new ArgumentException("We can't find driver with this id!");
            return driver;
        }

        public async Task<List<DeliveryDriver>> GetNearByDelivery()
        {
            List<DeliveryDriver> drivers = await _repo.GetAllDeliveryAsync();
            return drivers;
        }

        public async Task<Order> AcceptOrder(Order order, int deliveryDriverId)
        {
          DeliveryDriver driver = await GetDeliveryDriver(deliveryDriverId);
          order.DeliveryDriverId = driver.UserId;
          order.DeliveryDriver = driver;
          driver.IsAuthenticated = false;
          return order;
        }
    }
}
