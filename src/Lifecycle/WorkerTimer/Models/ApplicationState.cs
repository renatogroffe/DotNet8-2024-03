namespace WorkerTimer.Models;

public class ApplicationState
{
    public bool StartingAsync { get; set; }
    public bool StartAsync { get; set; }
    public bool StartedAsync { get; set; }
    public bool StoppingAsync { get; set; }
    public bool StopAsync { get; set; }
    public bool StoppedAsync { get; set; }
}