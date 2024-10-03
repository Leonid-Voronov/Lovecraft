using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using System.Collections.Generic;
using UnityEngine;

namespace Lovecraft.Client.Input.GlobalMap
{
  public class ClickRaycastSystem : IEcsRunSystem
  {
    private readonly int _layerMask = LayerMask.GetMask("Clickable");
    private readonly EcsFilterInject<Inc<GlobalMapInput>> _globalMapInputFilter;

    private RaycastHit2D[] _raycastHits = new RaycastHit2D[10]; 

    public void Run(IEcsSystems systems)
    {
      foreach (var entity in _globalMapInputFilter.Value) 
      {
        ref var globalMapInput = ref _globalMapInputFilter.Pools.Inc1.Get(entity);

        if (globalMapInput.Click)
        {
          Vector2 clickWorldPosition = Camera.main.ScreenToWorldPoint(globalMapInput.MousePosition);

          Physics2D.RaycastNonAlloc(clickWorldPosition, Camera.main.transform.forward, _raycastHits, 1000f, _layerMask);

          foreach (var hit in _raycastHits) 
          {
            if (hit.collider != null)
            {
              Debug.Log(hit.collider);
            }
          }
        }
      }
    }
  }
}

