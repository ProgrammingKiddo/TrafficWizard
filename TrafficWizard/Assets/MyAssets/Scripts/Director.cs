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
    public UnityEngine.UI.Image testImage;

    enum AppMode
    {
        Exploracion = 0,
        Test = 1,
        Aventura = 2
    }
    private AudioSource audioSource;
    private AppMode currentAppMode;

    private ITrafficSignsData trafficSignsDAO;
    private ITrafficSignsSprites trafficSignsSpritesDAO;

    // Test mode stuff
    private int currentTestScore = 0;
    private int maxTestScore = 0;

    // Adventure mode stuff
    private int adventureModeScore = 0;
    private string currentSignToFind = "";
    private string previousSignToFind = "";


    void Start () {

        currentAppMode = AppMode.Exploracion;
        trafficSignsDAO = new FileParserTrafficSignsData();
        trafficSignsSpritesDAO = new LocalStorageTrafficSignsSprites();
        audioSource = GetComponent<AudioSource>();
        Debug.Log("Numbers of signs: " + trafficSignsDAO.GetNumberOfTrafficSigns());
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            testImage.sprite = trafficSignsSpritesDAO.GetSignSprite("Sign_R-2");
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
                currentTestScore = 0;
                maxTestScore = 0;
                GenerateNewQuestion();
                break;
            case AppMode.Aventura:
                AdventureModeUI.SetActive(true);
                adventureModeScore = 0;
                currentSignToFind = "";
                previousSignToFind = "";
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
        // We get a new random Sign to find and make sure it's not
        // the same one we just got before
        previousSignToFind = currentSignToFind;
        do
        {
            currentSignToFind = trafficSignsDAO.GetRandomSignName();
        } while (currentSignToFind == previousSignToFind);

        AdventureModeUI.GetComponent<AdventureUIController>().UpdateTargetSignText(currentSignToFind);
        AdventureModeUI.GetComponent<AdventureUIController>().UpdateCurrentScoreText(adventureModeScore);
    }

    // Test mode methods

    private void GenerateNewQuestion()
    {
        TestModeUI.GetComponent<TestUIController>().UpdateScoreText(currentTestScore, maxTestScore);
    }

    private void GenerateNewType1Question()
    {

    }

}
