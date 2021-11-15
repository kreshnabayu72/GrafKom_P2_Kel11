using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Unit/Create new unit")]
public class UnitBase : ScriptableObject
{
    [SerializeField] new string name;
    [SerializeField] Sprite sprite;

    //Base stats
    [SerializeField] int maxHp;
    [SerializeField] int maxStress;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] LearnableMove oneMove;
    [SerializeField] List<LearnableMove> moves;

    public string Name{
        get {return name;}
    }
    public Sprite Sprite{
        get { return sprite;}
    }
    public int MaxHp{
        get {return maxHp;}
    }
    public int MaxStress{
        get {return maxStress;}
    }
    public int Attack{
        get {return attack;}
    }
    public int Defense{
        get {return defense;}
    }
    public LearnableMove OneMove{
        get{return oneMove;}
    }
    public List<LearnableMove> Moves{
        get { return moves;}
    }
    
}

[System.Serializable]
public class LearnableMove{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;
    

    public MoveBase Base{
        get {return moveBase;}
    }
    public int Level{
        get {return level;}
    }
    public string Name{
        get{return Base.Name;}
    }
}
