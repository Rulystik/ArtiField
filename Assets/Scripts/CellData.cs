
public class CellData
{
    public Artillery Artillery { get; set; }
    public CellState PlayerCellState { get; set; }
    public CellState EnemyCellState { get; set; }

    public CellData()
    {
        Artillery = null;
        PlayerCellState = CellState.Clear;
        EnemyCellState = CellState.Clear;
    }

}
