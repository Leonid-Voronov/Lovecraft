using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Lovecraft.Client.Config;
using Lovecraft.Client.GameplayCommon;

namespace Lovecraft.Client.Resources
{
  public class ResourcesInitSystem : IEcsInitSystem
  {
    private readonly EcsFilterInject<Inc<ConflictSide>> _conflictSideFilter = default;
    private readonly EcsCustomInject<ConfigurationSo> _configurationInject = default;

    private readonly EcsPoolInject<Wood> _woodPool = default;
    private readonly EcsPoolInject<Stone> _stonePool = default;
    private readonly EcsPoolInject<Iron> _ironPool = default;
    private readonly EcsPoolInject<Warpstone> _warpStonePool = default;

    public void Init(IEcsSystems systems)
    {
      ConfigurationSo configuration = _configurationInject.Value;

      foreach (var entity in _conflictSideFilter.Value) 
      {
        ref var wood = ref _woodPool.Value.Add(entity);
        ref var stone = ref _stonePool.Value.Add(entity);
        ref var iron = ref _ironPool.Value.Add(entity);
        ref var warpStone = ref _warpStonePool.Value.Add(entity);

        wood.WoodCount = configuration.StartWoodAmount;
        stone.StoneCount = configuration.StartStoneAmount;
        iron.IronCount = configuration.StartIronAmount;
        warpStone.WarpstoneCount = configuration.StartWarpstoneAmount;
      }
    }
  }
}

