using TMPro;
using UnityEngine;
using Zenject;

namespace RudnTest
{
    public class ResourcePanelUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _resourceText;

        DumpSite _dumpSite;

        [Inject]
        public void Construct(DumpSite dumpSite)
        {
            _dumpSite = dumpSite;
        }

        private void OnEnable()
        {
            _dumpSite.OnResourceAmountChange += ResourceChange;
        }

        private void OnDestroy()
        {
            _dumpSite.OnResourceAmountChange -= ResourceChange;
        }

        private void ResourceChange(int amount)
        {
            _resourceText.text = amount.ToString();
        }
    }
}
