using System.Collections.Generic;

public interface ITrafficSignsData
{
    bool GetTrafficSignCollection(out Dictionary<string, string> trafficSignCollection);
    bool GetTrafficSignText(string trafficSignName, out string trafficSignText);
    int GetNumberOfTrafficSigns();
}
