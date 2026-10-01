using UnityEngine;
using TMPro;

public class ChangeQuality : MonoBehaviour
{
    private TMP_Dropdown dropdown;

    void Start()
    {
        dropdown = GetComponentInChildren<TMP_Dropdown>();
        int index = dropdown.value;
    }

    public void changeQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
    }
}
