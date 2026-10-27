using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    // Fields
    [SerializeField] private Player _playerStats;
    [SerializeField] private Slider _hpBar;

    // MonoBehavior
    private void OnEnable()
    {
        Player.OnHPChanged += OnHPChanged;
    }

    private void OnDisable()
    {
        Player.OnHPChanged -= OnHPChanged;
    }

    // My Functions
    public void Init()
    {
        _hpBar.maxValue = _playerStats.MaxHP;
        _hpBar.value = _playerStats.HP;
    }

    // Events
    private void OnHPChanged(float newHP)
    {
        _hpBar.value = newHP;
    }
}
