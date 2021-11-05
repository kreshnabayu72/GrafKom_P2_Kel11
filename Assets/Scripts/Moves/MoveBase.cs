using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Move",menuName="Unit/Create a new move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string moveName;
    [SerializeField] int level;
    [SerializeField] int damage;
   
    public string Name{
        get {return moveName;}
    } 
    public int Level{
        get{return level;}
    }    
    public int Damage{
        get {return damage;}
    }
   
}
