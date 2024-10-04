using System;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Lovecraft.Client.GlobalMap;
using UnityEngine;

namespace Lovecraft.Client.Input.GlobalMap
{
  public class ClickRaycastSystem : IEcsRunSystem
  {
    private readonly int _layerMask = LayerMask.GetMask("Clickable");
    private readonly EcsFilterInject<Inc<GlobalMapInput>> _globalMapInputFilter;
    private readonly EcsCustomInject<CellService> _cellService = default;

    private RaycastHit2D[] _raycastHits = new RaycastHit2D[10];

    public void Run(IEcsSystems systems)
    {
      foreach (var entity in _globalMapInputFilter.Value)
      {
        ref var globalMapInput = ref _globalMapInputFilter.Pools.Inc1.Get(entity);

        if (globalMapInput.Click)
        {
          Vector2 clickWorldPosition = Camera.main.ScreenToWorldPoint(globalMapInput.MousePosition);
          Array.Clear(_raycastHits, 0, _raycastHits.Length);
          
          Physics2D.RaycastNonAlloc(clickWorldPosition, Camera.main.transform.forward, _raycastHits, 100f, _layerMask);

          foreach (var hit in _raycastHits) 
          {
            if (hit.collider != null)
            {
              ref var cell = ref _cellService.Value.FindCell(hit.collider.transform);
              Debug.Log(cell.Transform.gameObject.name);
            }
          }
        }
      }
    }
  }
}

