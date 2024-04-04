using Zenject;
//https://github.com/modesttree/Zenject/blob/master/Documentation/Signals.md
//https://github.com/modesttree/Zenject/blob/master/Documentation/CheatSheet.md
public class SceneInstaller : MonoInstaller<SceneInstaller>
{
    readonly SignalBus _signalBus;
   public override void InstallBindings()
       {
           SignalBusInstaller.Install(Container);
           Container.Bind<SceneInstaller>().AsSingle();
           
           /*Container.Bind<PlayerController>().FromInstance(_playerController).AsSingle();
           Container.Bind<AudioManager>().FromInstance(_audioManager).AsSingle();
           Container.Bind<UIManager>().FromInstance(_gameplayUIManager).AsSingle();
        
           Container.Bind<CoreSignals>().AsSingle();
           Container.Bind<TeleportsManager>().AsSingle();
           Container.Bind<WorldObjectsContainer>().AsSingle();
           Container.Bind<PlayerInventoryManager>().AsSingle();

           ///SIGNALS >>>>>>>>>>>>>>>>
           Container.DeclareSignal<CoreSignals.DoorWasOpenedSignal>();
           Container.DeclareSignal<CoreSignals.PlayerWasSightedSignal>();
           Container.DeclareSignal<CoreSignals.PlayerSightWasLostSignal>();
           Container.DeclareSignal<CoreSignals.PlayerTriggeredTeleportZoneSignal>();
           Container.DeclareSignal<CoreSignals.OnTeleportApprovedSignal>();
           Container.DeclareSignal<CoreSignals.OnLayoutStateUpdateSignal>();
           Container.DeclareSignal<CoreSignals.OnAffectFlashLightSignal>();
           Container.DeclareSignal<CoreSignals.OverwriteMouseLookSensitivitySignal>();
           Container.DeclareSignal<CoreSignals.SetCursorSignal>();*/
       }
}
