using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


enum State {START,PLAYER_TURN,ENEMY_TURN,END,LOST}

public class Combat : MonoBehaviour
{   
    State GameState;

    public GameObject playerObject;
	public GameObject enemyObject;
    public GameObject gameStatusUI;
    public Text gameStatusText;

	[SerializeField] PlayerUnit playerUnit;
	[SerializeField] EnemyUnit enemyUnit;
	[SerializeField] UnitHUD playerHUD;
	[SerializeField] UnitHUD enemyHUD;
	[SerializeField] GameController gameController;
	[SerializeField] GameObject exploreEnemy;
	[SerializeField] GameObject explorePlayer;
	[SerializeField] PlayerWalk playerWalk;
    

	public void StartBattle(){
		gameStatusUI.SetActive(false);
        GameState = State.START;
        StartCoroutine(BattleStart());
	}

	private void Start() {
		playerUnit.Setup();
		playerHUD.SetPlayerData(playerUnit.Player);
	}


    IEnumerator BattleStart(){
		
		enemyUnit.Setup();
		enemyHUD.SetEnemyData(enemyUnit.Enemy);
       
		yield return new WaitForSeconds(0.5f);

        GameState = State.PLAYER_TURN;
        
    }

	public void SetExploreEnemy(GameObject e){
		exploreEnemy = e;
	}

    void EndBattle(){
       if(GameState == State.END){
		   	gameStatusText.text = "Battle Ends!";
			gameStatusUI.SetActive(true);
			exploreEnemy.SetActive(false);
			playerWalk.EnemyDown();
			gameController.ChangeState(true);
			gameController.EnableExplore();
	   }
	   else if(GameState == State.LOST){
		   gameStatusText.text = "YOU LOSE!";
		   gameStatusUI.SetActive(true);
		   explorePlayer.SetActive(false);
		   gameController.ChangeState(false);
		   gameController.EnableExplore();

	   }
		
    }

    IEnumerator PlayerMove0()
	{		
		gameStatusUI.SetActive(true);
		gameStatusText.text = playerUnit.Player.Base.Name +" uses "+playerUnit.Player.Moves[0].Name;
		enemyUnit.Enemy.TakeDamage(playerUnit.Player.Moves[0],playerUnit);
		enemyHUD.UpdateHP();

		yield return new WaitForSeconds(1f);
		gameStatusUI.SetActive(false);

		if(enemyUnit.Enemy.HP <= 0)
		{
			GameState = State.END;
			EndBattle();
			Debug.Log("ENEMY DED");
		} else
		{
			GameState = State.ENEMY_TURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator PlayerMove1(){
		gameStatusUI.SetActive(true);
		gameStatusText.text = playerUnit.Player.Base.Name +" uses "+playerUnit.Player.Moves[1].Name;

		playerUnit.Player.Heal(playerUnit.Player.Moves[1]);
		enemyUnit.Enemy.TakeDamage(playerUnit.Player.Moves[1],playerUnit);

		enemyHUD.UpdateHP();
		playerHUD.UpdateHP();

		yield return new WaitForSeconds(1f);
		gameStatusUI.SetActive(false);

		if(enemyUnit.Enemy.HP <= 0)
		{
			EndBattle();
			Debug.Log("ENEMY DED");
		} else
		{
			GameState = State.ENEMY_TURN;
			StartCoroutine(EnemyTurn());
		}
	}
	IEnumerator PlayerMove2(){
		gameStatusUI.SetActive(true);
		gameStatusText.text = playerUnit.Player.Base.Name +" uses "+playerUnit.Player.Moves[2].Name;

		playerUnit.Player.Heal(playerUnit.Player.Moves[2]);

		enemyHUD.UpdateHP();
		playerHUD.UpdateHP();

		yield return new WaitForSeconds(1f);
		gameStatusUI.SetActive(false);

		if(enemyUnit.Enemy.HP <= 0)
		{
			EndBattle();
			Debug.Log("ENEMY DED");
		} else
		{
			GameState = State.ENEMY_TURN;
			StartCoroutine(EnemyTurn());
		}
	}
	


    IEnumerator EnemyTurn()
	{
	
		yield return new WaitForSeconds(1f);

		int selectedMove = Random.Range(0,enemyUnit.Enemy.Moves.Count);

		playerUnit.Player.TakeDamage(enemyUnit.Enemy.Moves[selectedMove]);
		playerHUD.UpdateHP();
		gameStatusUI.SetActive(true);
		gameStatusText.text = enemyUnit.Enemy.Base.Name +" uses "+ enemyUnit.Enemy.Moves[selectedMove].Name;
	   		 

		yield return new WaitForSeconds(1f);
		gameStatusUI.SetActive(false);
		GameState = State.PLAYER_TURN;
	
		if(playerUnit.Player.HP <= 0 )
		{
			GameState = State.LOST;
			EndBattle();
		} else
		{
			GameState = State.PLAYER_TURN;
		}

	}

    public void AttackButtonHandler0()
	{
		if (GameState != State.PLAYER_TURN)
			return;

		StartCoroutine(PlayerMove0());
	}
    public void AttackButtonHandler1()
	{
		if (GameState != State.PLAYER_TURN)
			return;

		StartCoroutine(PlayerMove1());
	}
    public void AttackButtonHandler2()
	{
		if (GameState != State.PLAYER_TURN)
			return;

		StartCoroutine(PlayerMove2());
	}
    public void AttackButtonHandler3()
	{
		if (GameState != State.PLAYER_TURN)
			return;

		Debug.Log("E");
	}

}

