using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Lovecraft.Client.Infrastructure;
using UnityEngine;

namespace Lovecraft.Client.Input
{
  sealed class InputInitializationSystem : IEcsInitSystem
  {
    private EcsWorldInject _ecsWorld = Idents.Worlds.World;

    private EcsPoolInject<PlayerInputControls> _playerInputControlsPool = default;

    public void Init(IEcsSystems systems)
    {
      var world = _ecsWorld.Value;
      var controlsEntity = world.NewEntity();
      Controls controls = new Controls();
      controls.Enable();

      ref var playerInputControls = ref _playerInputControlsPool.Value.Add(controlsEntity);
      playerInputControls.Controls = controls;
    }
  }
}

