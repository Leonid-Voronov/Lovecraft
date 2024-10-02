using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Lovecraft.Client.Input
{
  sealed class GlobalMapInputSystem : IEcsRunSystem
  {
    private readonly EcsFilterInject<Inc<PlayerInputControls>> _playerControls;

    public void Run(IEcsSystems systems)
    {
      foreach (var entity in _playerControls.Value) 
      {
        ref var controls = ref _playerControls.Pools.Inc1.Get(entity);
      }
    }
  }
}

