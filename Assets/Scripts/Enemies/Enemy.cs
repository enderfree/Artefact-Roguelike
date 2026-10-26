using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Fields
    [SerializeField] private EnemyNames _name;
    [SerializeField] private float _maxHP;
    [SerializeField] private float _hp;

    // Functions
    private void Die()
    {
        Destroy(gameObject);
    }

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
}
