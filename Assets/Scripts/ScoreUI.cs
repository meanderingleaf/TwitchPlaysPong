using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

    public Text[] txtPlayerScores;
    private int[] playerScores = { 0, 0 };


    public void PlayerScored(int playerNum)
    {
        playerScores[playerNum] = playerScores[playerNum] + 1;
        txtPlayerScores[playerNum].text = playerScores[playerNum].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
