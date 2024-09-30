using Leopotam.EcsLite;
using UnityEngine;

namespace Lovecraft.Client.Input
{
  sealed class InputInitializationSystem : IEcsInitSystem
  {
    private EcsWorld _ecsWorld;

    public void Init(IEcsSystems systems)
    {
      Debug.Log(_ecsWorld != null); //Still doesn't inject
      Controls controls = new Controls();
    }
  }
}

