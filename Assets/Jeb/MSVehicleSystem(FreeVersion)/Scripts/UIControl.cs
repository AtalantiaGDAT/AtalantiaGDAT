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
    public static float TurnDivider;
    public static int DiffVelocity;
    public Button DiffEasy;
    public Button DiffMedium;
    public Button DiffHard;
    public Slider SensitivitySlider;
    Color SelectedColor = new Color(182,175,175);

    float MaxTurnDivider = 70;

    // Use this for initialization
    void Start () {
        TurnDivider = MaxTurnDivider;
        DiffVelocity = 30;
        DiffEasy.GetComponent<Image>().color = SelectedColor;
    }

    // Update is called once per frame
    void Update () {
        //Sensitivity Values
        TurnDivider = MaxTurnDivider * ((1-SensitivitySlider.value/2));

        //Difficulty values
        DiffHard.onClick.AddListener(() => diffSelector(3));
        DiffMedium.onClick.AddListener(() => diffSelector(2));
        DiffEasy.onClick.AddListener(() => diffSelector(1));

    }

    void diffSelector(int diff)
    {
        if(diff == 3)
        {
            DiffHard.GetComponent<Image>().color = SelectedColor;
            DiffMedium.GetComponent<Image>().color = Color.white;
            DiffEasy.GetComponent<Image>().color = Color.white;

            
        }
        //else if(diff == 2)
    }

}
