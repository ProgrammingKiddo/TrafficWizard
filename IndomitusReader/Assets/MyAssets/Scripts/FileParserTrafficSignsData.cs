using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileParserTrafficSignsData : ITrafficSignsData
{
    private readonly string _filePath;
    private bool _fileFound;
    private Dictionary<string, string> _trafficSignCollection = null;

    // Constructors
    public FileParserTrafficSignsData() : this("/StreamingAssets/TrafficSign_TextFile.txt") { }

    public FileParserTrafficSignsData(string filePath)
    {
        _filePath = filePath;

        string rawText;
        ExtractRawText(out rawText);
        if (_fileFound)
        {
            _trafficSignCollection = new Dictionary<string, string>();
            ParseRawText(rawText);
        }
    }

    // Interface implementation methods
    public bool GetTrafficSignCollection(out Dictionary<string, string> trafficSignCollection)
    {
        trafficSignCollection = _trafficSignCollection;
        return (_trafficSignCollection != null) ? true : false;
    }

    public bool GetTrafficSignText(string trafficSignName, out string trafficSignText)
    {
        return _trafficSignCollection.TryGetValue(trafficSignName, out trafficSignText);
    }

    public int GetNumberOfTrafficSigns()
    {
        return _trafficSignCollection.Count;
    }

    // Utility methods
    private void ExtractRawText(out string rawText)
    {
        try
        {
            rawText = File.ReadAllText(_filePath);
            _fileFound = true;
        }
        catch (System.Exception e)
        {
            _fileFound = false;
            rawText = null;
        }
    }
    private void ParseRawText(string rawText)
    {
        string[] lines;
        lines = rawText.Split('\n');
        int i = 0;
        string[] keyValuePair;
        while (i < lines.Length)
        {
            keyValuePair = lines[i].Split(';');
            _trafficSignCollection.Add(keyValuePair[0], keyValuePair[1]);
            i++;
        }
    }
}
