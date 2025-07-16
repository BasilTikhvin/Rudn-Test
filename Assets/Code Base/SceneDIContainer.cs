using Zenject;

namespace RudnTest
{
    public class SceneDIContainer : MonoInstaller
    {
        public Character PlayerCharacter;
        public DumpSite DumpSite;

        public override void InstallBindings()
        {
            Container.Bind<Character>().FromInstance(PlayerCharacter).AsSingle();
            Container.Bind<DumpSite>().FromInstance(DumpSite).AsSingle();
        }
    }
}