using System;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Lovecraft.Client.Config;
using Lovecraft.Client.GlobalMap;
using UnityEngine;

namespace Lovecraft.Client.Input.GlobalMap
{
  public class ClickRaycastSystem : IEcsRunSystem
  {
    private readonly int _layerMask = LayerMask.GetMask("Clickable");
    private readonly EcsFilterInject<Inc<GlobalMapInput>> _globalMapInputFilter;
    private readonly EcsFilterInject<Inc<Cell>, Exc<Click>> _cellFilter;
    private readonly EcsCustomInject<CellService> _cellService = default;
    private readonly EcsCustomInject<ConfigurationSo> _configuration;
    private readonly EcsPoolInject<Click> _clickPool = default;

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
          
          Physics2D.RaycastNonAlloc(clickWorldPosition, 
                                    Camera.main.transform.forward, 
                                    _raycastHits, 
                                    _configuration.Value.ClickRaycastMaxDistance, 
                                    _layerMask);

          foreach (var hit in _raycastHits) 
          {
            if (hit.collider != null)
            {
              ref var hitCell = ref _cellService.Value.FindCell(hit.collider.transform);
              foreach (var cellEntity in _cellFilter.Value)
              {
                ref var cell = ref _cellFilter.Pools.Inc1.Get(cellEntity);
                if (cell.Equals(hitCell))
                {
                  _clickPool.Value.Add(cellEntity);
                  break;
                }
              }
            }
          }
        }
      }
    }
  }
}

