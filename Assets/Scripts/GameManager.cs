using UnityEngine;
using System.Collections;

    public class GameManager : MonoBehaviour
    {

        
        public enum StateType
        {
            DEFAULT,      //Fall-back state, should never happen
            WAITING,      //waiting for other player to finish his turn
            STARTTURN,    //Once, on start of each player's turn
            PLAYING,      //My turn
            PLACING,      //placing a new obstacle
            BUYING,       //Buying something new
            SHOOTING,     //aiming to shoot
            BALLWAIT,     //Waiting for ball to stop
            TURNOVER,
            GAMEOVER,
            GAMESTART,
            LOBBY,        //Player is in the lobby
            MENU,         //Player is viewing in-game menu
            OPTIONS       //player is adjusting game options

        };
        void Update()
        {
        
            
         }

}



