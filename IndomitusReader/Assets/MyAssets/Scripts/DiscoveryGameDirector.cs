using System.Collections;
using System.Collections.Generic;
using Vuforia;
using UnityEngine;
using System.IO;

public class DiscoveryGameDirector : IGameDirector {

    private ITrafficSignsData trafficSignsDAO;

    public DiscoveryGameDirector()
    {
        trafficSignsDAO = new FileParserTrafficSignsData();
    }

    public void ButtonClicked(GameObject go)
    {
        string recognizedSignText;
        string recognizedSignName;

        recognizedSignName = go.GetComponentInParent<ImageTargetBehaviour>().ImageTarget.Name;
        Debug.Log(recognizedSignName);
        bool exists = trafficSignsDAO.GetTrafficSignText(recognizedSignName, out recognizedSignText);
        if (exists)
        {
            go.transform.GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = recognizedSignText;
        }
        else
        {
            go.transform.GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Void";
        }
    }

    public void TestButtonClicked(string goName, GameObject textGO)
    {
        string text;
        bool exists = trafficSignsDAO.GetTrafficSignText(goName, out text);
        if (exists)
        {
            textGO.GetComponent<UnityEngine.UI.Text>().text = text;
        }
        else
        {
            textGO.GetComponent<UnityEngine.UI.Text>().text = "Void";
        }
    }
}
