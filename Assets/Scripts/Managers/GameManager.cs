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

    // Register
    private void RegisterMovesets()
    {
        // temp to test things before animations are shipped
        new SwordMoveset(null);
        new BowMoveset(null);
    }

    private void RegisterWeapons()
    {
        // temp to test things before animations are shipped
        new Weapon("Default Sword", WeaponNames.DefaultSword, Moveset.Movesets[MovesetNames.Sword], null, 5f, typeof(Weapon));
        new Weapon("Default Bow", WeaponNames.DefaultBow, Moveset.Movesets[MovesetNames.Bow], null, 5f, typeof(Weapon));
    }

    // Misc
    private void Init()
    {
        RegisterMovesets();
        RegisterWeapons();

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
