using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Vuforia;

public class Director : MonoBehaviour {

    public GameObject VersionTextGO;
    public GameObject SettingsUI;
    public GameObject TestModeUI;
    public GameObject AdventureModeUI;
    public GameObject TargetsGO;

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

    private int adventureModeScore = 0;
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
        if (settingsUIId != -1)
        {
            AppMode previousAppMode = currentAppMode;
            currentAppMode = (AppMode)settingsUIId;
            ManageModeChange(previousAppMode, currentAppMode);
            VersionTextGO.GetComponent<Text>().text = "Current mode: " + currentAppMode;
        }
        // Turn on/off the option panels
        SettingsUI.SetActive(!SettingsUI.activeSelf);
        isSettingsOpen = !isSettingsOpen;
    }

    public void TargetTracked(string targetName)
    {
        if (currentAppMode == AppMode.Adventure)
        {
            Debug.Log(targetName);
        }
    }

    private void ManageModeChange(AppMode previousMode, AppMode newMode)
    {
        switch(previousMode)
        {
            case AppMode.Discovery:
                TargetsGO.SetActive(false);
                break;
            case AppMode.Test:
                TestModeUI.SetActive(false);
                break;
            case AppMode.Adventure:
                AdventureModeUI.SetActive(false);
                TargetsGO.SetActive(false);
                break;
        }

        switch (newMode)
        {
            case AppMode.Discovery:
                TargetsGO.SetActive(true);
                break;
            case AppMode.Test:
                TestModeUI.SetActive(true);
                break;
            case AppMode.Adventure:
                AdventureModeUI.SetActive(true);
                adventureModeScore = 0;
                GenerateNewAdventure();
                TargetsGO.SetActive(true);
                break;
        }
    }

    private void GenerateNewAdventure()
    {
        
    }

    private void TestButtonClicked(string name)
    {
        gameDirector.TestButtonClicked(name, VersionTextGO);
    }
}
