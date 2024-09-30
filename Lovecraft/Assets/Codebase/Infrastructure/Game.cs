using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client
{
  sealed class Game : MonoBehaviour
  {
    [SerializeField] SceneData _sceneData;
    [SerializeField] Configuration _configuration;
    EcsSystems _systems;

    void Start()
    {
      var world = new EcsWorld();
      _systems = new EcsSystems(world);

      _systems
#if UNITY_EDITOR
          .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
          .Inject(_sceneData)
          .Init();
    }

    void Update()
    {
      _systems?.Run();
    }

    void OnDestroy()
    {
      _systems?.Destroy();
      _systems?.GetWorld()?.Destroy();
      _systems = null;
    }
  }
}
