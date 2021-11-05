using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUnit : MonoBehaviour
{
    [SerializeField] UnitBase _base;
    [SerializeField] GameObject enemySprite;

    public Enemy Enemy {get;set;}

    public void SetUnit(UnitBase based){
        _base = based;
    }

    public void Setup(){
        Enemy = new Enemy(_base);
        enemySprite.GetComponent<SpriteRenderer>().sprite = Enemy.Base.Sprite;
    }
}
