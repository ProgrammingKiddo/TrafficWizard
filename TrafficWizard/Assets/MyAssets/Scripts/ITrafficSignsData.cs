using System.Collections.Generic;

public interface ITrafficSignsData
{
    bool GetTrafficSignCollection(out List<TrafficSign> trafficSignCollection);

    bool GetSignTextByName(string signName, out string signText);
    bool GetSignTextByTargetName(string signTargetName, out string signText);

    bool GetSignNameByText(string signText, out string signName);
    bool GetSignNameByTargetName(string signTargetName, out string signName);

    bool GetSignTargetNameByText(string signText, out string signTargetName);
    bool GetSignTargetNameByName(string signName, out string signTargetName);

    int GetNumberOfTrafficSigns();
}
