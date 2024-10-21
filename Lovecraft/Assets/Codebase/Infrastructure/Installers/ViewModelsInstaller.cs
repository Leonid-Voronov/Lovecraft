using Lovecraft.Client.Ui.ViewModels;
using Zenject;

namespace Lovecraft.Client.Infrastructure.Installers
{
  public class ViewModelsInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<WoodViewModel>()
          .AsSingle()
          .NonLazy();

      Container.BindInterfacesAndSelfTo<StoneViewModel>()
          .AsSingle()
          .NonLazy();

      Container.BindInterfacesAndSelfTo<IronViewModel>()
          .AsSingle()
          .NonLazy();

      Container.BindInterfacesAndSelfTo<WarpstoneViewModel>()
          .AsSingle()
          .NonLazy();
    }
  }
}

