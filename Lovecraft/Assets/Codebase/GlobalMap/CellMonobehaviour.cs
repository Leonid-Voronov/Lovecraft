using UnityEngine;

namespace Lovecraft.Client.GlobalMap
{
  public class CellMonobehaviour : MonoBehaviour
  {
    [field: SerializeField] public CellType CellType { get; private set; }
    [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
    public Transform Transform => transform;
  }
}

