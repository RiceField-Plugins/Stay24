using Rocket.Core.Plugins;
using SDG.Unturned;
using Steamworks;
using Logger = Rocket.Core.Logging.Logger;

namespace Stay24
{
    public class Plugin : RocketPlugin<Configuration>
    {
        public Plugin Inst;
        public Configuration Conf;
        private byte m_OriginalMaxPlayer;

        protected override void Load()
        {
            Inst = this;
            Conf = Configuration.Instance;
            if (Conf.Enabled)
            {
                m_OriginalMaxPlayer = Provider.maxPlayers;
                if (Level.isLoaded)
                    EditMaxPlayer();

                Level.onPostLevelLoaded += OnPostLevelLoaded;
            }
            else
                Logger.LogError("[Stay24] Plugin: DISABLED");

            Logger.LogWarning("[Stay24] Plugin loaded successfully!");
            Logger.LogWarning("[Stay24] Stay24 v1.0.0");
            Logger.LogWarning("[Stay24] Made with 'rice' by RiceField Plugins!");
        }

        protected override void Unload()
        {
            if (Conf.Enabled)
            {
                if (Conf.RevertOnUnload)
                    RevertMaxPlayer();

                Level.onPostLevelLoaded -= OnPostLevelLoaded;
            }

            Inst = null;
            Conf = null;

            Logger.LogWarning("[Stay24] Plugin unloaded successfully!");
        }

        private void OnPostLevelLoaded(int a)
        {
            EditMaxPlayer();
        }

        private void EditMaxPlayer()
        {
            Provider.maxPlayers = Conf.RealMaxPlayer;
            SteamGameServer.SetMaxPlayerCount(Conf.FakeMaxPlayer);
        }

        private void RevertMaxPlayer()
        {
            Provider.maxPlayers = m_OriginalMaxPlayer;
            SteamGameServer.SetMaxPlayerCount(m_OriginalMaxPlayer);
        }
    }
}