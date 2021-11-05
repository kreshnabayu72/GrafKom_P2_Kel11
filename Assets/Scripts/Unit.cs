using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int unitMaxHP;
    public int unitCurrentHP;
    public int unitMaxStress;
    public int unitCurrentStress;
    public int unitDamage;
    public int moveCount = 0;
    public Text HealthText;
    public Slider HealthSlider;
    

    // Start is called before the first frame update
    void Start()
    {
        SetHud();
    }

    void SetHud(){
        if(unitCurrentHP>= 0 )
            HealthText.text = "HP: " + unitCurrentHP;
        else
            HealthText.text = "HP: " + 0;
        HealthSlider.maxValue = unitMaxHP;
        HealthSlider.value = unitCurrentHP;
    }

    // Update is called once per frame
    void Update()
    {
        SetHud();
    }

    public void takeDamage(int dmg){
        unitCurrentHP -= dmg;
    }
    public void takeStress(int stress){
        unitCurrentStress += stress;
    }
    public int getMaxHP(){
        return unitMaxHP;
    }
    public int getCurrentHP(){
        return unitCurrentHP;
    }
    public int getMaxStress(){
        return unitMaxStress;
    }
    public int getCurrentStress(){
        return unitCurrentStress;
    }
    public int getMoveCount(){
        return moveCount;
    }
    public void addMoveCount(int count){
        moveCount+=count;
    }
}
