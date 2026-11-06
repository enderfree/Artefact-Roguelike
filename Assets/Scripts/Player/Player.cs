using UnityEngine;
using System.Collections.Generic;

public class Player: MonoBehaviour, IBlessable
{
    // Field
    [Header("External References")]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _weaponHolder;

    [Header("Player Stats")]
    [SerializeField] private string _characterName;
    [SerializeField] private float _maxHP;
    [SerializeField] private float _hp;

    private Weapon _weapon;
    private float _defaultMaxHP;

    // Face is implied by order in List
    private List<List<BlessingEffect>> _blessingPerFace = new List<List<BlessingEffect>>();

    // Face is implied by order in List
    public List<Weapon> Loadout = new List<Weapon>();

    public delegate void HPChanged(float newHP);
    public static event HPChanged OnHPChanged;

    public delegate void MaxHPChanged(float newMaxHP);
    public static event MaxHPChanged OnMaxHPChanged;

    // Functions
    public void Init()
    {
        _defaultMaxHP = _maxHP;
        AssingInitialLoadout();
        _blessingPerFace = GetEmptyBlessingList();
        Weapon = Loadout[_gameManager.WhiteDice];
    }

    private void AssingInitialLoadout()
    {
        Loadout = new List<Weapon>() {
            Weapon.Weapons[WeaponNames.DefaultSword],
            Weapon.Weapons[WeaponNames.DefaultSword],
            Weapon.Weapons[WeaponNames.DefaultSword],
            Weapon.Weapons[WeaponNames.DefaultBow],
            Weapon.Weapons[WeaponNames.DefaultBow],
            Weapon.Weapons[WeaponNames.DefaultBow]
        };
    }

    private void Die()
    {
        // todo
    }

    public static List<List<BlessingEffect>> GetEmptyBlessingList()
    {
        return new List<List<BlessingEffect>>() { 
            new List<BlessingEffect>(),
            new List<BlessingEffect>(),
            new List<BlessingEffect>(),
            new List<BlessingEffect>(),
            new List<BlessingEffect>(),
            new List<BlessingEffect>()
        };
    }

    // Getter and Setter
    public string CharacterName
    {
        get
        {
            return _characterName;
        }
    }

    public float MaxHP
    {
        get
        {
            return _maxHP;
        }
        set
        {
            _maxHP = value;
            OnMaxHPChanged(_maxHP);
        }
    }

    public float HP
    {
        get
        {
            return _hp;
        }
        set
        {
            if (value <= 0f)
            {
                _hp = 0f;
                Die();
            }
            else if (value > MaxHP)
            {
                _hp = MaxHP;
            }
            else
            {
                _hp = value;
            }

            OnHPChanged(_hp);
        }
    }

    public Weapon Weapon
    {
        get
        {
            return _weapon;
        }
        set
        {
            // we need an animation in there
            if (_weapon != null)
            {
                Destroy(_weapon.Prefab);
            }

            _weapon = value;

            Instantiate(_weapon.Prefab, _weaponHolder.transform);
        }
    }

    /// <summary>
    /// First list represents a dice face
    /// Inner list contains all BlessingEffects that trigger on this face
    /// </summary>
    public List<List<BlessingEffect>> BlessingEffects
    {
        get
        {
            return _blessingPerFace;
        }
    }

    public float DefaultMaxHP
    {
        get
        {
            return _defaultMaxHP;
        }
    }
}
