using System.Threading.Tasks;

namespace Savaged.HasMyPasswordBeenPwned.Lib
{
    public interface IPwnedService
    {
        bool? IsPwned { get; }

        Task LoadAsync();
    }
}