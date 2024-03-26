using System.Runtime.InteropServices;
using System.Text.Json;
using WorkerTimer.Models;

namespace WorkerTimer;

public class Worker : IHostedLifecycleService
{
    private readonly ILogger<Worker> _logger;
    private readonly ApplicationState _applicationState;
    private Timer? _timer;


    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
        _logger.LogInformation("***** Testes com .NET 8 | Utilizando IHostedLifecycleService *****");
        _logger.LogInformation($"Versao do .NET em uso: {RuntimeInformation
            .FrameworkDescription} - Ambiente: {Environment.MachineName} - Kernel: {Environment
            .OSVersion.VersionString}");
        _applicationState = new ApplicationState();
        DisplayCurrentTime(_applicationState);
        LogStatusApplication("Constructor");
    }

    public Task StartingAsync(CancellationToken cancellationToken)
    {
        _applicationState.StartingAsync = true;
        LogStatusApplication(nameof(StartingAsync));
        _timer = new Timer(callback: DisplayCurrentTime, state: _applicationState,
            dueTime: Timeout.Infinite, period: 0);
        return Task.CompletedTask;
    }


    public Task StartAsync(CancellationToken cancellationToken)
    {
        _applicationState.StartAsync = true;
        LogStatusApplication(nameof(StartAsync));
        _logger.LogWarning("Pressione Ctrl+C para encerrar a execucao do servico...");
        _timer!.Change(dueTime: TimeSpan.FromSeconds(5), period: TimeSpan.FromSeconds(1));
        return Task.CompletedTask;
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        _applicationState.StartedAsync = true;
        LogStatusApplication(nameof(StartedAsync));
        return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        _applicationState.StoppingAsync = true;
        LogStatusApplication(nameof(StoppingAsync));
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer!.Change(Timeout.Infinite, 0);
        _applicationState.StopAsync = true;
        LogStatusApplication(nameof(StopAsync));
        return Task.CompletedTask;
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        _applicationState.StoppedAsync = true;
        LogStatusApplication(nameof(StoppedAsync));
        return Task.CompletedTask;
    }

    private void DisplayCurrentTime(object? state) => _logger.LogInformation(
        $"Horario atual: {DateTime.Now:HH:mm:ss} | " +
        $"Status da aplicacao: {JsonSerializer.Serialize(state)}");

    private void LogStatusApplication(string methodName) => _logger.LogInformation(
        $"{methodName} | Status da aplicacao: {JsonSerializer.Serialize(_applicationState)}");
}