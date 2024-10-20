using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Lovecraft.Client.Input.GlobalMap;

namespace Lovecraft.Client.GameplayCommon
{
  public class ConflictSidesInitSystem : IEcsInitSystem
  {
    private readonly EcsFilterInject<Inc<PlayerTag>> _playerFilter = default;
    private readonly EcsPoolInject<ConflictSide> _conflictSidePool = default;

    public void Init(IEcsSystems systems)
    {
      foreach (var entity in _playerFilter.Value)
      {
        _conflictSidePool.Value.Add(entity);
      }
    }
  }
}

