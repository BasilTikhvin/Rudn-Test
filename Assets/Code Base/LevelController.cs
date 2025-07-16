using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace RudnTest
{
    public class LevelController : MonoBehaviour
    {
        public event UnityAction OnLevelPassed;

        [SerializeField] int _resourceRequired;

        DumpSite _dumpSite;

        [Inject]
        public void Construct(DumpSite dumpSite)
        {
            _dumpSite = dumpSite;
        }

        private void OnEnable()
        {
            _dumpSite.OnResourceAmountChange += OnResourceAmountChange;

            Cursor.visible = false;
        }

        private void OnDestroy()
        {
            _dumpSite.OnResourceAmountChange -= OnResourceAmountChange;
        }

        private void OnResourceAmountChange(int amount)
        {
            if (amount >= _resourceRequired)
                OnLevelPassed?.Invoke();
        }
    }
}
