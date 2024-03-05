using Code.Services.PauseService;
using UnityEngine;
using Zenject;

namespace Code.Services.Factories.MonoBehaviourFactory
{
    public class SimpleFactory<TObject> : IFactory<TObject> where TObject : MonoBehaviour
    {
        private readonly IPauseService _pauseService;
        private readonly DiContainer _diContainer;
        private readonly TObject[] _prefabs;

        public SimpleFactory(IPauseService pauseService, DiContainer diContainer, TObject[] prefabs)
        {
            _pauseService = pauseService;
            _diContainer = diContainer;
            _prefabs = prefabs;
        }

        public TObject Create(Vector3 position, Transform parent = null)
        {
            var instance = _diContainer.InstantiatePrefabForComponent<TObject>(
                _prefabs[Random.Range(0, _prefabs.Length)],
                parent
            );
            
            if(instance is IPausable pausable)
                _pauseService.Add(pausable);

            return instance;
        }

        public TObject Create(Transform parent = null) => 
            Create(Vector3.zero, parent);
    }
}