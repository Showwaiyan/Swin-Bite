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

        public async Task<List<DeliveryDriver>> GetNearByDelivery()
        {
            List<DeliveryDriver> drivers = await _repo.GetAllDeliveryAsync();
            return drivers;
        }

    }
}
