using UnityEngine;
using System.Collections.Generic;

public class Player: MonoBehaviour, IBlessable
{
    // Field
    [SerializeField] private string _characterName;
    [SerializeField] private float _maxHP;
    [SerializeField] private float _hp;

    private Weapon _weapon;

    // Face is implied by order in List
    private List<List<BlessingEffect>> _blessingPerFace = new List<List<BlessingEffect>>();

    // Face is implied by order in List
    public List<Weapon> Loadout = new List<Weapon>();

    public delegate void HPChanged(float newHP);
    public static event HPChanged OnHPChanged;

    // Functions
    public void Init()
    {
        // assign initial loadout
        // assing initial weapon based on WhiteDice
    }

    private void Die()
    {
        // todo
    }

    public static List<List<BlessingEffect>> GetEmptyLoadout()
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
            _weapon = value;
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
}
