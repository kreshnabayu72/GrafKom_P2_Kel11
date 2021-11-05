using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWalk : MonoBehaviour
{
    private float moveSpeed = 10f;
    private float dirX,dirY;
    [SerializeField] GameController gameController;
    [SerializeField] Combat combat;
    [SerializeField] GameObject GameWinUI;

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(dirX*moveSpeed*Time.deltaTime,dirY*moveSpeed*Time.deltaTime,0);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Enemy")){
            collision.GetComponent<ExploreEnemy>().ToBattle();
            combat.SetExploreEnemy(collision.gameObject);
            TriggerCombat();
        }
        if(collision.CompareTag("Win")){
            gameWin();
        }
    }

    void TriggerCombat(){
        gameController.ChangeState();
        combat.StartBattle();
    }

    void gameWin(){
        GameWinUI.SetActive(true);
        this.enabled = false;
    }
       
}
