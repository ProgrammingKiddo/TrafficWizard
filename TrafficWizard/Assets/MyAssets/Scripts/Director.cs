using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Vuforia;

public class Director : MonoBehaviour {

    public Text VersionText;
    public GameObject SettingsUI;
    public GameObject TestModeUI;
    public GameObject AdventureModeUI;
    public GameObject TargetsGO;
    public AudioClip coin;
    public AudioClip setting;

    enum AppMode
    {
        Exploracion = 0,
        Test = 1,
        Aventura = 2
    }
    private AudioSource audioSource;
    private AppMode currentAppMode;

    private ITrafficSignsData trafficSignsDAO;

    // Test mode stuff

    // Adventure mode stuff
    private int adventureModeScore = 0;
    private string currentSignToFind = "";


    void Start () {

        currentAppMode = AppMode.Exploracion;
        trafficSignsDAO = new FileParserTrafficSignsData();
        audioSource = GetComponent<AudioSource>();
        Debug.Log("Numbers of signs: " + trafficSignsDAO.GetNumberOfTrafficSigns());
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeAppMode(2);
        }

    }

    public void ChangeAppMode(int settingsUIId)
    {
        AppMode previousAppMode = currentAppMode;
        currentAppMode = (AppMode)settingsUIId;
        if (currentAppMode != previousAppMode)
        {
            ManageModeChange(previousAppMode, currentAppMode);
            VersionText.text = "Modo actual: " + currentAppMode;
        }
    }

    

    private void ManageModeChange(AppMode previousMode, AppMode newMode)
    {
        switch(previousMode)
        {
            case AppMode.Exploracion:
                TargetsGO.SetActive(false);
                break;
            case AppMode.Test:
                TestModeUI.SetActive(false);
                break;
            case AppMode.Aventura:
                AdventureModeUI.SetActive(false);
                TargetsGO.SetActive(false);
                break;
        }
        audioSource.clip = setting;
        audioSource.Play();
        switch (newMode)
        {
            case AppMode.Exploracion:
                TargetsGO.SetActive(true);
                break;
            case AppMode.Test:
                TestModeUI.SetActive(true);
                break;
            case AppMode.Aventura:
                AdventureModeUI.SetActive(true);
                adventureModeScore = 0;
                GenerateNewAdventure();
                TargetsGO.SetActive(true);
                break;
        }
    }

    // Adventure mode methods

    public void TargetTracked(string targetName)
    {
        if (currentAppMode == AppMode.Aventura)
        {
            string foundSignName;
            trafficSignsDAO.GetSignNameByTargetName(targetName, out foundSignName);
            if (foundSignName == currentSignToFind)
            {
                adventureModeScore++;
                audioSource.clip = coin;
                audioSource.Play();
                GenerateNewAdventure();
            }
        }
    }

    private void GenerateNewAdventure()
    {
        currentSignToFind = trafficSignsDAO.GetRandomSignName();
        AdventureModeUI.GetComponent<AdventureUIController>().UpdateTargetSignText(currentSignToFind);
        AdventureModeUI.GetComponent<AdventureUIController>().UpdateCurrentScoreText(adventureModeScore);
    }

}
