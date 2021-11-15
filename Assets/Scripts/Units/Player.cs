using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    public UnitBase Base {get;set;}
    public int HP{get;set;}
    public int Stress{get;set;}
    public List<LearnableMove> Moves {get;set;}

    public Player(UnitBase pBase){        
        Base = pBase;
        HP = MaxHp;
        Stress = 0;
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
    public int MaxStress{
        get {return (Base.MaxStress);}
    }

    public bool TakeDamage(LearnableMove move){
        HP-=move.Base.Damage;
        Stress+= move.Base.StressDamage;
        if(HP<=0){
            HP = 0;
            return true;
        }

        return false;
    }
   
    public void Heal(LearnableMove move){
        HP += move.Base.Heal;
        if(HP > MaxHp) HP = MaxHp;
        Stress -= move.Base.StressHeal;
    }
}
