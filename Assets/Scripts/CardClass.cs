using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClass : MonoBehaviour {
    [SerializeField]
    int Number;
    [SerializeField]
    string Name;
    [SerializeField]
    string Status;
    [SerializeField]
    string Description;
    [SerializeField]
    string Code;
    [SerializeField]
    Sprite Thumbnail;
    [SerializeField]
    Sprite Eyecatch;
    [SerializeField]
    Sprite Transparent;
    [SerializeField]
    Sprite Picture;

  public int getNumber()
    { 
        return Number;
    }

  public Sprite getThumbnail()
    {
        return Thumbnail;
    }

    public string getStatus()
    {
        return Status;
    }
}
