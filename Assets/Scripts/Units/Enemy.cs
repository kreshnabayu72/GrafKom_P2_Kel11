using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public UnitBase Base {get;set;}
    public int HP{get;set;}
    public int currentStress;
    public int maxStress;
    public List<LearnableMove> Moves {get;set;}

    int damage;

    public Enemy(UnitBase pBase){
        Base = pBase;
        HP = MaxHp;
        Moves = Base.Moves;
    }

    public int Attack{
        get {return (Base.Attack);}
    }
    public int Defense{
        get {return (Base.Defense);}
    }
    public int MaxHp{
        get {return (Base.MaxHp );}
    }

    public bool TakeDamage(LearnableMove move,PlayerUnit player){ 
        damage =  (move.Base.Damage-player.Player.Stress/10);
        if(damage >=0)
            HP-= damage;
    
        if(HP<=0){
            HP = 0;
            return true;
        }

        return false;
    }
}
