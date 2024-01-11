using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUIController : MonoBehaviour {

    public GameObject[] Buttons;
    public Director director;

    public void OnSelect(GameObject originGO)
    {
        switch(originGO.name)
        {
            case "Button_Option_1":
                director.ChangeAppMode(0);
                break;
            case "Button_Option_2":
                director.ChangeAppMode(1);
                break;
            case "Button_Option_3":
                director.ChangeAppMode(2);
                break;
            default:
                break;
        }
        // Activate/deactivate the settings panel
        foreach (GameObject button in Buttons)
            button.SetActive(!button.activeSelf);
    }
}
