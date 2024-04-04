using Zenject;

public class SceneInstaller : MonoInstaller<SceneInstaller>
{
   public override void InstallBindings()
       {
           // Bind your services, controllers, factories, etc. here
   
           // Example binding: Bind<MyService>().FromInstance(_myServicePrefab).AsSingle();
           // Replace MyService with your actual service type and _myServicePrefab with your prefab instance
   
           // Example binding: Container.Bind<IMyInterface>().To<MyImplementation>().AsSingle();
           // Replace IMyInterface with your interface type and MyImplementation with your actual implementation
   
           // You can bind other dependencies as needed
       }
}
