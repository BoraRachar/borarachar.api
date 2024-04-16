using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using BoraRachar.Domain.Service.Abstract.Interfaces.Bases;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Bases;

[ExcludeFromCodeCoverage]
public class BaseService : IBaseService
{
    public ILogger logger { get; }
    private readonly string _serviceName;
    private readonly Stopwatch _stopwatch;

    public BaseService(ILogger logger, [CallerMemberName] string serviceName = "Service")
    {
        this.logger = logger;
        _serviceName = serviceName;
        _stopwatch = new Stopwatch();
        _stopwatch.Start();
        this.logger.LogInformation($"O Serviço foi iniciado {_serviceName}");
    }

    public void Dispose()
    {
        _stopwatch.Stop();
        logger.LogInformation($"O Serviço foi finalizado {_serviceName} tempo: {_stopwatch.Elapsed.TotalSeconds}");
    }
}