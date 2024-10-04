using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Lovecraft.Client.Infrastructure;

namespace Lovecraft.Client.GlobalMap
{
  public class CellsInitSystem : IEcsInitSystem
  {
    private readonly EcsWorldInject _ecsWorld = Idents.Worlds.World;
    private readonly EcsCustomInject<SceneData> _sceneDataInject = default;
    private readonly EcsCustomInject<CellService> _cellService = default;
    private readonly EcsPoolInject<Cell> _buildCellPool = default;

    public void Init(IEcsSystems systems)
    {
      SceneData sceneData = _sceneDataInject.Value;

      foreach (var cellMono in sceneData.Cells)
      {
        var cellEntity = _ecsWorld.Value.NewEntity();
        ref var cell = ref _buildCellPool.Value.Add(cellEntity);

        cell.SpriteRenderer = cellMono.SpriteRenderer;
        cell.Transform = cellMono.Transform;

        _cellService.Value.AddCell(ref cell);
      }
    }
  }
}

