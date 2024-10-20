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
    private readonly EcsPoolInject<Cell> _cellPool = default;
    private readonly EcsPoolInject<BuildCell> _buildCellPool = default;
    private readonly EcsPoolInject<BuildingCell> _buildingCellPool = default;

    public void Init(IEcsSystems systems)
    {
      SceneData sceneData = _sceneDataInject.Value;

      foreach (var cellMono in sceneData.Cells)
      {
        var cellEntity = _ecsWorld.Value.NewEntity();
        ref var cell = ref _cellPool.Value.Add(cellEntity);

        cell.SpriteRenderer = cellMono.SpriteRenderer;
        cell.Transform = cellMono.Transform;

        AddTypeComponent(cellMono.CellType, cellEntity);

        _cellService.Value.AddCell(ref cell);
      }
    }

    private void AddTypeComponent(CellType type, int cellEntity)
    {
      switch (type) 
      {
        case CellType.Empty:
          _buildCellPool.Value.Add(cellEntity);
          break;

        case CellType.Building:
          _buildingCellPool.Value.Add(cellEntity);
          break;

        default:
          break;
      }
    }
  }
}

