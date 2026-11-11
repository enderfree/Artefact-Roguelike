using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Field
    [SerializeField] private RoomManager _roomManager;
    [SerializeField] private WeaponRegisterer _weaponRegisterer;
    [SerializeField] private Player _playerStats;
    [SerializeField] private GUIManager _guiManager;

    private GameObject _activeRoom;

    public int WhiteDice;

    // MonoBehavior
    private void Awake()
    {
        Init();
    }

    // Misc
    private void Init()
    {
        _roomManager.Init();
        _weaponRegisterer.Init();

        WhiteDice = RollWhiteDice();
        _playerStats.Init();
        _guiManager.Init();

        // static for playtest, gonna ranomize the rooms later
        ActiveRoom = _roomManager.RoomPrefabs[RoomNames.Hexagon];
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

    // Getters and Setters
    public GameObject ActiveRoom
    {
        get
        {
            return _activeRoom;
        }
        set
        {
            Destroy(_activeRoom);
            _activeRoom = Instantiate(value);
            _playerStats.transform.position = _activeRoom.GetComponent<Room>().PlayerSpawn.transform.position;
        }
    }
}
