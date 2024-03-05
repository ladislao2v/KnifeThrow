using System.Collections;
using Code.Services.CoroutineRunner;
using Code.Services.Factories.MonoBehaviourFactory;
using Code.Services.PauseService;
using Code.Services.Pool;
using Code.UI.Gameplay;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Services.Spawners
{
    public class SpawnerService : ISpawnerService, IPausable
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IPauseService _pauseService;
        private readonly Transform _transform;

        private WaitForSeconds _delay = new(2f);
        private Coroutine _spawning;
        private IPool<TargetView> _pool; 
        private float _delta = 750;

        public SpawnerService(ICoroutineRunner coroutineRunner,
            IFactory<TargetView> factory, 
            Transform transform)
        {
            _coroutineRunner = coroutineRunner;
            _transform = transform;
            _pool = new QueuePool<TargetView>(factory, transform);
        }
    
        public void Start()
        {
            _spawning = _coroutineRunner.StartCoroutine(Spawning());
        }

        public void Stop()
        {
            _coroutineRunner.StopCoroutine(_spawning);
        }

        private IEnumerator Spawning()
        {
            while (true)
            {
                Spawn(_delta);
                Debug.Log(nameof(SpawnerService));
                yield return _delay;
            }
        }

        private void Spawn(float delta)
        {
            var haldDelta = delta / 2;
            var position =_transform.position +  new Vector3(Random.Range(- haldDelta, haldDelta), 0, 0);

            var targetView = _pool.Get(position);
            targetView.Show();
            targetView.Move();
        }

        public void OnPause()
        {
            Stop();
        }

        public void OnResume()
        {
            Start();
        }
    }
}
