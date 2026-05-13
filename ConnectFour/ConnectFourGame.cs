namespace ConnectFour;

public class ConnectFourGame(Player player) : IConnectFour
{
    public Player GetPlayerAt(int row, int col)
    {
        throw new NotImplementedException();
    }

    public Player PlayerOnTurn { get; }
    public bool IsGameOver { get; }
    public Player Winner { get; }
    public void Reset(Player playerOnTurn)
    {
        throw new NotImplementedException();
    }

    public void Drop(int col)
    {
        throw new NotImplementedException();
    }
}