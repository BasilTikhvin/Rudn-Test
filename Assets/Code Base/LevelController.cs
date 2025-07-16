using UnityEngine;

namespace RudnTest
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] DumpSite _dumpSite;
        [SerializeField] int _resourceRequired;
        [SerializeField] Character _character;

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
            if (amount >= _resourceRequired)
                _character.CharacterInput.DisableInput();
        }
    }
}
