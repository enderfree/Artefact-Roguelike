using UnityEngine;

public class MeleeHurtBox : MonoBehaviour
{
    // Fields
    private Player _player;

    // Monobehavior
    private void Awake()
    {
        _player = GameObject.FindAnyObjectByType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.HP -= _player.Weapon.Damage;
        }
    }
}
