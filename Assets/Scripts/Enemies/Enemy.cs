using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Fields
    [SerializeField] private EnemyNames _name;
    [SerializeField] private float _maxHP;
    [SerializeField] private float _hp;

    // Getters and Setters
    public virtual EnemyNames Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    public virtual float MaxHP
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

    public virtual float HP
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
        }
    }
}
