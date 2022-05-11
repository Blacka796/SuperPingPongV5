using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int PlayerScore1 = 3;
    public static int score = 0;
    

    public GUISkin layout;

    GameObject theBall;

    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    public static void Score (string wallID) {
    if (wallID == "BottomWall")
    {
        PlayerScore1--;
    } else
        {
            PlayerScore1--;
        }
}

    void OnGUI () {
    GUI.skin = layout;
    GUI.Label(new Rect(Screen.width / 2 - 500, 30, 160, 1000), "Lives:" + PlayerScore1);
    GUI.Label(new Rect(Screen.width / 2 - 340, 30, 160, 1000), "Score:" + score);


        if (GUI.Button(new Rect(Screen.width / 2 + 600, 1000, 120, 60), "RESTART"))
    {
        PlayerScore1 = 3;
        score = 0;
 
        theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        PlayAgain();
    }

    if (PlayerScore1 == 0)
    {
        GUI.Label(new Rect(Screen.width / 2 + 150, -460, 2000, 1000), "YOU LOSE");
        theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
    } else if (score == 36) {
        GUI.Label(new Rect(Screen.width / 2 + 150, -280, 2000, 1000), "YOU WON");
        theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
    }
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        score++;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
