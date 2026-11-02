using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using TMPro;

public class ConfirmationMenuManager : MonoBehaviour
{
    // these should be the 6 buttons from this menu
    [SerializeField] List<Button> _toConfirm;

    private Action _onYes;
    private Action _onNo;

    // Functions
    /// <summary>
    /// Fill the menu and diplay it
    /// </summary>
    /// <param name="optionsToConfirm">always give 6</param>
    /// <param name="onYes">what happens OnAccept</param>
    /// <param name="onNo">what happens when people choose to go back</param>
    public void DisplaySelectionConfirmationMenu(List<string> optionsToConfirm, Action onYes, Action onNo)
    {
        for (int i = 0; i < 6; ++i)
        {
            _toConfirm[i].GetComponentInChildren<TMP_Text>().text = optionsToConfirm[i];
        }

        _onYes = onYes;
        _onNo = onNo;

        gameObject.SetActive(true);
    }

    public void CloseSelectionConfirmationMenu()
    {
        gameObject.SetActive(false);
    }

    // Handle Buttons
    public void OnYes()
    {
        _onYes();
    }

    public void OnNo()
    {
        _onNo();
    }
}
