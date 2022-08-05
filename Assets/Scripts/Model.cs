using System;
using System.Collections.Generic;

public enum GameType
{
    Simple,
    Advanced,
    Single,
    Multi
}
public enum CellState
{
    Clear,
    Missed,
    Damaged,
    Destroyed
}

public class Model
{
    private int width;
    private int height;
    
    private Dictionary<int, CellData> field;
    private Dictionary<int, Artillery> playerArtilleries;
    private Dictionary<int, Artillery> enemyArtilleries;

    public Action<int, CellState> PlayerCellStateChanged;
    public Action<int, CellState> EnemyCellStateChanged;

    public Model()
    {
        Init();
    }
    public void Init()
    {
        width = GameSettings.Instance.WidthField;
        height = GameSettings.Instance.HeightField;
        
        playerArtilleries = new Dictionary<int, Artillery>();
        enemyArtilleries = new Dictionary<int, Artillery>();
        field = new Dictionary<int, CellData>();
        
        CreateArti();
        CreateField();
    }
    private void CreateField()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var id = i == 0 ? j : i * 100 + j; 
                field.Add(id, new CellData());
            }
        }
    }

    private void CreateArti()
    {                                                                 // 1 - index 1cell arty - 4 amount = 1(1-4)
        int X = 4;                                                    // 2 - index 2cell arty - 3 amount = 2(1-3)
        for (int i = 1; i <= 4 ; i++)                                 // 3 - index 3cell arty - 2 amount = 3(1-2)
        {                                                             // 4 - index 4cell arty - 1 amount = 41
            for (int j = 1; j <= X; j++)
            {
                int id = i*10 + j;
                playerArtilleries.Add(id, new Artillery(id));
                enemyArtilleries.Add(id, new Artillery(id));
                if (j == X)
                {
                    X --;
                }
            }
        }
    }
    public void ClearDataForNewGame()
    {
        //Clear Fields
        foreach (var cellData in field)
        {
            cellData.Value.Artillery = null;
            PlayerCellStateChanged?.Invoke(cellData.Key, CellState.Clear);
            EnemyCellStateChanged?.Invoke(cellData.Key, CellState.Clear);
            
        }
        
        //Clear Artilleries
        foreach (var playerArtillery in playerArtilleries)
        {
            playerArtillery.Value.ClearArtyPositions();
        }

        foreach (var enemyArtillery in enemyArtilleries)
        {
            enemyArtillery.Value.ClearArtyPositions();
        }
        
    }

    public void SetPlayerCellState(int id, CellState state)
    {
        field[id].PlayerCellState = state;
        PlayerCellStateChanged?.Invoke(id, state);
    }

    public void SetEnemyCellState(int id, CellState state)
    {
        field[id].EnemyCellState = state;
        EnemyCellStateChanged?.Invoke(id, state);
    }

    public CellState GetPlayerCellState(int id)
    {
        return field[id].PlayerCellState;
    }
    public CellState GetEnemyCellState(int id)
    {
        return field[id].EnemyCellState;
    }

    public Artillery GetArtilleryFromCell(int id)
    {
        if (field[id].Artillery != null)
        {
            return field[id].Artillery;
        }

        return null;
    }
}
