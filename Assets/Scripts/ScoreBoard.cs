using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public static int Score = 0;
    public static int Bonus = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnGUI(){
        string text1 = "", text2 = "";
        if(Bonus == 10) {
            text1 = " points for scoring with \na level 1 ball.";
            text2 = "\nDetails:\ngreen ball\nthrown force=500";
        }
        else if(Bonus == 20){
            text1 = " points for scoring with \na level 2 ball.";
            text2 = "\nDetails:\nyellow ball\nthrown force=400";
        }
        else if(Bonus == 30){
            text1 = " points for scoring with \na level 3 ball.";
            text2 = "\nDetails:\nred ball\nthrown force=300";
        }

        if(Bonus == 0) GUI.Box(new Rect(100, 100, 230, 130), "Score: " + Score.ToString());
        else GUI.Box(new Rect(100, 100, 230, 130), "Score: " + Score.ToString() + "\n\nBonus: " + Bonus.ToString() + text1 + text2);
    }
}
