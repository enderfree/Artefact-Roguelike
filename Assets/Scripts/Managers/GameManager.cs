using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Field
    [SerializeField] private Player _playerStats;
    [SerializeField] private GUIManager _guiManager;

    public int WhiteDice;

    // MonoBehavior
    private void Awake()
    {
        Init();
    }

    // My Functions
    private void Init()
    {
        WhiteDice = RollWhiteDice();
        _playerStats.Init();
        _guiManager.Init();
    }

    /// <summary>
    /// this returns 6 numbers and can be used raw as indexes
    /// </summary>
    /// <returns>0, 1, 2, 3, 4 or 5</returns>
    public int Roll1d6()
    {
        return Random.Range(0, 5); 
    }

    /// <summary>
    /// Handles rolling the white dice
    /// </summary>
    /// <returns>0, 1, 2, 3, 4 or 5</returns>
    public int RollWhiteDice()
    {
        // animation
        return Roll1d6();
    }

    /// <summary>
    /// Handles rolling the black dice
    /// </summary>
    /// <returns>0, 1, 2, 3, 4 or 5</returns>
    public int RollBlackDice()
    {
        // animation
        return Roll1d6();
    }
}
