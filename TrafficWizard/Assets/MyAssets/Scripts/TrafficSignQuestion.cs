using System.Collections.Generic;

public class TrafficSignQuestion {

	public enum QuestionType
    {
        Name_Text = 0,
        Name_Sprite = 1,
        Sprite_Name = 2
    }
    public QuestionType questionType;
    public string questionTitle;
    public List<string> answers;

    public TrafficSignQuestion()
    {
        // We initialize the answers list to contain 3 default-value ("") elements
        answers = new List<string>(new string[3]);
    }
}
