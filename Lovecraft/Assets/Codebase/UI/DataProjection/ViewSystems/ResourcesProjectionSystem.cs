using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Lovecraft.Client.GameplayCommon;
using Lovecraft.Client.Resources;

namespace Lovecraft.Client.Ui.DataProjection
{
  public class ResourcesProjectionSystem : IEcsRunSystem
  {
    private readonly EcsCustomInject<IGlobalMapProjections> _projection = default;
    private readonly EcsFilterInject<Inc<PlayerTag, Wood, Stone, Iron, Warpstone>> _playerInject = default;

    public void Run(IEcsSystems systems)
    {
      foreach (var entity in _playerInject.Value) 
      {
        int woodAmount = _playerInject.Pools.Inc2.Get(entity).WoodCount;
        int stoneAmount = _playerInject.Pools.Inc3.Get(entity).StoneCount;
        int ironAmount = _playerInject.Pools.Inc4.Get(entity).IronCount;
        int warpstoneAmount = _playerInject.Pools.Inc5.Get(entity).WarpstoneCount;

        _projection.Value.ResourcesProjection.ProjectResources(woodAmount, stoneAmount, ironAmount, warpstoneAmount);
      }
    }
  }
}

