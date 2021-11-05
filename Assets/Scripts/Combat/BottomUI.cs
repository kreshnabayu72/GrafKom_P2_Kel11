using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomUI : MonoBehaviour
{
    public Slider HealthSlider;
    
    public void SetSliderMax(int value){
        HealthSlider.maxValue = value;
    }
    public void SetSliderValue(int value){
        HealthSlider.value = value;
    }
}
