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
    public AudioClip modeChangeSound;
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
    private ITrafficSignsQuestions trafficSignsQuestionsDAO;

    // Test mode stuff
    private int currentTestScore = 0;
    private int maxTestScore = 0;
    private TrafficSignQuestion currentQuestion;
    private TrafficSignQuestion previousQuestion;

    // Adventure mode stuff
    private int adventureModeScore = 0;
    private string currentSignToFind = "";
    private string previousSignToFind = "";


    void Start () {

        currentAppMode = AppMode.Exploracion;
        trafficSignsDAO = new FileParserTrafficSignsData();
        trafficSignsQuestionsDAO = new FileParserTrafficSignsQuestions();
        audioSource = GetComponent<AudioSource>();
        string s = "¿características guardadas?";
        VersionText.text = s;
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
        PlayClip(modeChangeSound);
        switch (newMode)
        {
            case AppMode.Exploracion:
                TargetsGO.SetActive(true);
                break;
            case AppMode.Test:
                TestModeUI.SetActive(true);
                currentTestScore = 0;
                maxTestScore = 0;
                currentQuestion = null;
                previousQuestion = null;
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

    private void PlayClip(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
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
                PlayClip(coin);
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
        previousQuestion = currentQuestion;
        do
        {
            currentQuestion = trafficSignsQuestionsDAO.GetRandomQuestion();
        } while (currentQuestion == previousQuestion);

        TestModeUI.GetComponent<TestUIController>().UpdateScoreText(currentTestScore, maxTestScore);
        TestModeUI.GetComponent<TestUIController>().ShowQuestion(currentQuestion);
    }

    public void CheckAnswer(string answer)
    {
        if (answer == currentQuestion.answers[0])
        {
            PlayClip(coin);
            currentTestScore++;
        }
        maxTestScore++;
        GenerateNewQuestion();
    }

}
