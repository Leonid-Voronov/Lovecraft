using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Lovecraft.Client.Input.GlobalMap
{
  public class GlobalMapInputInitializationSystem : IEcsInitSystem
  {
    private readonly EcsFilterInject<Inc<PlayerInputControls>> _playerControlsFilter;
    private EcsPoolInject<GlobalMapInput> _globalMapInputPool = default;

    public void Init(IEcsSystems systems)
    {
      foreach (var entity in _playerControlsFilter.Value)
      {
        ref var globalMapInput = ref _globalMapInputPool.Value.Add(entity);
      }
    }
  }
}

