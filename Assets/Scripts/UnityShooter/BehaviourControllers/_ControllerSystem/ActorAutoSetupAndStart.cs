
namespace UnityShooter
{

    public class ActorAutoSetupAndStart : Actor
    {

        protected override void Awake()
        {
            base.Awake();
            Setup();
        }

        private void Start()
        {
            GoOnStage();
        }
    }
}