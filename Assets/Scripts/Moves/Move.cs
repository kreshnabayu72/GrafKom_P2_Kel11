using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move 
{
    public MoveBase Base {get;set;}
    public int level;

    public Move(MoveBase mBase){
        Base = mBase;
        level = Base.Level;
    }
}
