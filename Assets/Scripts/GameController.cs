using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool earlyGame = true;    
    public bool lateGame = false;

    public void InvertGamePhase() {
        bool temp = earlyGame;
        earlyGame = lateGame;
        lateGame = temp;
    }
}
