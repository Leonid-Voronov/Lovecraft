using Lovecraft.Client.Ui.DataProjection;
using MVVM;
using UniRx;
using Zenject;

namespace Lovecraft.Client.Ui.ViewModels
{
  public sealed class WarpstoneViewModel : ITickable
  {
    [Data("Resource")] public readonly ReactiveProperty<string> Warpstone = new();

    private readonly IResourcesProjection _resourcesProjection;

    [Inject]
    public WarpstoneViewModel(IResourcesProjection resourcesProjection)
    {
      _resourcesProjection = resourcesProjection;
    }

    public void Tick() => Warpstone.Value = _resourcesProjection.WarpstoneAmount.ToString();
  }
}

