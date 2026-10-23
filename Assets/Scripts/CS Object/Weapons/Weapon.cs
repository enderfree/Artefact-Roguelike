using UnityEngine;
using System.Collections.Generic;

public class Weapon
{
    // Fields
    public static List<Weapon> Weapons = new List<Weapon>();

    // the weapon name will likely be used raw and never references in the code for anything 
    // so an enum should not be needed for those. 
    [SerializeField] private string _name;
    [SerializeField] private Moveset _moveset;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _damage;
    // add a field for bows, I'm just not sure if range, velocity or path will be needed yet

    // Constructors
    public Weapon(string name, Moveset moveset, GameObject prefab, float damage)
    {
        _name = name;
        _moveset = moveset;
        _prefab = prefab;
        _damage = damage;

        Weapons.Add(this);
    }

    // Getters and Setters
    public virtual string Name
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

    public virtual Moveset Moveset
    {
        get
        {
            return _moveset;
        }
        set
        {
            _moveset = value;
        }
    }

    public virtual GameObject Prefab
    {
        get
        {
            return _prefab;
        }
        // if we set a prefab, there's gonna be quite a few lines that I am not ready to do rn
    }

    public virtual float Damage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = value;
        }
    }
}
