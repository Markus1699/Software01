namespace Bowling;

public class Game
{
    private readonly int[] _rolls = new int[21];
    private int _currentRoll;



    public void Roll(int pins)
    {
        _rolls[_currentRoll++] = pins;  

    }

    public void Roll(params int[] rolls)
    {
        foreach (var pins in rolls)
        {
            Roll(pins);
        }
    }

    public int GetScore()
    {
        int score = 0;
        int rollIndex = 0;

        for (int frame = 0; frame < 10; frame++)
        {
            
            if (IsStrike(rollIndex))
            {
                score += StrikeBonus(rollIndex);
                rollIndex += 1;
            }
            else if (IsSpare(rollIndex))
            {
                score += SpareBonus(rollIndex);
                rollIndex += 2;
            }
            else
            {
                score += SummeOfPinsInFrame(rollIndex);
                rollIndex += 2;
            }
        }

        return score;
    }

    private  bool IsSpare(int rollIndex) => _rolls[rollIndex] + _rolls[rollIndex + 1] == 10;

    private int SpareBonus(int rollIndex) => 10 + _rolls[rollIndex + 2];
    
    private bool IsStrike(int rollIndex) => _rolls[rollIndex] == 10;
    
    private int StrikeBonus(int rollIndex) => 10 + _rolls[rollIndex + 1] + _rolls[rollIndex + 2];

    private int SummeOfPinsInFrame(int rollIndex) => _rolls[rollIndex] + _rolls[rollIndex + 1];
}