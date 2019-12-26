using UnityEngine.UI;

public class CardButton : Button {
    CardClass CurrentCard;
    //public Button Butt;

    public CardClass getCard() {
        return CurrentCard;    
    }//returns an INSTANCE of the card

    //this is why Button cannot be private, because we need to access the ACTUAL button for highlights and stuff

    public void setCard(CardClass C) {
        CurrentCard = C;
    }

    public bool hasCard() {
        if (CurrentCard != null) return true;
        return false;
    }

    public void removeCard() {
        CurrentCard = null;
        this.GetComponent<Image>().sprite = null;
    }
}
