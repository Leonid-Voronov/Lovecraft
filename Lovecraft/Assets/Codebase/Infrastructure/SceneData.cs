using System.Collections.Generic;
using Lovecraft.Client.GlobalMap;
using UnityEngine;

namespace Lovecraft.Client.Infrastructure
{
  sealed class SceneData : MonoBehaviour
  {
    [field: SerializeField] public List<CellMonobehaviour> Cells { get; private set; } = new ();
  }
}
