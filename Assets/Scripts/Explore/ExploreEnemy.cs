using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExploreEnemy : MonoBehaviour
{
    [SerializeField] UnitBase _base;
    [SerializeField] GameObject enemySprite;
    [SerializeField] EnemyUnit combatEnemy;

    private void Start() {
        enemySprite.GetComponent<SpriteRenderer>().sprite = _base.Sprite;
    }

    public void ToBattle(){
        combatEnemy.SetUnit(_base);
    }
    
    
}
