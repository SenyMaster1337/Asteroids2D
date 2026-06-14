using Code.Core.Configs.Player;

namespace Code.Core.Configs.Enemies.AlienShip
{
    public class AlienShipConfig : IConfigValidate
    {
        public PhysicsConfig Physics;
        public AlienShipFollowerConfig Follower;

        public void Validate()
        {
            Physics.Validate();
            Follower.Validate();
        }
    }
}