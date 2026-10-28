using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    //// Fields
    // Outside Scripts
    [SerializeField] private Player _playerStats;

    // Hud Sections
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _faceSelectionMenu;

    // Hud Ojects
    [SerializeField] private Slider _hpBar;

    //// MonoBehavior
    private void OnEnable()
    {
        Player.OnHPChanged += OnHPChanged;
    }

    private void OnDisable()
    {
        Player.OnHPChanged -= OnHPChanged;
    }

    //// My Functions
    public void Init()
    {
        _faceSelectionMenu.SetActive(false);
        _menuPanel.SetActive(false);

        _hpBar.maxValue = _playerStats.MaxHP;
        _hpBar.value = _playerStats.HP;
    }

    //// Events
    private void OnHPChanged(float newHP)
    {
        _hpBar.value = newHP;
    }
}
