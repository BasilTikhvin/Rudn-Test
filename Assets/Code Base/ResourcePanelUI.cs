using TMPro;
using UnityEngine;

namespace RudnTest
{
    public class ResourcePanelUI : MonoBehaviour
    {
        [SerializeField] DumpSite _dumpSite;
        [SerializeField] TextMeshProUGUI _resourceText;

        private void OnEnable()
        {
            _dumpSite.ResourceChange += ResourceChange;
        }

        private void OnDestroy()
        {
            _dumpSite.ResourceChange -= ResourceChange;
        }

        private void ResourceChange(int amount)
        {
            _resourceText.text = amount.ToString();
        }
    }
}
