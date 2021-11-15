using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Move",menuName="Unit/Create a new move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string moveName;
    [SerializeField] int level;
    [SerializeField] int damage;
    [SerializeField] int stressDamage;
    [SerializeField] int heal;
    [SerializeField] int stressHeal;
   
    public string Name{
        get {return moveName;}
    } 
    public int Level{
        get {return level;}
    }    
    public int Damage{
        get {return damage;}
    }
    public int StressDamage{
        get {return stressDamage;}
    }
    public int Heal{
        get {return heal;}
    }
    public int StressHeal{
        get {return stressHeal;}
    }
   
}
