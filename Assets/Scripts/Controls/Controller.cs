using DG.Tweening;
using UI;

namespace Controls
{
    public class Controller
    {
        public View View { get; }
        public Model Model{ get; }
        private BattleFieldView _battleFieldView;
        private PlayerFieldHandler _playerFieldHandler;
        private ShootController _shootController;
    
        public Controller(View view, BattleFieldView fieldView)
        {
            Model = new Model();
            View = view;
            _battleFieldView = fieldView;
            _shootController = new ShootController(_battleFieldView, Model);
        
            Model.EnemyCellStateChanged += fieldView.SetImageOnEnemyField;
            Model.PlayerCellStateChanged += fieldView.SetImageOnPlayerField;

            View.StartGameAction += PrepareGame;
            View.EndGameAction += EndGame;
        
            _battleFieldView.ShootMarkAction += _shootController.SetShootingCrossPos;
        }

        private void PrepareGame(GameType singleMultiType, GameType simpleAdvType)
        {
            GameSettings.Instance.SetFieldSize(simpleAdvType);
            _battleFieldView.PrepareFields();
            Model.ClearDataForNewGame();
            DOVirtual.DelayedCall(0.3f, ()=>_battleFieldView.BattleFieldActiveOnOff());

        }

        private void StartSingleGame()
        {
            // To Do
        }

        private void StartMultiGame()
        {
            //To Do
        }
        private void EndGame()
        {
            _battleFieldView.BattleFieldActiveOnOff();
        }
    }
}
