using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour 
{
    private string myName;

    public string Name
    {
        get { return myName; }
        set { myName = value; }
    }
}