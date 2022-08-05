using DG.Tweening;
using Random = UnityEngine.Random;

public class ShootController
{
    private BattleFieldView BattleFieldView { get; }
    private Model Model { get; }
    private int? prevCellId;
    private int targetId;


    public ShootController(BattleFieldView fieldView, Model model)
    {
        BattleFieldView = fieldView;
        Model = model;
        BattleFieldView.ShootButtonDownAction += Shoot;
        BattleFieldView.EnemyFieldOnPosAction += SetShootingCrossRandomPos;
    }

    private void SetShootingCrossRandomPos()
    {
        int x = Random.Range(0, GameSettings.Instance.WidthField - 1);
        int y = Random.Range(0, GameSettings.Instance.HeightField - 1);
        int idPos = x == 0 ? y : x * 100 + y;

        if (Model.GetEnemyCellState(idPos) == CellState.Clear)
        {
            prevCellId = null;
            SetShootingCrossPos(idPos);
        }
        else
        {
            SetShootingCrossRandomPos();
        }
    }

    public void SetShootingCrossPos(int id)
    {
        if (Model.GetEnemyCellState(id) == CellState.Clear)
        {
            var enemyTile =  BattleFieldView.enemyViewObjects[id];
            var sprite = BattleFieldView.GetCrossImage();
            enemyTile.SetStateIcon(sprite);

            targetId = id;

            if (prevCellId != id && prevCellId != null)
            {
                CellState prevCellState = Model.GetEnemyCellState((int)prevCellId);

                if (prevCellState == CellState.Clear)
                {
                    BattleFieldView.enemyViewObjects[(int)prevCellId].DeactivateStateTile();
                }
            }
            prevCellId = id;
        }
        

    }

    public void Shoot()
    {
        // Send CellID for check if get target
        // if got target need to get ID and state arti
        // shoot again or enemy shoot
        
        

        BattleFieldView.enemyViewObjects[targetId].DeactivateStateTile();
        DOVirtual.DelayedCall(1, () => BattleFieldView.SwapFields());

    }

   
}
