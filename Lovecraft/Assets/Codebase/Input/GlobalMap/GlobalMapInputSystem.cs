using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine.InputSystem;

namespace Lovecraft.Client.Input.GlobalMap
{
  sealed class GlobalMapInputSystem : IEcsRunSystem
  {
    private readonly EcsFilterInject<Inc<PlayerInputControls, GlobalMapInput>> _playerControls;
    
    public void Run(IEcsSystems systems)
    {
      foreach (var entity in _playerControls.Value) 
      {
        ref var controls = ref _playerControls.Pools.Inc1.Get(entity);
        ref var input = ref _playerControls.Pools.Inc2.Get(entity);

        input.Click = controls.Controls.GlobalMap.Click.WasPerformedThisFrame();
        input.MousePosition = Mouse.current.position.value;
      }
    }
  }
}

