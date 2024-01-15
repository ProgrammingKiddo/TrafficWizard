using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileParserTrafficSignsData : ITrafficSignsData
{
    private readonly string filePath;
    private bool fileFound;
    private List<TrafficSign> signCollection;

    // Constructors
    public FileParserTrafficSignsData() : this("/StreamingAssets/TrafficSign_TextFile.txt") { }

    public FileParserTrafficSignsData(string givenFilePath)
    {
        filePath = Application.dataPath + givenFilePath;

        string rawText;
        ExtractRawText(out rawText);
        if (fileFound)
        {
            signCollection = new List<TrafficSign>();
            ParseRawText(rawText);
        }
    }

    // Interface implementation methods
    public bool GetTrafficSignCollection(out List<TrafficSign> trafficSignCollection)
    {
        trafficSignCollection = signCollection;
        return (trafficSignCollection != null) ? true : false;
    }

    public bool GetSignTextByName(string signName, out string signText)
    {
        TrafficSign tempSign = signCollection.Find(x => x.signName == signName);
        bool signFound = (tempSign != null);
        signText = (signFound) ? "" : tempSign.signText;
        return signFound;
    }
    public bool GetSignTextByTargetName(string signTargetName, out string signText)
    {
        TrafficSign tempSign = signCollection.Find(x => x.signTargetName == signTargetName);
        bool signFound = (tempSign != null);
        signText = (signFound) ? "" : tempSign.signText;
        return signFound;
    }

    public bool GetSignNameByText(string signText, out string signName)
    {
        TrafficSign tempSign = signCollection.Find(x => x.signText == signText);
        bool signFound = (tempSign != null);
        signName = (signFound) ? "" : tempSign.signName;
        return signFound;
    }
    public bool GetSignNameByTargetName(string signTargetName, out string signName)
    {
        TrafficSign tempSign = signCollection.Find(x => x.signTargetName == signTargetName);
        bool signFound = (tempSign != null);
        signName = (signFound) ? tempSign.signName : "";
        return signFound;
    }

    public bool GetSignTargetNameByText(string signText, out string signTargetName)
    {
        TrafficSign tempSign = signCollection.Find(x => x.signText == signText);
        bool signFound = (tempSign != null);
        signTargetName = (signFound) ? "" : tempSign.signTargetName;
        return signFound;
    }
    public bool GetSignTargetNameByName(string signName, out string signTargetName)
    {
        TrafficSign tempSign = signCollection.Find(x => x.signName == signName);
        bool signFound = (tempSign != null);
        signTargetName = (signFound) ? "" : tempSign.signTargetName;
        return signFound;
    }

    public int GetNumberOfTrafficSigns()
    {
        return signCollection.Count;
    }

    public string GetRandomSignName()
    {
        System.Random rand = new System.Random();
        return signCollection[rand.Next(signCollection.Count)].signName;
    }

    // Utility methods
    private void ExtractRawText(out string rawText)
    {
        try
        {
            rawText = File.ReadAllText(filePath, System.Text.Encoding.GetEncoding("iso-8859-1"));
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
            TrafficSign tempSign = new TrafficSign();
            signAttributes = lines[i].Split(';');
            if (signAttributes.Length == 3)
            {
                tempSign.signTargetName = signAttributes[0];
                tempSign.signName = signAttributes[1];
                tempSign.signText = signAttributes[2];
                signCollection.Add(tempSign);
            }
            i++;
        }
    }
}
