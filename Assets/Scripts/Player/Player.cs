using UnityEngine;
using System.Collections.Generic;

public class Player: MonoBehaviour
{
    // Field
    [SerializeField] private string _characterName;
    [SerializeField] private float _maxHP;
    [SerializeField] private float _hp;

    private Weapon _weapon;

    public Dictionary<int, Weapon> Loadout = new Dictionary<int, Weapon>();

    public delegate void HPChanged(float newHP);
    public static event HPChanged OnHPChanged;

    // Functions
    public void Init()
    {
        // assign initial loadout
    }

    private void Die()
    {
        // todo
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
}
