using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Linq;

public class GUIManager : MonoBehaviour
{
    //// Fields
    [Header("Outside Scripts")]
    [SerializeField] private Player _playerStats;
    [SerializeField] private YesNoMenuManager _yesNoMenuManager;

    [Header("Hud Sections")]
    // the yes/no panel is not a child of the menu panel
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _faceSelectionMenu;

    [Header("Hud Ojects")]
    [SerializeField] private Slider _hpBar;
    // Should always be 6
    [SerializeField] private List<Button> _fsmLoadoutButtons;
    // Should always be 6
    [SerializeField] private List<Button> _fsmOptionButtons;

    // Non-Serialized
    private const string _emptyOption = "---";

    private Button _fsmSelected;
    private List<BlessingEffect> _fsmOptions;
    private List<List<BlessingEffect>> _fsmTempSelections;

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
        _fsmTempSelections = Player.GetEmptyLoadout();
        FillFaceSelectionMenuLoadout();
        FillFaceSelectionMenuOptions(new List<BlessingEffect>());
        _faceSelectionMenu.SetActive(false);
        _menuPanel.SetActive(false);
        _yesNoMenuManager.CloseYesNoMenu();
        
        _hpBar.maxValue = _playerStats.MaxHP;
        _hpBar.value = _playerStats.HP; 
    }

    // Face Selection Menu
    /// <summary>
    /// Initialize this menu
    /// </summary>
    /// <param name="options">The options offered to the player</param>
    private void OpenFaceSelectionMenu(List<BlessingEffect> options)
    {
        _fsmTempSelections = Player.GetEmptyLoadout();
        FillFaceSelectionMenuLoadout();
        FillFaceSelectionMenuOptions(options);
        
        _menuPanel.SetActive(true);
        _faceSelectionMenu.SetActive(true);
    }

    private void FillFaceSelectionMenuLoadout()
    {
        for (int i = 0; i < 6; ++i)
        {
            string btnText = (i + 1) + ". " + _playerStats.Loadout[i].Name.ToString();
            List<BlessingEffect> iterrationList = new List<BlessingEffect>(_playerStats.BlessingEffects[i]);
            iterrationList.AddRange(_fsmTempSelections[i]);

            foreach (BlessingEffect effect in iterrationList)
            {
                btnText += "\n" + effect.Name.ToString() + " (" + effect.Description + ")";
            }

            _fsmLoadoutButtons[i].GetComponentInChildren<TMP_Text>().text = btnText;
        }
    }

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

        _fsmOptions = options;

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

    private void SwapLoadoutOption(int loadout, int option)
    {
        _fsmSelected = null;
        _fsmTempSelections[loadout].Add(_fsmOptions[option]);

        Debug.Log("Loadout i: " + loadout + " Option i: " + option);
    }

    // Face Selection Menu Buttons (this does not include those in a list as those do weird things)
    public void ResetButton()
    {
        _yesNoMenuManager.DisplayYesNoMenu("Are you sure you want to discard your pending changes?", () => {
            // onAccept
            _fsmTempSelections = Player.GetEmptyLoadout();
            _yesNoMenuManager.CloseYesNoMenu();
            // onCancel
        }, () => _yesNoMenuManager.CloseYesNoMenu());
    }

    public void AcceptButton()
    {

    }

    //// Events
    private void OnHPChanged(float newHP)
    {
        _hpBar.value = newHP;
    }

    //// Getters and Setters
    public Button FSMSelected
    {
        get
        {
            return _fsmSelected;
        }
        set
        {
            Button newValue = value;

            if (_fsmSelected != null)
            {
                if (_fsmLoadoutButtons.Contains(_fsmSelected) && _fsmOptionButtons.Contains(newValue))
                {
                    SwapLoadoutOption(_fsmLoadoutButtons.IndexOf(_fsmSelected), _fsmOptionButtons.IndexOf(newValue));
                    return;
                }
                else if (_fsmLoadoutButtons.Contains(newValue) && _fsmOptionButtons.Contains(_fsmSelected))
                {
                    SwapLoadoutOption(_fsmLoadoutButtons.IndexOf(newValue), _fsmOptionButtons.IndexOf(_fsmSelected));
                    return;
                }
            }

            _fsmSelected = newValue;
        }
    }
}
