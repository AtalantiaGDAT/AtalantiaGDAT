using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

/*public class Example : MonoBehaviour
{
    public GameObject SensitivitySliderGet = GameObject.Find("SensitivitySlider").GetComponent<Slider>().value;
    

    //Invoked when a submit button is clicked.
    public void SubmitSliderSetting()
    {
        //Displays the value of the slider in the console.
        Debug.Log(SensitivitySliderGet.value);
    }
}*/

public class UIControl : MonoBehaviour {
    float SensitivitySlider;
    public static float TurnDivider;
    float MaxTurnDivider = 70;

    // Use this for initialization
    void Start () {
        TurnDivider = MaxTurnDivider;
        SensitivitySlider = GetComponent<Slider>().value;
    }

    // Update is called once per frame
    void Update () {
        SensitivitySlider = GetComponent<Slider>().value;
        TurnDivider = MaxTurnDivider * ((1-SensitivitySlider/2));
        Debug.Log(TurnDivider);
    }
}
