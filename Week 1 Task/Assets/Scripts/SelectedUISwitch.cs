using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedUISwitch : MonoBehaviour
{

    public void switchSelected(GameObject nextSelected)
    {
        EventSystem.current.SetSelectedGameObject(nextSelected);
    }

}
