using Lovecraft.Client.Ui.DataProjection;
using MVVM;
using UniRx;
using Zenject;

namespace Lovecraft.Client.Ui.ViewModels
{
  public sealed class IronViewModel : ITickable
  {
    [Data("Resource")] public readonly ReactiveProperty<string> Iron = new();

    private readonly IResourcesProjection _resourcesProjection;

    [Inject]
    public IronViewModel(IResourcesProjection resourcesProjection)
    {
      _resourcesProjection = resourcesProjection;
    }

    public void Tick() => Iron.Value = _resourcesProjection.IronAmount.ToString();
  }
}

