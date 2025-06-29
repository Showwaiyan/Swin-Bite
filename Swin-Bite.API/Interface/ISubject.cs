using SwinBite.Models;

namespace SwinBite.Interface
{
  public interface ISubject
  {
    public void AddObserver(SwinBite.Interface.IObserver observer);
    public void RemoveObserver(SwinBite.Interface.IObserver observer);
    public void NotifyObservers(Notification notification);
  }
}
