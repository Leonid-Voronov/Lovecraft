using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Lovecraft.Client.Config;
using Lovecraft.Client.Debug;
using Lovecraft.Client.GameplayCommon;
using Lovecraft.Client.GlobalMap;
using Lovecraft.Client.Input;
using Lovecraft.Client.Input.GlobalMap;
using Lovecraft.Client.Resources;
using Lovecraft.Client.Ui.DataProjection;
using UnityEngine;
using Zenject;

namespace Lovecraft.Client.Infrastructure
{
  sealed class Game : MonoBehaviour
  {
    [SerializeField] private SceneData _sceneData;
    [SerializeField] private ConfigurationSo _configuration;
    [SerializeField] private DebugDataSo _debugData;

    private EcsSystems _systems;
    private CellService _cellService;
    private IGlobalMapProjections _projections;

    [Inject]
    public void Construct(IGlobalMapProjections globalMapProjections) => _projections = globalMapProjections;

    private void Start()
    {
      var world = new EcsWorld();
      _systems = new EcsSystems(world);
      _cellService = new CellService(_sceneData);

      _systems
#if UNITY_EDITOR
          .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
          //.Add(new ResourceDebugSystem())
#endif
          .Add(new PlayerInitSystem())
          .Add(new CellsInitSystem())
          .Add(new InputInitializationSystem())
          .Add(new GlobalMapInputInitializationSystem())
          .Add(new ConflictSidesInitSystem())
          .Add(new ResourcesInitSystem())
          .Add(new ResourcesProjectionSystem())
          .Add(new GlobalMapInputSystem())
          .Add(new ClickRaycastSystem())
          .Add(new BuildGuiOpenSystem())

          .AddWorld(world, Idents.Worlds.World)

          .Inject(_sceneData)
          .Inject(_cellService)
          .Inject(_configuration)
          .Inject(_debugData)
          .Inject(_projections)

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
