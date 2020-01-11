using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VersusMenu : MonoBehaviour {

    [SerializeField]
    public static CharMenu P1Menu;

    [SerializeField]
    public static CharMenu P2Menu;


    public static CardClass[] TeamP1;

    public static CardClass[] TeamP2;

    public Image[] Team1Display = new Image [10]; //Used to Verify player teams

    public Image[] Team2Display = new Image [10]; //Used to Verify player teams

    
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    public void SetTeam(int i, CardClass[] GivenTeam) {
     
        if (i == 1) {

            TeamP1 = GivenTeam;
            for (int j = 0; j < GivenTeam.Length; j++)
            {
                Team1Display[j].sprite = GivenTeam[j].getThumbnail(); 
            }

        } //we set player 1's team

        else if (i == 2) {

            TeamP2 = GivenTeam;

            for (int j = 0; j < GivenTeam.Length; j++)
            {
                Team2Display[j].sprite = GivenTeam[j].getThumbnail();
            }

        }//we set player 2's team
    }

}
