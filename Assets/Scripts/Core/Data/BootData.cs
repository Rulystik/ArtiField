namespace Core.Data
{
    public class BootData
    {
        public GameType SingleOrMulti { get; set; }
        public GameType SimpleOrAdvanced { get; set; }
        public BootStateEnum BootState { get; set; }
        public string PlayerName { get; set; }
        public string EnemyName { get; set; }

        public BootData()
        {
            PlayerName = "Player";
            EnemyName = "Enemy";
            BootState = BootStateEnum.Menu;
        }
    }
}
