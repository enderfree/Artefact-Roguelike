using UnityEngine;

public class DressGirlAnimationEventHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private MyCharacterController _characterController;

    public void ActivateWeaponHitbox()
    {
        _player.WeaponInstance.transform.Find("Hitbox").gameObject.SetActive(true);
    }

    public void DectivateWeaponHitbox()
    {
        _player.WeaponInstance.transform.Find("Hitbox").gameObject.SetActive(false);
        _player.Weapon.Moveset.OnGoingAttack = AttackTypes.None;
        _characterController.AllowInput = true;
    }
}
