using UnityEngine;
using Zenject;

namespace RudnTest
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] LevelController _levelController;
        [SerializeField] Character _playerCharacter;
        [SerializeField] CharacterInput _characterInput;
        [SerializeField] DumpSite _dumpSite;

        public override void InstallBindings()
        {
            Container.Bind<LevelController>().FromInstance(_levelController).AsSingle();
            Container.Bind<Character>().FromInstance(_playerCharacter).AsSingle();
            Container.Bind<CharacterInput>().FromInstance(_characterInput).AsSingle();
            Container.Bind<DumpSite>().FromInstance(_dumpSite).AsSingle();

            Container.Bind<Bag>().FromNew().AsSingle();
        }
    }
}