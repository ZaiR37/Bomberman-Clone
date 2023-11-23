public class GridInfo
{
    private GridSystem<GridInfo> gridSystem;
    private GridPosition gridPosition;
    private LevelObject levelObject;

    public GridInfo(GridSystem<GridInfo> gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
    }

    public void AddObject(LevelObject levelObject) => this.levelObject = levelObject;
    public void RemoveObject()
    {
        levelObject = null;
    }

    public bool HasObject() => levelObject != null;
    public LevelObject GetObject() => levelObject;
}