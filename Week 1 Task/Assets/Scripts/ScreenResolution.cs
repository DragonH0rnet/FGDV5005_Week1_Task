using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    private Resolution[] resolutions;
    List<Resolution> rawResolutions = new List<Resolution>();

    void Start()
    {
        dropdown = this.GetComponent<TMP_Dropdown>();
        
        resolutions = Screen.resolutions;

        /*
        List<Resolution> filteredResolutions = resolutions
            .GroupBy(res => new { res.width, res.height })
            .Select(group => group.OrderByDescending(res => res.refreshRateRatio.value).First())
            .OrderBy(res => res.width)
            .ThenBy(res => res.height)
            .ToList();
        */

        List<string> stringResolutions = new List<string>();

        HashSet<string> uniqueResolutions = new HashSet<string>();
        int currentResolutionIndex = 0;
        int uniqueIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {

            string uniqueKey = $"{resolutions[i].width} x {resolutions[i].height}";

            if (!uniqueResolutions.Contains(uniqueKey))
            {
                uniqueResolutions.Add(uniqueKey);
                rawResolutions.Add(resolutions[i]);
                stringResolutions.Add(uniqueKey);
                uniqueIndex++;
            }

            // Check if this matches the user's current screen resolution
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = uniqueIndex - 1;
            }
        }
        
        dropdown.AddOptions(stringResolutions);
        dropdown.value = currentResolutionIndex;
        dropdown.RefreshShownValue();
    }

    public void SetResolution()
    {
        int index = dropdown.value;
        Screen.SetResolution(rawResolutions[index].width, rawResolutions[index].height, Screen.fullScreenMode);
    }
}
