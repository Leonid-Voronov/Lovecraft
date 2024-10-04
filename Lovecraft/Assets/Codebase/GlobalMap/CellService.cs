using Lovecraft.Client.Infrastructure;
using UnityEngine;

namespace Lovecraft.Client.GlobalMap
{
  sealed class CellService
  {
    private readonly Cell[] _cells;

    private int _currentIndex = 0;

    public CellService(SceneData sceneData)
    {
      _cells = new Cell[sceneData.Cells.Count];
    }

    public ref Cell FindCell(Transform transform)
    {
      for (int i = 0; i < _cells.Length; i++) 
      {
        if (_cells[i].Transform == transform)
        {
          return ref _cells[i];
        }
      }

      return ref _cells[0];
    }

    public void AddCell(ref Cell cell)
    {
      _cells[_currentIndex] = cell;
      _currentIndex++;
    }
  }
}

