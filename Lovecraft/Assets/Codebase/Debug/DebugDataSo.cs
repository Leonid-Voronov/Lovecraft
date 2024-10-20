using UnityEngine;

namespace Lovecraft.Client.Debug
{
  [CreateAssetMenu(fileName = "DebugData", menuName = "ScriptableObjects/DebugData", order = 1)]
  public class DebugDataSo : ScriptableObject
  {
    [field: SerializeField] public ResourceName DebuggedResourceName { get; private set; }
  }
}

