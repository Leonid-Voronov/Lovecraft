using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Lovecraft.Client.GameplayCommon;
using Lovecraft.Client.Infrastructure;

namespace Lovecraft.Client.GlobalMap
{
  public class PlayerInitSystem : IEcsInitSystem
  {
    private EcsWorldInject _ecsWorld = Idents.Worlds.World;

    private EcsPoolInject<PlayerTag> _playerTagPool = default;

    public void Init(IEcsSystems systems)
    {
      var world = _ecsWorld.Value;
      var playerEntity = world.NewEntity();

      _playerTagPool.Value.Add(playerEntity);
    }
  }
}