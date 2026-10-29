using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Linq;

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
    // Should always be 6
    [SerializeField] private List<Button> _fsmLoadoutButtons;
    // Should always be 6
    [SerializeField] private List<Button> _fsmOptionButtons;

    // Non-Serialized
    private const string _emptyOption = "---";

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
        FillFaceSelectionMenuLoadout();
        FillFaceSelectionMenuOptions(new List<BlessingEffect>());
        _faceSelectionMenu.SetActive(false);
        _menuPanel.SetActive(false);

        _hpBar.maxValue = _playerStats.MaxHP;
        _hpBar.value = _playerStats.HP;
    }

    private void FillFaceSelectionMenuLoadout()
    {
        for (int i = 0; i < 6; ++i)
        {
            string btnText = (i + 1) + ". " + _playerStats.Loadout[i].Name.ToString();

            foreach (BlessingEffect effect in _playerStats.BlessingEffects[i])
            {
                btnText += "\n" + effect.Name.ToString() + " (" + effect.Description + ")";
            }

            _fsmLoadoutButtons[i].GetComponentInChildren<TMP_Text>().text = btnText;
        }
    }

    // Face Selection Menu
    /// <summary>
    /// Fills the options the player can select from the option table in the face selection menu
    /// </summary>
    /// <param name="options">A list containing a maximum of 6 options</param>
    private void FillFaceSelectionMenuOptions(List<BlessingEffect> options)
    {
        // 6 is hardcoded at a few places because we based even the design on a d6 and while I could link
        // to a dice size variable or something else, we'd still need to redesign pretty much every thing, 
        // so it's not worth the hassle
        if (options.Count < 6)
        {
            options.AddRange(Enumerable.Repeat<BlessingEffect>(null, 6 - options.Count));
        }

        for (int i = 0; i < 6; ++i)
        {
            if (options[i] != null)
            {
                _fsmOptionButtons[i].GetComponentInChildren<TMP_Text>().text = options[i].Name.ToString() + "/n" + options[i].Description;
            }
            else
            {
                _fsmOptionButtons[i].GetComponentInChildren<TMP_Text>().text = _emptyOption;
            }
        }
    }

    //// Events
    private void OnHPChanged(float newHP)
    {
        _hpBar.value = newHP;
    }
}
