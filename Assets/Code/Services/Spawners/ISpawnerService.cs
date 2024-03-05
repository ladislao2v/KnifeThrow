using Code.Services.PauseService;

namespace Code.Services.Spawners
{
    public interface ISpawnerService : IPausable
    {
        void Start();
        void Stop();
    }
}