using System.Collections.Generic;


public class Artillery
{
    public int ArtyID { get; }
    public List<CellData> ArtyPositions { get; set; }
    public bool IsOnBoard { get; private set; }
    

    public Artillery(int value)
    {
        ArtyID = value;
        ArtyPositions = new List<CellData>();
        IsOnBoard = false;
    }

    public CellState GetArtyState()
    {
        for (int i = 0; i < ArtyPositions.Count; i++)
        {
            if (ArtyPositions[i].PlayerCellState == CellState.Clear)
            {
                return CellState.Damaged;
            }
        }

        return CellState.Destroyed;
    }

    public void AddArtyPositions(List<CellData> cells)
    {
        ArtyPositions = cells;
        IsOnBoard = true;
    }

    public void ClearArtyPositions()
    {
        ArtyPositions.Clear();
        IsOnBoard = false;
    }
}
