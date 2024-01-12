using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileParserTrafficSignsQuestions : ITrafficSignsQuestions {

    private readonly string filePath;
    private bool fileFound;
    private List<TrafficSignQuestion> questionCollection;

    // Constructors
    public FileParserTrafficSignsQuestions() : this("/StreamingAssets/TrafficSign_QuestionsFile.txt") { }

    public FileParserTrafficSignsQuestions(string givenFilePath)
    {
        filePath = Application.dataPath + givenFilePath;

        string rawText;
        ExtractRawText(out rawText);
        if (fileFound)
        {
            questionCollection = new List<TrafficSignQuestion>();
            ParseRawText(rawText);
        }
    }

    public TrafficSignQuestion GetRandomQuestion()
    {
        System.Random rand = new System.Random();
        return questionCollection[rand.Next(questionCollection.Count)];
    }

    public int GetNumberOfQuestions()
    {
        return questionCollection.Count;
    }

    // Utilitiy methods
    private void ExtractRawText(out string rawText)
    {
        try
        {
            rawText = File.ReadAllText(filePath);
            fileFound = true;
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            fileFound = false;
            rawText = null;
        }
    }

    private void ParseRawText(string rawText)
    {
        string[] lines;
        lines = rawText.Split('\n');
        int i = 0;
        string[] signAttributes;
        while (i < lines.Length)
        {
            TrafficSignQuestion tempQuestion = new TrafficSignQuestion();
            signAttributes = lines[i].Split(';');
            if (signAttributes.Length == 5)
            {
                tempQuestion.questionType = (TrafficSignQuestion.QuestionType) int.Parse(signAttributes[0]);
                tempQuestion.questionTitle = signAttributes[1];
                tempQuestion.answers[0] = signAttributes[2];
                tempQuestion.answers[1] = signAttributes[3];
                tempQuestion.answers[2] = signAttributes[4];
                questionCollection.Add(tempQuestion);
            }
            i++;
        }
    }
}
