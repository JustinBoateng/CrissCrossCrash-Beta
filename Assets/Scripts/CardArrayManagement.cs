using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardArrayManagement : MonoBehaviour {

    [SerializeField]
    static int range;

    public CardClass[] Array= new CardClass[range];


    public CardClass getCard(int NumCode)
    {int index = 0; 
        while (index <= 99) 
        {//Debug.Log("While loop # " + (index + 1));

           //Debug.Log("Attempting to getNumber of Card at index " + index + " With NumCode " + NumCode);

            if (Array[index].getNumber() == NumCode)
            {
                return Array[index];
            }

            index++;
        }
    
    //Debug.Log("Card does not exist");
        return null;        
    }
    
}
