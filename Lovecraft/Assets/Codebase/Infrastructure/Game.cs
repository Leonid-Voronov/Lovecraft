using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Lovecraft.Client.Config;
using Lovecraft.Client.GlobalMap;
using Lovecraft.Client.Input;
using Lovecraft.Client.Input.GlobalMap;
using UnityEngine;

namespace Lovecraft.Client.Infrastructure
{
  sealed class Game : MonoBehaviour
  {
    [SerializeField] private SceneData _sceneData;
    [SerializeField] private ConfigurationSo _configuration;
    private EcsSystems _systems;
    private CellService _cellService;

    private void Start()
    {
      var world = new EcsWorld();
      _systems = new EcsSystems(world);
      _cellService = new CellService(_sceneData);

      _systems
#if UNITY_EDITOR
          .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
          .Add(new CellsInitSystem())
          .Add(new InputInitializationSystem())
          .Add(new GlobalMapInputInitializationSystem())
          .Add(new GlobalMapInputSystem())
          .Add(new ClickRaycastSystem())
          .AddWorld(world, Idents.Worlds.World)
          .Inject(_sceneData)
          .Inject(_cellService)
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
