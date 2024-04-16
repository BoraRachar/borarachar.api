using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Bases;

public interface IBaseService : IDisposable
{
    ILogger logger { get; }
}