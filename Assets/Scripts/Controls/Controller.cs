using DG.Tweening;
using UnityEngine;

public class Controller
{
    public View View { get; }
    public Model Model{ get; }
    public BattleFieldView BattleFieldView { get; }
    private ShootController shootController;
    
    public Controller(View view, BattleFieldView fieldView)
    {
        Model = new Model();
        View = view;
        BattleFieldView = fieldView;
        shootController = new ShootController(BattleFieldView, Model);
        
        Model.EnemyCellStateChanged += fieldView.SetImageOnEnemyField;
        Model.PlayerCellStateChanged += fieldView.SetImageOnPlayerField;

        View.StartGameAction += PrepareGame;
        View.EndGameAction += EndGame;
        
        BattleFieldView.ShootMarkAction += shootController.SetShootingCrossPos;
    }

    private void PrepareGame(GameType singleMultiType, GameType simpleAdvType)
    {
        GameSettings.Instance.SetFieldSize(simpleAdvType);
        BattleFieldView.PrepareFields();
        Model.ClearDataForNewGame();
        DOVirtual.DelayedCall(0.3f, ()=>BattleFieldView.BattleFieldActiveOnOff());

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
        BattleFieldView.BattleFieldActiveOnOff();
    }
}
