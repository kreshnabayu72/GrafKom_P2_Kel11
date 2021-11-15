using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomUI : MonoBehaviour
{
    public Slider HealthSlider;
    public Slider StressSlider;
    public PlayerUnit player;
    public Text button0;
    public Text button1;
    public Text button2;
    public Text button3;
    
    public void SetHealthMax(int value){
        HealthSlider.maxValue = value;
    }
    public void SetHealthValue(int value){
        HealthSlider.value = value;
    }

    public void SetStressMax(int value){
        StressSlider.maxValue = value;
    }
    public void SetStressValue(int value){
        StressSlider.value = value;
    }
    public void SetButtonText(Player _player) {
        button0.text = _player.Base.Moves[0].Name;
        button1.text = _player.Base.Moves[1].Name;
        button2.text = _player.Base.Moves[2].Name;
        //button3.text = _player.Base.Moves[3].Name;
    }
}
