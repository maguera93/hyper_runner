using MAG.Utils;

public class GameModel : IModel
{
    public int Level { get; set; }
    public int Gems { get; set; }
    public bool Win { get; set; }

    public GameModel()
    {
        Gems = 0;
        Win = false;
    }

    public void EndGame(bool win, int gems)
    {
        if (win)
            AddGems(gems);
    }

    private void AddGems(int gems)
    {
        Gems += gems; 
    }
}
