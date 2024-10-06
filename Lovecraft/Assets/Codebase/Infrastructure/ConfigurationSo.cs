using UnityEngine;

namespace Lovecraft.Client.Config
{
  [CreateAssetMenu(fileName = "Configuration", menuName = "ScriptableObjects/Configuration", order = 1)]
  sealed class ConfigurationSo : ScriptableObject
  {
    [field: SerializeField] public float ClickRaycastMaxDistance {  get; private set; }
  }
}
