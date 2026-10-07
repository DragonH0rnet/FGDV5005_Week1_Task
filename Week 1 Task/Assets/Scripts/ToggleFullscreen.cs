using System;
using UnityEngine;

public class ToggleFullscreen : MonoBehaviour
{

    [SerializeField] GameObject FullscreenWidget;

    void Start()
    {
        FullscreenWidget.GetComponent<UnityEngine.UI.Toggle>().SetIsOnWithoutNotify(Screen.fullScreen);
    }

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
