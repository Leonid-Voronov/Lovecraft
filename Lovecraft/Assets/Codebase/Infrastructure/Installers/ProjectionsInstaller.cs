using Lovecraft.Client.Ui.DataProjection;
using Zenject;

namespace Lovecraft.Client.Infrastructure.Installers
{
  public class ProjectionsInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<IGlobalMapProjections>()
          .To<GlobalMapProjections>()
          .AsSingle();

      Container.Bind<IResourcesProjection>()
          .To<ResourcesProjection>()
          .AsSingle();
    }
  }
}

