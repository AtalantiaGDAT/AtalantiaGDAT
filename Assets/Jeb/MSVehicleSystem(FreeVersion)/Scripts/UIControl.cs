using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.


public class UIControl : MonoBehaviour {
    public static float TurnDivider;
    public static int DiffVelocity;
    public Button DiffEasy;
    public Button DiffMedium;
    public Button DiffHard;
    public Slider SensitivitySlider;
    float MaxTurnDivider = 70;

    // Use this for initialization
    void Start () {
        TurnDivider = MaxTurnDivider;
        DiffVelocity = 30;
        DiffEasy.GetComponent<Image>().color = Color.green;
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
            Debug.Log("Hard");
            DiffHard.GetComponent<Image>().color = Color.green;
            DiffMedium.GetComponent<Image>().color = Color.white;
            DiffEasy.GetComponent<Image>().color = Color.white;
            DiffVelocity = 250;
        }
        else if(diff == 2)
        {
            Debug.Log("Medium");
            DiffMedium.GetComponent<Image>().color = Color.green;
            DiffEasy.GetComponent<Image>().color = Color.white;
            DiffHard.GetComponent<Image>().color = Color.white;
            DiffVelocity = 100;

        }
        else if (diff == 1)
        {
            Debug.Log("Easy");
            DiffEasy.GetComponent<Image>().color = Color.green;
            DiffMedium.GetComponent<Image>().color = Color.white;
            DiffHard.GetComponent<Image>().color = Color.white;
            DiffVelocity = 30;

        }

    }

}
