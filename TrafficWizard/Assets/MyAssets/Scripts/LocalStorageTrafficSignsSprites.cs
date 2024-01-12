using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalStorageTrafficSignsSprites : ITrafficSignsSprites {

	public Sprite GetSignSprite(string signTargetName)
    {
        return Resources.Load<Sprite>(signTargetName);
    }
}
