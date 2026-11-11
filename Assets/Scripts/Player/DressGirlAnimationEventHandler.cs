using UnityEngine;

public class DressGirlAnimationEventHandler : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void ActivateWeaponHitbox()
    {
        _player.WeaponInstance.transform.Find("Hitbox").gameObject.SetActive(true);
    }

    public void DectivateWeaponHitbox()
    {
        _player.WeaponInstance.transform.Find("Hitbox").gameObject.SetActive(false);
    }
}
