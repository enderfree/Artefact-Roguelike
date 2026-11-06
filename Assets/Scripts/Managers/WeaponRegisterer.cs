using UnityEngine;

/// <summary>
/// Weapons need a ton of outside references so I'd rather take it out of the 
/// GameMnager for ease of managing all of those fields
/// </summary>
public class WeaponRegisterer : MonoBehaviour
{
    // Fields
    [Header("Animators")]
    [SerializeField] private Animator _swordAnimator;

    [Header("Prefabs")]
    [SerializeField] private GameObject _defaultWeaponPrefab;

    // Functions
    public void Init()
    {
        RegisterMovesets();
        RegisterWeapons();
    }

    private void RegisterMovesets()
    {
        // temp to test things before animations are shipped
        new SwordMoveset(_swordAnimator);
        new BowMoveset(null);
    }

    private void RegisterWeapons()
    {
        // temp to test things before animations are shipped
        new Weapon("Default Sword", WeaponNames.DefaultSword, Moveset.Movesets[MovesetNames.Sword], _defaultWeaponPrefab, 5f, typeof(Weapon));
        new Weapon("Default Bow", WeaponNames.DefaultBow, Moveset.Movesets[MovesetNames.Bow], null, 5f, typeof(Weapon));
    }
}
