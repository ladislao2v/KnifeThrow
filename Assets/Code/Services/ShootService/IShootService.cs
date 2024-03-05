using System;

namespace Code.Services.ShootService
{
    public interface IShootService
    {
        event Action Shooted;
        event Action BulletsEnded;
        event Action Reloaded;

        void Shoot();
        void Reset();
    }
}
