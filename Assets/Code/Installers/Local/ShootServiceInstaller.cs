using Code.Services.ShootService;
using Zenject;

namespace Assets.Code.Installers.Local
{
    public class ShootServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindShootService();

        private void BindShootService() =>
            Container
                .BindInterfacesAndSelfTo<ShootService>()
                .AsSingle();
    }
}
