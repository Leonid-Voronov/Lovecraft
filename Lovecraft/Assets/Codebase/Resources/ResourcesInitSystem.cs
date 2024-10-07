using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Lovecraft.Client.GameplayCommon;

namespace Lovecraft.Client.Resources
{
  public class ResourcesInitSystem : IEcsInitSystem
  {
    private readonly EcsFilterInject<Inc<ConflictSide>> _conflictSideFilter = default;

    private readonly EcsPoolInject<Wood> _woodPool = default;
    private readonly EcsPoolInject<Stone> _stonePool = default;
    private readonly EcsPoolInject<Iron> _ironPool = default;
    private readonly EcsPoolInject<Warpstone> _warpStonePool = default;

    public void Init(IEcsSystems systems)
    {
      foreach (var entity in _conflictSideFilter.Value) 
      {
        _woodPool.Value.Add(entity);
        _stonePool.Value.Add(entity);
        _ironPool.Value.Add(entity);
        _warpStonePool.Value.Add(entity);
      }
    }
  }
}

