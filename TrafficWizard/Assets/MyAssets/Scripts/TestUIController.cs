using UnityEngine;
using UnityEngine.UI;

public class TestUIController : MonoBehaviour {

    public Director director;
    public GameObject[] QuestionTypesLayouts = new GameObject[3];
    public Text Type1QuestionTitle;
    public Text Type2QuestionTitle;
    public Image Type3QuestionTitle;
    public Text[] Type1Answers = new Text[3];
    public Image[] Type2Answers = new Image[3];
    public Text[] Type3Answers = new Text[3];
    public Text currentScoreText;
    public Text maxScoreText;

    private ITrafficSignsSprites trafficSignsSpritesDAO;
    private TrafficSignQuestion currentQuestion;

    private System.Random rand;

    // Use this for initialization
    void Start () {
        trafficSignsSpritesDAO = new LocalStorageTrafficSignsSprites();
        rand = new System.Random();
    }

    void OnEnable()
    {
        trafficSignsSpritesDAO = new LocalStorageTrafficSignsSprites();
        rand = new System.Random();
    }

    public void ShowQuestion(TrafficSignQuestion newQuestion)
    {
        DisableQuestionLayouts();
        currentQuestion = newQuestion;
        TrafficSignQuestion.QuestionType currentQuestionType = currentQuestion.questionType;
        // Activate the relevant layout to the type of question to show
        QuestionTypesLayouts[(int)currentQuestionType].SetActive(true);
        switch(currentQuestionType)
        {
            case TrafficSignQuestion.QuestionType.Name_Text:
                ShowType1Question();
                break;
            case TrafficSignQuestion.QuestionType.Name_Sprite:
                ShowType2Question();
                break;
            case TrafficSignQuestion.QuestionType.Sprite_Name:
                ShowType3Question();
                break;
        }

    }

    public void UpdateScoreText(int newCurrentTestScore, int newMaxTestScore)
    {
        currentScoreText.text = newCurrentTestScore.ToString();
        maxScoreText.text = newMaxTestScore.ToString();
    }

    public void OnSelect(GameObject go)
    {
        if (go.CompareTag("Answer"))
        {
            Debug.Log(go.name);
            if (currentQuestion.questionType == TrafficSignQuestion.QuestionType.Name_Sprite)
            {
                director.CheckAnswer(go.GetComponentInChildren<Image>().sprite.name);
            }
            else
            {
                director.CheckAnswer(go.GetComponentInChildren<Text>().text);
            }
        }
    }

    private void ShowType1Question()
    {
        Type1QuestionTitle.text = currentQuestion.questionTitle;
        
        int[] randomizedOptions = RandomizeOrderOfAnswers();
        Type1Answers[randomizedOptions[0]].text = currentQuestion.answers[0];
        Type1Answers[randomizedOptions[1]].text = currentQuestion.answers[1];
        Type1Answers[randomizedOptions[2]].text = currentQuestion.answers[2];
    }

    private void ShowType2Question()
    {
        Type2QuestionTitle.text = currentQuestion.questionTitle;

        int[] randomizedOptions = RandomizeOrderOfAnswers();
        Type2Answers[randomizedOptions[0]].sprite = trafficSignsSpritesDAO.GetSignSprite(currentQuestion.answers[0]);
        Type2Answers[randomizedOptions[1]].sprite = trafficSignsSpritesDAO.GetSignSprite(currentQuestion.answers[1]);
        Type2Answers[randomizedOptions[2]].sprite = trafficSignsSpritesDAO.GetSignSprite(currentQuestion.answers[2]);
    }

    private void ShowType3Question()
    {
        Type3QuestionTitle.sprite = trafficSignsSpritesDAO.GetSignSprite(currentQuestion.questionTitle);
            
        int[] randomizedOptions = RandomizeOrderOfAnswers();
        Type3Answers[randomizedOptions[0]].text = currentQuestion.answers[0];
        Type3Answers[randomizedOptions[1]].text = currentQuestion.answers[1];
        Type3Answers[randomizedOptions[2]].text = currentQuestion.answers[2];
    }

    // Random.Shuffle(T[]) doesn't seem to get properly recognized, so
    // we program our own shuffle method for our use case
    private int[] RandomizeOrderOfAnswers()
    {
        rand = new System.Random();
        int[] options = { 0, 1, 2 };
        int x, y, z;
        x = rand.Next(0, 3);
        options[x] = 0;
        do
        {
            y = rand.Next(0, 3);
        } while (x == y);
        // The sum of {0,1,2} is 3; so we work the leftover backwards
        z = 3 - (x + y);
        options[0] = x;
        options[1] = y;
        options[2] = z;
        return options;
    }

    // Deactivate all layouts
    private void DisableQuestionLayouts()
    {
        foreach (GameObject layout in QuestionTypesLayouts)
            layout.SetActive(false);
    }
}
