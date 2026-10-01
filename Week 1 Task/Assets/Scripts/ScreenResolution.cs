using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    private Resolution[] resolutions;
    
    void Start()
    {
        dropdown = this.GetComponent<TMP_Dropdown>();
        
        resolutions = Screen.resolutions;

        List<string> stringResolutions = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            stringResolutions.Add(new string(resolutions[i].width + " x " + resolutions[i].height));

            // Check if this matches the user's current screen resolution
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        
        dropdown.AddOptions(stringResolutions);
        dropdown.value = currentResolutionIndex;
        dropdown.RefreshShownValue();
    }

    public void SetResolution()
    {
        int index = dropdown.value;
        Screen.SetResolution(resolutions[index].width, resolutions[index].height, Screen.fullScreenMode);
    }
}
