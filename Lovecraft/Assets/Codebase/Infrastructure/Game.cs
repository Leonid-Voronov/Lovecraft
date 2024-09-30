using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Lovecraft.Client.Config;
using Lovecraft.Client.Input;
using UnityEngine;

namespace Lovecraft.Client.Infrastructure
{
  sealed class Game : MonoBehaviour
  {
    [SerializeField] private SceneData _sceneData;
    [SerializeField] private ConfigurationSo _configuration;
    private EcsSystems _systems;

    private void Start()
    {
      var world = new EcsWorld();
      _systems = new EcsSystems(world);

      _systems
#if UNITY_EDITOR
          .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
          .Add(new InputInitializationSystem())
          .AddWorld(world, "World")
          .Inject(_sceneData)
          .Init();
    }

    private void Update()
    {
      _systems?.Run();
    }

    private void OnDestroy()
    {
      _systems?.Destroy();
      _systems?.GetWorld()?.Destroy();
      _systems = null;
    }
  }
}
