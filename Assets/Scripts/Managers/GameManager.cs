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

    public int RollWhiteDice()
    {
        // animation
        return Random.Range(1, 6);
    }

    public int RollBlackDice()
    {
        // animation
        return Random.Range(1, 6);
    }
}
