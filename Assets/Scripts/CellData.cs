
public class CellData
{
    public Artillery Artillery { get; set;}
    public int ID { get;}
    public CellState PlayerCellState { get; set; }
    public CellState EnemyCellState { get; set; }

    public CellData(int id)
    {
        Artillery = null;
        ID = id;
        PlayerCellState = CellState.Clear;
        EnemyCellState = CellState.Clear;
    }

}
