using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAccess : MonoBehaviour {

    public RectTransform navigator1;
    int navPosition = 0;

    [SerializeField]
    public RectTransform[] CSelectSlots = new RectTransform[6]; //MenuType1
    public RectTransform[] UpDownSlots = new RectTransform[2]; //MenuType2
    public RectTransform[] TeamSetSlots = new RectTransform[10];//MenuType3
    public RectTransform[] ClearSlot = new RectTransform[1];//MenuType4

    public int jumpAmount = 3; //works for both MenuTypes 1 and 3

    public int MenuType = 1; //we start off in the Character Select Slots
    
    // Use this for initialization
    void Start () {
        MoveNav(0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W)) { //going up
            MoveNav(-jumpAmount);
        }
	}

    void MoveNav(int change) {
        //Access the MenuType to check what context we're judging the input
        //change the navPosition value under the correct circumstance, as well as the MenuType if need be
        //For Example
        //if the current MenuType is 1, the change is jumpAmount and the navPosition is 3
        //...that is you're right above the up button
        //then change the MenuType to 2 and The NavPosition to 0

        //also, create a sprite to represent the cursor of player 1
        //We'll create four cursors for the entire menu, but only one will be on at a time
        //Since we'll be traversing across "4 different menus"
        //Let Navigator1 represent the navigator of the first menu.
        //use navigator1.GetComponent<GameObject>().SetActive(false); to make it invisible
    }

}
