using Rocket.API;

namespace Stay24
{
    public class Configuration : IRocketPluginConfiguration
    {
        public bool Enabled;
        public bool RevertOnUnload;
        public byte RealMaxPlayer;
        public byte FakeMaxPlayer;

        public void LoadDefaults()
        {
            Enabled = true;
            RevertOnUnload = true;
            RealMaxPlayer = 24;
            FakeMaxPlayer = 48;
        }
    }
}
