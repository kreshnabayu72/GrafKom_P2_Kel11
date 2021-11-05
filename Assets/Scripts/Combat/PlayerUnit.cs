using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUnit : MonoBehaviour
{
    [SerializeField] UnitBase _base;
    [SerializeField] GameObject playerSprite;

    public Player Player {get;set;}

    public void Setup(){
        Player = new Player(_base);
        playerSprite.GetComponent<SpriteRenderer>().sprite = Player.Base.Sprite;
    }
}
