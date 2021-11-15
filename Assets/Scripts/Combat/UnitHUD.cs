using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHUD : MonoBehaviour
{
   public Text HealthText;
   public Slider HealthSlider;
   public bool isPlayer;

   [SerializeField] BottomUI bottomUI;

   Player _player;
   Enemy _enemy;

   public void SetPlayerData(Player player){
        _player = player;
        HealthText.text = "HP: " + _player.HP;
        HealthSlider.maxValue = _player.HP;
        HealthSlider.value = _player.HP;
        bottomUI.SetHealthMax(_player.HP);
        bottomUI.SetHealthValue(_player.HP);
        bottomUI.SetStressMax(_player.MaxStress);
        bottomUI.SetStressValue(_player.Stress);
        bottomUI.SetButtonText(_player);
   }

   public void SetEnemyData(Enemy enemy){
        _enemy = enemy;
        HealthText.text = "HP: " + _enemy.HP;
        HealthSlider.maxValue = _enemy.HP;
        HealthSlider.value = _enemy.HP;
   }

    public void UpdateHP(){
        if(isPlayer){
            HealthSlider.value = _player.HP;
            HealthText.text = "HP: " + _player.HP;
            bottomUI.SetHealthValue(_player.HP);
            bottomUI.SetStressValue(_player.Stress);
        }
            
        else{
            HealthSlider.value = _enemy.HP;
            HealthText.text = "HP: " + _enemy.HP;
        }
            
    }
}   
