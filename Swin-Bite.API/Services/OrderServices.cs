using SwinBite.Models;
using SwinBite.Reposiroties;

namespace SwinBite.Services
{
  public class OrderServices
  {
    private readonly OrderRepository _repo;

    public OrderServices(OrderRepository repo)
    {
      _repo = repo;
    }

    public async Task SaveOrder(Order order)
    {
      await _repo.SaveOrder(order);
    }
  }
}
