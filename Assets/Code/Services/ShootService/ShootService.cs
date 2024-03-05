using Code.Services.CoroutineRunner;
using System;
using System.Collections;
using UnityEngine;

namespace Code.Services.ShootService
{
    public class ShootService : IShootService
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly int _maxBullets = 5;
        private readonly WaitForSeconds _reloadTime = new(3f);

        private int _bullets;

        public event Action Shooted;
        public event Action BulletsEnded;
        public event Action Reloaded;

        public ShootService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            Reset();
        }

        public void Shoot()
        {
            if(_bullets < 1)
                return;

            _bullets--;

            Shooted?.Invoke();

            if(_bullets == 0) 
            {
                BulletsEnded?.Invoke();

                _coroutineRunner.StartCoroutine(Reload());
            }
        }

        public void Reset()
        {
            _bullets = _maxBullets;
        }

        private IEnumerator Reload()
        {
            yield return _reloadTime;

            _bullets = _maxBullets;
            Reloaded?.Invoke();
        }
    }
}
