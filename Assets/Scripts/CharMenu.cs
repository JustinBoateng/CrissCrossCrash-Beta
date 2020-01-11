using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class CharMenu : MonoBehaviour {

    public CardClass[] CMenu = new CardClass[6];
    public CardButton[] CSelect = new CardButton[6]; //6 for the menu, 7th is UP button, 8th is Down button
    [SerializeField]
    CardArrayManagement CardData;
    [SerializeField]
    int MaxNoOfCards;

    public CardClass[] Team = new CardClass[10];
    public CardButton[] TeamSelect = new CardButton[10];//10 for the team, 11th for the clear button 

    [SerializeField]
    public Button UPButton;

    [SerializeField]
    public Button DOWNButton;

    [SerializeField]
    public Button CLEARButton;

    [SerializeField]
    public Button NEXTButton;

    [SerializeField]
    public VersusMenu VSMReference;


    [SerializeField]
    public int PlayerNumber;


    private int u = 0; //u goes through the CSelect Buttons 
    private int v = 0; //v sets up the highlight/press colors of the buttons in CSELECT
    private int w = 0; //w aims to set a card in the TeamSelect Array
    ColorBlock ColorVar;
 
    void Start()
    {
        while (u <= CSelect.Length-1) //u acts as the incrementor for the CSelect buttons
        { //-2 because we're omitting the last two buttons: UP and DOWN
            CardButton CS = CSelect[u]; //It is ESSENTIAL that we create CS as a pointer to the CSelect[u] value to be called in the delegate
                                        

            CSelect[u].onClick.AddListener(new UnityAction(delegate() { //delegate is a way to apply a function on the spot, typically for Listeners
                if (CS.getCard().getStatus().ToLower() == "striker" || CS.getCard().getStatus().ToLower() == "ether" || CS.getCard().getStatus().ToLower() == "psychic") {
                    w = 0;
                    while (TeamSelect[w].hasCard() && w < 5) { w++; }

                    Team[w] = CS.getCard();
                    TeamSelect[w].setCard(CS.getCard()); //We set the card in the TeamSelect[w] Button's Card
                    TeamSelect[w].GetComponent<Image>().sprite = TeamSelect[w].getCard().getThumbnail();//Clicking on a button sets the thumbnail of the selected button to the Team Array button.
                }

                else if (CS.getCard().getStatus().ToLower() == "checkmate")
                {
                    w = 6;
                    if (TeamSelect[w].hasCard()) { w++; } //w=7 now (the second Checkmate slot)

                    Team[w] = CS.getCard();
                    TeamSelect[w].setCard(CS.getCard()); //We set the card in the TeamSelect[w] Button's Card
                    TeamSelect[w].GetComponent<Image>().sprite = TeamSelect[w].getCard().getThumbnail();//Clicking on a button sets the thumbnail of the selected button to the Team Array button.
                }

                else if (CS.getCard().getStatus().ToLower() == "slayer")
                {
                    w = 8;
                    Team[w] = CS.getCard();
                    TeamSelect[w].setCard(CS.getCard()); //We set the card in the TeamSelect[w] Button's Card
                    TeamSelect[w].GetComponent<Image>().sprite = TeamSelect[w].getCard().getThumbnail();//Clicking on a button sets the thumbnail of the selected button to the Team Array button.
                }

                else if (CS.getCard().getStatus().ToLower() == "boss")
                {
                    w = 9;
                    Team[w] = CS.getCard();
                    TeamSelect[w].setCard(CS.getCard()); //We set the card in the TeamSelect[w] Button's Card
                    TeamSelect[w].GetComponent<Image>().sprite = TeamSelect[w].getCard().getThumbnail();//Clicking on a button sets the thumbnail of the selected button to the Team Array button.
                }
                
            })); //parameters can't be entered into delegate functions, so we set the parameters outside the function as variables in this class 
                 //(the parameters being CS - the clicked button, and w - the CardButton in the TeamSelect array that we're putting CS into)

            ColorVar = CSelect[u].colors; //Use Var class or ColorBlock class // GetComponent<Button>() allows us to access the button component we see in Unity //But since CSelect[N] extends the Button class, it is a button all on its own and you can call the colors variable without using GetComponent
            ColorVar.highlightedColor = Color.cyan; //our arbitrary newColor () values dont work, but the preset colors (like Color.Cyan) does
            ColorVar.pressedColor = Color.blue;
            CSelect[u].colors = ColorVar;   //ColorVar copies the various colors the button has, such as it's highlighted, pressed, normal, and disabled colors. Then we edit them one by one, and return the color values to the button.

            u++;
        }

        //Sets highlights and pressed button colors of TEAMSELECT
        while (v < TeamSelect.Length)//-1 because the Clear Button runs the Clear function
        {
            CardButton TS = TeamSelect[v];
            TeamSelect[v].onClick.AddListener(new UnityAction(delegate () { //clicking on a card in your Team REMOVES the card from your team
                TS.removeCard();
            }));

            ColorVar = TeamSelect[v].GetComponent<Button>().colors; //Use Var class or ColorBlock class
            ColorVar.highlightedColor = Color.cyan; //our arbitrary newColor () values dont work, but the preset colors (like Color.Cyan) does
            ColorVar.pressedColor = Color.blue;
            TeamSelect[v].GetComponent<Button>().colors = ColorVar;
            v++;

        }

        UPButton.onClick.AddListener(new UnityAction(() => placeCards("UP")));
        DOWNButton.onClick.AddListener(new UnityAction(() => placeCards("DOWN")));
        CLEARButton.onClick.AddListener(new UnityAction(() => Clear()));
        NEXTButton.onClick.AddListener(new UnityAction(() => VSMReference.SetTeam(PlayerNumber,Team)));

        /*
         *CSelect[7].onClick.AddListener(new UnityAction(placeCards("UP"))); 
         * 
         The above line tries to call placeCards and then create a delegate from the result.
         That isn't going to work, because it's a void method.
         Normally you'd use a method group to create a delegate, or an anonymous function
         such as a lambda expression. In this case a lambda expression will be easiest:
         *
         CSelect[7].onClick.AddListener(new UnityAction(() => placeCards("UP")));
             
         You can't just use new UnityAction(placeCards()) 
         as the placeCards doesn't match the signature for UnityAction 
         (That is, it doesn't have the same number of parameters and the same return type)
         It's important that you understand why you're getting this error, as well as how to fix it.
       
         */


    }



    //Team has access to the selected cards 


    //try making the placeCards function a case-type function    
    public void placeCards(String CODE) //The Up and Down buttons call this function with a certain string. Depending on the string, the cards change
    {
        int index = 0;

        if (CODE == "BASE")                             //setting up the menu for the first time
        {
            for (int N = 0; N <= 5; N++)                //for 6 slots
            {
                CMenu[N] = CardData.getCard(10100 + N); //HMenu will be filled with the initial cards
            }
            Show();
            return;
        }

        if (CODE == "UP")//set up the card index
        {
            index = -100;
            if (CMenu[0].getNumber() + index == 10000)
                {
                //Debug.Log("Index is " + ((CMenu[0].getNumber() + index)/100));
                return;
                }             //if we're going up have index change respectively
            
        }

        else if (CODE == "DOWN") //set up the card index
        {
            index = 100;
            if ((CMenu[0].getNumber() + index) / 100 >= MaxNoOfCards)
            {
                //Debug.Log("Index is " + ((CMenu[0].getNumber() + index)/100) + ", which is greater than/ equal to " + MaxNoOfCards);
                return;
            }
            
        }           //if we're going down, have index change respectively

        
        for (int N = 0; N <= 5; N++)//populate the rest of the menu
        {
            //Debug.Log("Now it's " + (CMenu[N].getNumber() + index)); // INDEX CHECK//

            CMenu[N] = CardData.getCard(CMenu[N].getNumber() + index); //we're incrementing the current cards by the index amount
        }
        //Debug.Log("Ending for loop"); // INDEX CHECK//
        Show();
        return;
    }

    public void Show() //Show is only run once to 
    {
        for (int N = 0; N <= 5; N++)
        {
            CSelect[N].setCard(CMenu[N]); //We set the card that CSelect[N] has to it's corresponding CMenu Card
            CSelect[N].GetComponent<Image>().sprite = CMenu[N].getThumbnail(); //We get the thumbnail value from the Card object and apply it to the button //Also we access the Image component of the button to set its sprite (The graphic of the button)
        }
    }

    public void Clear() {
        for (int i = 0; i < TeamSelect.Length; i++) {
            TeamSelect[i].removeCard();
        }
    }

    public CardClass[] getTeam()
    {
        return Team;
    }
}