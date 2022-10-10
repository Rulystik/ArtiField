using System;

namespace Core.Data
{
    public class RunTimeData
    {
        private MenuStateEnum _menuState;
        public GameType SingleOrMulti { get; set; }
        public GameType SimpleOrAdvanced { get; set; }
        public BootStateEnum BootState { get; set; }
        public string PlayerName { get; set; }
        public string EnemyName { get; set; }

        public RunTimeData()
        {
            PlayerName = "Player";
            EnemyName = "Enemy";
            BootState = BootStateEnum.Menu;
        }
    }
}
