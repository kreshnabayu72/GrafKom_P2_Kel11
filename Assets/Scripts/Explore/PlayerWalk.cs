using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerWalk : MonoBehaviour
{
    public int enemyCount;
    private float moveSpeed = 8f;
    private float dirX,dirY;
    [SerializeField] GameController gameController;
    [SerializeField] Combat combat;
    [SerializeField] GameObject GameWinUI;
    [SerializeField] GameObject GameLoseUI;
    [SerializeField] Animator anim;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject restart;
    [SerializeField] GameObject next;
    [SerializeField] Text enemyLeftText;
    [SerializeField] Camera cam;

    bool canWalk = true;
    

    // Update is called once per frame
    void Update()
    {
        if(canWalk) Walk();
        
        enemyLeftText.text = "Enemy left: "+enemyCount;
        cam.transform.position = new Vector3(transform.position.x,transform.position.y,cam.transform.position.z);
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

    public void EnemyDown(){
        enemyCount -= 1;
        if(enemyCount == 0){
            gameWin();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Enemy")){
            collision.GetComponent<ExploreEnemy>().ToBattle();
            combat.SetExploreEnemy(collision.gameObject);
            TriggerCombat();
        }
    }

    void TriggerCombat(){
        gameController.ChangeState(true);
        gameController.DisableExplore();
        combat.StartBattle();
    }

    public void gameWin(){
        canWalk = false;
        GameWinUI.SetActive(true);
        mainMenu.SetActive(true);
        next.SetActive(true);
    }

    public void gameLost(){   
        canWalk = false;
        GameLoseUI.SetActive(true);
        mainMenu.SetActive(true);
        restart.SetActive(true);   
    }
       
    public void Tutorial(){
        SceneManager.LoadScene("Tutorial");
    }
    public void Asrama(){
        SceneManager.LoadScene("Asrama");
    }
    public void CCR(){
        SceneManager.LoadScene("Tutorial");
    }
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    
}
