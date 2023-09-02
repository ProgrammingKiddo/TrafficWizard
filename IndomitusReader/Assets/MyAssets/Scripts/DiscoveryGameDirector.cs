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
        /*string textFileContents = File.ReadAllText(textFilePath);
        trafficSignDictionary = JsonUtility.FromJson<TrafficSigns>(textFileContents);*/
        trafficSignDictionary = new TrafficSigns();
        trafficSignDictionary.trafficSigns = new Dictionary<string, string>();
        /*TrafficSign ts1 = new TrafficSign();
        TrafficSign ts2 = new TrafficSign();
        ts1.signName = "Sign_R-2";
        ts1.signText = "Obligatorio para todo conductor de detener su vehículo ante la próxima línea de detención o, si no existe, inmediatamente antes de la intersección, y ceder el paso en la misma a los vehículos que circulen por la vía a la que se aproxime.";
        ts2.signName = "Sign_R-301_30kmph";
        ts2.signText = "\"Prohibición de circular a la velocidad superior, en kilómetros por hora, a la indicada en la señal. Obliga desde el lugar en que esté situada hasta la próxima señal de \"Fin de la limitación velocidad\", de \"Fin de prohibiciones\" u otra de \"Velocidad máxima\", salvo que esté colocada bajo una señal de advertencia de peligro, en cuyo caso la prohibición finaliza cuando termine el peligro señalado. Situada en una vía sin prioridad, deja de tener vigencia al salir de una intersección con una vía con prioridad.\"";*/
        trafficSignDictionary.trafficSigns.Add("Sign_R-2", "Obligatorio para todo conductor de detener su vehículo ante la próxima línea de detención o, si no existe, inmediatamente antes de la intersección, y ceder el paso en la misma a los vehículos que circulen por la vía a la que se aproxime.");
        trafficSignDictionary.trafficSigns.Add("Sign_R-301_30kmph", "\"Prohibición de circular a la velocidad superior, en kilómetros por hora, a la indicada en la señal. Obliga desde el lugar en que esté situada hasta la próxima señal de \"Fin de la limitación velocidad\", de \"Fin de prohibiciones\" u otra de \"Velocidad máxima\", salvo que esté colocada bajo una señal de advertencia de peligro, en cuyo caso la prohibición finaliza cuando termine el peligro señalado. Situada en una vía sin prioridad, deja de tener vigencia al salir de una intersección con una vía con prioridad.\"");
        string jsonString = JsonUtility.ToJson(trafficSignDictionary.trafficSigns);
        Debug.Log(jsonString);
        File.WriteAllText(textFilePath, jsonString);
    }

    public void ButtonClicked(GameObject go)
    {
        Debug.Log(go.name);
        recognizedSignName = go.GetComponent<ImageTargetBehaviour>().ImageTarget.Name;
        string recognizedSignText = trafficSignDictionary.trafficSigns[recognizedSignName];
        Debug.Log(recognizedSignText);
        go.transform.GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = recognizedSignText;
    }

    public void TestButtonClicked(string goName, GameObject textGO)
    {
        string text = "";
        bool exists;
        if (trafficSignDictionary.trafficSigns != null)
        {
            exists = trafficSignDictionary.trafficSigns.TryGetValue(goName, out text);
            Debug.Log(exists);
            //string recognizedSignText = trafficSignDictionary.trafficSigns[goName];
            Debug.Log(text);
            textGO.GetComponent<UnityEngine.UI.Text>().text = text;
        }
        else
        {
            textGO.GetComponent<UnityEngine.UI.Text>().text = "Void";
        }
    }
}
