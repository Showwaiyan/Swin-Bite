using SwinBite.Models;

namespace SwinBite.Interface
{
    public interface IObserver
    {
        public void Update(Notification notification);
    }
}
