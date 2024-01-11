using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Vuforia;

public class Director : MonoBehaviour {

    public GameObject VersionTextGO;
    public GameObject OptionPanelsGO;

    enum AppMode
    {
        Discovery = 0,
        Test = 1,
        Adventure = 2
    }
    //public GameObject testTargetGO;
    private AppMode currentAppMode;
    private bool isSettingsOpen;
    private IGameDirector gameDirector;
    private GameObject createdGO;
    private Vector3 eulerAngleVelocity = new Vector3(10f, 10f, 0f);
    // Use this for initialization
    void Start () {
        gameDirector = new DiscoveryGameDirector();
        isSettingsOpen = true;
        currentAppMode = AppMode.Discovery;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            FixedUIButtonClicked(2);
        }
	}

    public void FixedUIButtonClicked(int settingsUIId)
    {
        Debug.Log(isSettingsOpen);
        if (settingsUIId != -1)
        {
            currentAppMode = (AppMode)settingsUIId;
            VersionTextGO.GetComponent<Text>().text = "Current mode: " + currentAppMode;
        }
        // Turn on/off the option panels
        OptionPanelsGO.SetActive(!OptionPanelsGO.activeSelf);
        isSettingsOpen = !isSettingsOpen;
        Debug.Log(isSettingsOpen);
    }

    private void TestButtonClicked(string name)
    {
        gameDirector.TestButtonClicked(name, VersionTextGO);
    }
}
