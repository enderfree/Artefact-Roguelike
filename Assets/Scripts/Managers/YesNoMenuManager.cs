using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class YesNoMenuManager : MonoBehaviour
{
    // Fields
    [SerializeField] TMP_Text _text;
    [SerializeField] Button _yes;
    [SerializeField] Button _no;

    private Action _onYes;
    private Action _onNo;

    // Functions
    public void DisplayYesNoMenu(string text, Action onYes, Action onNo, string yes = "Accept", string no = "Cancel")
    {
        _text.text = text;
        _yes.GetComponentInChildren<TMP_Text>().text = yes;
        _no.GetComponentInChildren<TMP_Text>().text = no;
        _onYes = onYes;
        _onNo = onNo;

        gameObject.SetActive(true);
    }

    public void CloseYesNoMenu()
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
