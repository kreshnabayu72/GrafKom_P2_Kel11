using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWalk : MonoBehaviour
{
    private float moveSpeed = 8f;
    private float dirX,dirY;
    [SerializeField] GameController gameController;
    [SerializeField] Combat combat;
    [SerializeField] GameObject GameWinUI;
    [SerializeField] Animator anim;

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    void Walk(){
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(dirX*moveSpeed*Time.deltaTime,dirY*moveSpeed*Time.deltaTime,0);

        anim.SetFloat("dirX",dirX);
        anim.SetFloat("dirY",dirY);

        if(dirX == 0 && dirY==0){
            anim.SetBool("isWalking",false);
        }else{
            anim.SetBool("isWalking",true);
        }
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
        gameController.DisableExplore();
        combat.StartBattle();
    }

    void gameWin(){
        GameWinUI.SetActive(true);
        this.enabled = false;
    }
       
}
