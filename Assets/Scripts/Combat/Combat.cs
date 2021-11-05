using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


enum State {START,PLAYER_TURN,ENEMY_TURN,END}

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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

	public void StartBattle(){
		gameStatusUI.SetActive(false);
        GameState = State.START;
        StartCoroutine(BattleStart());
	}

    IEnumerator BattleStart(){
		playerUnit.Setup();
		playerHUD.SetPlayerData(playerUnit.Player);
		enemyUnit.Setup();
		enemyHUD.SetEnemyData(enemyUnit.Enemy);
       
		yield return new WaitForSeconds(0.5f);

        GameState = State.PLAYER_TURN;
        
    }
   
    void PlayerTurn()
    {
        Debug.Log("Player turn");
    }
	
	public void SetExploreEnemy(GameObject e){
		exploreEnemy = e;
	}

    void EndBattle(){
        GameState = State.END;
		gameStatusText.text = "Battle Ends!";
		gameStatusUI.SetActive(true);
		exploreEnemy.SetActive(false);
		gameController.ChangeState();
    }

    IEnumerator PlayerAttack()
	{		
		gameStatusUI.SetActive(true);
		gameStatusText.text = playerUnit.Player.Base.Name +" uses "+playerUnit.Player.Moves[0].Name;
		enemyUnit.Enemy.TakeDamage(playerUnit.Player.Moves[0]);
		enemyHUD.UpdateHP();

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
		PlayerTurn();

		if(playerUnit.Player.HP <= 0 || enemyUnit.Enemy.HP <= 0)
		{
			GameState = State.END;
			EndBattle();
		} else
		{
			GameState = State.PLAYER_TURN;
			PlayerTurn();
		}

	}


	public void EnemyStressAttack(){
		// playerScript.takeStress(10);
		gameStatusUI.SetActive(true);
		gameStatusText.text = "Stress Attack";
	}

    public void AttackButtonHandler()
	{
		if (GameState != State.PLAYER_TURN)
			return;

		StartCoroutine(PlayerAttack());
	}

}

