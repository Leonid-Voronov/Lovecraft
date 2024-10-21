using Lovecraft.Client.Ui.DataProjection;
using MVVM;
using UniRx;
using Zenject;

namespace Lovecraft.Client.Ui.ViewModels
{
  public sealed class WoodViewModel : ITickable
  {
    [Data("Resource")] public readonly ReactiveProperty<string> Wood = new();

    private readonly IResourcesProjection _resourcesProjection;

    [Inject]
    public WoodViewModel(IResourcesProjection resourcesProjection)
    {
      _resourcesProjection = resourcesProjection;
    }

    public void Tick() => Wood.Value = _resourcesProjection.WoodAmount.ToString();
  }
}

