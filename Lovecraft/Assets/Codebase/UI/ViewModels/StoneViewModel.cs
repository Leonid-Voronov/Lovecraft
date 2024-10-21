using Lovecraft.Client.Ui.DataProjection;
using MVVM;
using UniRx;
using Zenject;

namespace Lovecraft.Client.Ui.ViewModels
{
  public sealed class StoneViewModel : ITickable
  {
    [Data("Resource")] public readonly ReactiveProperty<string> Stone = new();

    private readonly IResourcesProjection _resourcesProjection;

    [Inject]
    public StoneViewModel(IResourcesProjection resourcesProjection)
    {
      _resourcesProjection = resourcesProjection;
    }

    public void Tick() => Stone.Value = _resourcesProjection.StoneAmount.ToString();
  }
}

