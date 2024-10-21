using Zenject;

namespace Lovecraft.Client.Ui.DataProjection
{
  public class GlobalMapProjections : IGlobalMapProjections
  {
    public IResourcesProjection ResourcesProjection { get; }

    [Inject]
    public GlobalMapProjections(IResourcesProjection resourcesProjection)
    {
      ResourcesProjection = resourcesProjection;
    }
  }
}


