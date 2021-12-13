using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState {COMBAT,EXPLORE}
public class GameController : MonoBehaviour
{
    [SerializeField] Combat combat;
    [SerializeField] PlayerWalk playerWalk;
    public Camera CombatCamera;
    public Camera ExploreCamera;
    public GameState Status;

    public void ChangeState(bool win){
        if(Status == GameState.COMBAT){
            Status = GameState.EXPLORE;
            if(!win) playerWalk.gameLost();
        }
        else if(Status == GameState.EXPLORE){
            Status = GameState.COMBAT;
        }
    }

    private void Update() {
        if(Status == GameState.COMBAT){
            ExploreCamera.enabled = false;
            CombatCamera.enabled = true;
        }
        else if(Status == GameState.EXPLORE){
            ExploreCamera.enabled = true;
            CombatCamera.enabled = false;
        }
    }

    public void DisableExplore(){
        playerWalk.enabled = false;
    }
    public void EnableExplore(){
        playerWalk.enabled = true;
    }
    public void DisableCombat(){
        combat.enabled = false;
    }
    public void EnableCombat(){
        combat.enabled = true;
    }
    
}
