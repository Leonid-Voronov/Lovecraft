using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Lovecraft.Client.GameplayCommon;
using Lovecraft.Client.Resources;

namespace Lovecraft.Client.Debug
{
  public class ResourceDebugSystem : IEcsRunSystem
  {
    private readonly EcsFilterInject<Inc<PlayerTag, Wood, Stone, Iron, Warpstone>> _playerFilter;
    private readonly EcsCustomInject<DebugDataSo> _debugDataInject = default;

    public void Run(IEcsSystems systems)
    {
      foreach (var entity in _playerFilter.Value)
      {
        ResourceName debugResourceName = _debugDataInject.Value.DebuggedResourceName;
        int resourceAmount = 0;

        switch (debugResourceName)
        {
          case ResourceName.Wood:
            resourceAmount = _playerFilter.Pools.Inc2.Get(entity).WoodCount;
            break;

          case ResourceName.Stone:
            resourceAmount = _playerFilter.Pools.Inc3.Get(entity).StoneCount;
            break;

          case ResourceName.Iron:
            resourceAmount = _playerFilter.Pools.Inc4.Get(entity).IronCount;
            break;

          case ResourceName.Warpstone:
            resourceAmount = _playerFilter.Pools.Inc5.Get(entity).WarpstoneCount;
            break;
        }

        UnityEngine.Debug.Log($"{debugResourceName}: {resourceAmount}");
      }
    }
  }
}


