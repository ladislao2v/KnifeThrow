using Code.Services.Factories.MonoBehaviourFactory;
using Code.Services.Spawners;
using Code.UI.Gameplay;
using UnityEngine;
using Zenject;

namespace Code.Installers.Local
{
    public class SpawnerServiceInstaller : MonoInstaller
    {
        [SerializeField] private TargetView[] _prefabs;
        [SerializeField] private Transform _container;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<SimpleFactory<TargetView>>()
                .AsSingle()
                .WithArguments(_prefabs);

            Container
                .BindInterfacesAndSelfTo<SpawnerService>()
                .AsSingle()
                .WithArguments(_container);
        }
    }
}