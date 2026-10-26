using UnityEngine;

public class Player: MonoBehaviour
{
    // Field
    [SerializeField] private string _characterName;
    [SerializeField] private float _maxHP;
    [SerializeField] private float _hp;

    private Weapon _weapon;

    // Functions
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
                //_hp = 0f;
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
