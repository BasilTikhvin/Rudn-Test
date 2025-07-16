using UnityEngine;
using Zenject;

namespace RudnTest
{
    public class LevelEndPanelUI : MonoBehaviour
    {
        [SerializeField] GameObject _levelEndPanel;

        LevelController _levelController;

        [Inject]
        public void Construct(LevelController levelController)
        {
            _levelController = levelController;
        }

        private void OnEnable()
        {
            _levelController.OnLevelPassed += OnLevelPassed;

        }

        private void Start()
        {
            _levelEndPanel.SetActive(false);
        }

        private void OnDestroy()
        {
            _levelController.OnLevelPassed -= OnLevelPassed;
        }

        private void OnLevelPassed()
        {
            _levelEndPanel.SetActive(true);
        }
    }
}
