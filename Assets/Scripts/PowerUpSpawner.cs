using System;
using UnityEngine.UI;
using Random = System.Random;

[Serializable]
public class PowerUpSpawner
{
    public Image shrink, expand, multiball, powerMove;

    public Image SetImage()
    {
        Image[] imageCollection = { shrink, expand, multiball, powerMove };
        var rnd = new Random();
        return imageCollection[rnd.Next(0, imageCollection.Length)];
    }

}
