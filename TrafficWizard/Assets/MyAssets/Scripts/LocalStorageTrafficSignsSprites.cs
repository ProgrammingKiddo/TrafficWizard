using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalStorageTrafficSignsSprites : ITrafficSignsSprites {

	public Sprite GetSignSprite(string signTargetName)
    {
        Sprite loadedSprite = Resources.Load<Sprite>(signTargetName);
        if (loadedSprite == null)
        {
            Debug.Log("Sadly " + signTargetName + " returned null on its file search :(");
        }
        else
        {
            Debug.Log("Sprite " + loadedSprite.name + " loaded succesfully!");
        }
        return loadedSprite;
    }
}
