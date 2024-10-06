using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Lovecraft.Client.GlobalMap
{
  public class BuildGuiOpenSystem : IEcsRunSystem
  {
    private readonly EcsFilterInject<Inc<BuildCell, Click, Cell>> _clickedCellsFilter = default;

    public void Run(IEcsSystems systems)
    {
      foreach (var entity in _clickedCellsFilter.Value) 
      {
        ref var cell = ref _clickedCellsFilter.Pools.Inc3.Get(entity);

        //Open gui

        _clickedCellsFilter.Pools.Inc2.Del(entity);
      }
    }
  }
}

