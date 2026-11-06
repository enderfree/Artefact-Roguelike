using UnityEngine;

/// <summary>
/// Weapons need a ton of outside references so I'd rather take it out of the 
/// GameMnager for ease of managing all of those fields
/// </summary>
public class WeaponRegisterer : MonoBehaviour
{
    // Fields
    [SerializeField] private GameObject _defaultWeaponPrefab;

    // Functions
    public void Init()
    {
        new Weapon("Default Sword", WeaponNames.DefaultSword, Moveset.Movesets[MovesetNames.Sword], _defaultWeaponPrefab, 5f, typeof(Weapon));
        new Weapon("Default Bow", WeaponNames.DefaultBow, Moveset.Movesets[MovesetNames.Bow], null, 5f, typeof(Weapon));
    }
}
