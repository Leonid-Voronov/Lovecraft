using UnityEngine;

namespace Lovecraft.Client.Config
{
  [CreateAssetMenu(fileName = "Configuration", menuName = "ScriptableObjects/Configuration", order = 1)]
  sealed class ConfigurationSo : ScriptableObject
  {
    [field: SerializeField] public float ClickRaycastMaxDistance {  get; private set; }

    [field: Header("Start Player Resources")]
    [field: SerializeField] public int StartWoodAmount {  get; private set; }
    [field: SerializeField] public int StartStoneAmount {  get; private set; }
    [field: SerializeField] public int StartIronAmount {  get; private set; }
    [field: SerializeField] public int StartWarpstoneAmount {  get; private set; }
  }
}
