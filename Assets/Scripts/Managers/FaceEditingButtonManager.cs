using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FaceEditingButtonManager : MonoBehaviour, ISelectHandler
{
    [SerializeField] private GUIManager _guiManager;

    // deselect
    // select
    // click

    public void OnSelect(BaseEventData eventData)
    {
        _guiManager.FSMSelected = GetComponent<Button>();
    }
}
