using UnityEngine;
using Zenject;

namespace RudnTest
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] int _resourceRequired;

        DumpSite _dumpSite;
        Character _playerCharacter;

        [Inject]
        public void Construct(DumpSite dumpSite, Character playerCharacter)
        {
            _dumpSite = dumpSite;
            _playerCharacter = playerCharacter;
        }

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
                _playerCharacter.CharacterInput.DisableInput();
        }
    }
}
