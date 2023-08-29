using System.Collections;
using System.Collections.Generic;
using Vuforia;
using UnityEngine;
using System.IO;

public class DiscoveryGameDirector : IGameDirector {

    private string recognizedSignName;
    private TextAsset trafficSignTexts;
    private TrafficSigns trafficSignDictionary;

    public DiscoveryGameDirector()
    {
        string textFilePath = Application.dataPath + "/StreamingAssets/TrafficSign_TextFile.json";
        string textFileContents = File.ReadAllText(textFilePath);
        trafficSignDictionary = JsonUtility.FromJson<TrafficSigns>(textFileContents);
    }

    public void ButtonClicked(GameObject go)
    {
        Debug.Log(go.name);
        recognizedSignName = go.GetComponent<ImageTargetBehaviour>().ImageTarget.Name;
        string recognizedSignText = trafficSignDictionary.trafficSigns[recognizedSignName];
        Debug.Log(recognizedSignText);
        go.transform.GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = recognizedSignText;
    }
}
