using MVVM;
using TMPro;
using UnityEngine;

namespace Lovecraft.Client.Ui.Placeholders
{
  public sealed class ResourcePlaceholderView : MonoBehaviour
  {
    [Data("Resource")]
    [SerializeField] public TMP_Text _resourceText;
  }
}


