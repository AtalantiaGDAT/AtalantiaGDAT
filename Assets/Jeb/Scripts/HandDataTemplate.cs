using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using UnityEngine.UI;

public class HandDataTemplate : MonoBehaviour
{

    LeapProvider provider;

    public static float maxRightPinch; // = 0;
    public static float maxRightGrab; // = 0;
    public static float maxRightHeight; // = 0;
    public static float maxLeftPinch; // = 0;
    public static float maxLeftGrab; // = 0;
    public static float maxLeftHeight; // = 0;
    public static float leftHeight;
    public static float rightHeight;
    public static float rightGrab;

    //Data Scene UI elements
   /* public Text rPinch;
    public Text rGrab;
    public Text rHeight;

    public Text lPinch;
    public Text lGrab;
    public Text lHeight;*/

    //getting the system time from the user's computer
    public static string dateTime = System.DateTime.Now.ToString();

    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;

        maxRightPinch = 0;
        maxRightGrab = 0;
        maxRightHeight = 0;

        maxLeftPinch = 0;
        maxLeftGrab = 0;
        maxLeftHeight = 0;
    }

    /*******Add another column to return the name of the scene along with each
    record of data to know which scene that set of data is from******/

    void Update()
    {
        Frame frame = provider.CurrentFrame;
        List<Hand> hands = frame.Hands;
        for (int h = 0; h < hands.Count; h++)
        {
            Hand hand = hands[h];
            if (hand.IsRight)
            { //Begin right hand code
                Vector3 rightPalmUnity = hand.PalmNormal.ToVector3();
                Vector3 flat = new Vector3(1, 0, 0);

                var rightPalmDotProduct = Vector3.Dot(rightPalmUnity, flat);
                float rightPalmAngle = (Mathf.Acos(rightPalmDotProduct)) * (180.0f / Mathf.PI) - 90;

                float rightPinch = hand.PinchStrength; //Shows on a scale of 0 to 1 how much the forefinger and thumb are pinching
                rightGrab = hand.GrabStrength; //Shows on a scale of 0 to 1 how much the entire hand is grasping

                int rightExtendedFingers = 0; //Declares variable for amount of extended fingers on the right hand.

                for (int f = 0; f < hand.Fingers.Count; f++)
                {//Start loop to count extended fingers on the right hand
                    Finger digit = hand.Fingers[f];
                    if (digit.IsExtended)
                    {
                        rightExtendedFingers++; //Increase the count of extended fingers on the right hand by one
                    }
                } //End loop to count extended fingers on the right hand

                Finger rightThumb = hand.Fingers[0]; //
                Finger rightIndex = hand.Fingers[1]; //
                Finger rightMiddle = hand.Fingers[2]; // This section sets Finger variables for each finger on the right hand.
                Finger rightRing = hand.Fingers[3]; //
                Finger rightPinky = hand.Fingers[4]; //

                Leap.Vector rightThumbDir = rightThumb.Direction; //
                Leap.Vector rightIndexDir = rightIndex.Direction; //
                Leap.Vector rightMiddleDir = rightMiddle.Direction; //This section brings the direction variables for each finger out of the Leap Motion API
                Leap.Vector rightRingDir = rightRing.Direction; //
                Leap.Vector rightPinkyDir = rightPinky.Direction; //

                Vector3 rightThumbUnity = rightThumbDir.ToVector3(); //
                Vector3 rightIndexUnity = rightThumbDir.ToVector3(); //
                Vector3 rightMiddleUnity = rightThumbDir.ToVector3(); //This section converts all of the Leap Motion API vectors into Unity vectors
                Vector3 rightRingUnity = rightThumbDir.ToVector3(); //
                Vector3 rightPinkyUnity = rightThumbDir.ToVector3(); //

                var DotProduct_ThumbIndex = Vector3.Dot(rightThumbUnity, rightIndexUnity);
                float Angle_ThumbIndex = (Mathf.Acos(DotProduct_ThumbIndex)) * (180.0f / Mathf.PI) - 90; //Angle in degrees between Thumb and Index on right hand

                var DotProduct_IndexMiddle = Vector3.Dot(rightIndexUnity, rightMiddleUnity);
                float Angle_IndexMiddle = (Mathf.Acos(DotProduct_IndexMiddle)) * (180.0f / Mathf.PI) - 90; //Angle in degrees between Index and Middle on right hand

                var DotProduct_MiddleRing = Vector3.Dot(rightMiddleUnity, rightRingUnity);
                float Angle_MiddleRing = (Mathf.Acos(DotProduct_MiddleRing)) * (180.0f / Mathf.PI) - 90; //Angle in degrees between Middle and Ring on right hand

                var DotProduct_RingPinky = Vector3.Dot(rightRingUnity, rightPinkyUnity);
                float Angle_RingPinky = (Mathf.Acos(DotProduct_RingPinky)) * (180.0f / Mathf.PI) - 90; //Angle in degrees between Ring and Pinky on right hand

                rightHeight = (hand.PalmPosition.y + 0.3f) * 100.0f;


                //Write Code here to gather data from the right hand.

                if (rightPinch > maxRightPinch)
                {
                    maxRightPinch = rightPinch;
                }
                if (rightGrab > maxRightGrab)
                {
                    maxRightGrab = rightGrab;
                }
                if (rightHeight > maxRightHeight)
                {
                    maxRightHeight = rightHeight;
                }

               /* rPinch.text = rightPinch.ToString("F2");
                rGrab.text = rightGrab.ToString("F2");
                rHeight.text = rightHeight.ToString("F1");*/

            } //End right hand code

            else if (hand.IsLeft)
            { //Begin left hand code
                Vector3 leftPalmUnity = hand.PalmNormal.ToVector3();
                Vector3 flat = new Vector3(1, 0, 0);

                var leftPalmDotProduct = Vector3.Dot(leftPalmUnity, flat);
                float leftPalmAngle = (Mathf.Acos(leftPalmDotProduct)) * (180.0f / Mathf.PI) - 90;

                float leftPinch = hand.PinchStrength; //Shows on a scale of 0 to 1 how much the forefinger and thumb are pinching
                float leftGrab = hand.GrabStrength; //Shows on a scale of 0 to 1 how much the entire hand is grasping

                int leftExtendedFingers = 0; //Declares variable for amount of extended fingers on the left hand by one

                for (int f = 0; f < hand.Fingers.Count; f++)
                { //Start loop to count extended fingers on the left hand
                    Finger digit = hand.Fingers[f];
                    if (digit.IsExtended)
                    {
                        leftExtendedFingers++; //Increase the count of extended fingers on the left hand
                    }
                } //End loop to count extended fingers on the left hand

                Finger leftThumb = hand.Fingers[0]; //
                Finger leftIndex = hand.Fingers[1]; //
                Finger leftMiddle = hand.Fingers[2]; //This section sets Finger variables for each finger on the right hand.
                Finger leftRing = hand.Fingers[3]; //
                Finger leftPinky = hand.Fingers[4]; //

                Leap.Vector leftThumbDir = leftThumb.Direction; //
                Leap.Vector leftIndexDir = leftIndex.Direction; //
                Leap.Vector leftMiddleDir = leftMiddle.Direction; //This section brings the direction variables for each finger out of the Leap Motion API
                Leap.Vector leftRingDir = leftRing.Direction; //
                Leap.Vector leftPinkyDir = leftPinky.Direction; //


                Vector3 leftThumbUnity = leftThumbDir.ToVector3(); //
                Vector3 leftIndexUnity = leftThumbDir.ToVector3(); //
                Vector3 leftMiddleUnity = leftThumbDir.ToVector3(); //This section converts all of the Leap Motion API vectors into Unity vectors
                Vector3 leftRingUnity = leftThumbDir.ToVector3(); //
                Vector3 leftPinkyUnity = leftThumbDir.ToVector3(); //

                var DotProduct_ThumbIndex = Vector3.Dot(leftThumbUnity, leftIndexUnity);
                float Angle_ThumbIndex = (Mathf.Acos(DotProduct_ThumbIndex)) * (180.0f / Mathf.PI) - 90; //Angle in degrees between Thumb and Index on right hand

                var DotProduct_IndexMiddle = Vector3.Dot(leftIndexUnity, leftMiddleUnity);
                float Angle_IndexMiddle = (Mathf.Acos(DotProduct_IndexMiddle)) * (180.0f / Mathf.PI) - 90; //Angle in degrees between Index and Middle on right hand

                var DotProduct_MiddleRing = Vector3.Dot(leftMiddleUnity, leftRingUnity);
                float Angle_MiddleRing = (Mathf.Acos(DotProduct_MiddleRing)) * (180.0f / Mathf.PI) - 90; // Angle in degrees between Middle and Ring on right hand

                var DotProduct_RingPinky = Vector3.Dot(leftRingUnity, leftPinkyUnity);
                float Angle_RingPinky = (Mathf.Acos(DotProduct_RingPinky)) * (180.0f / Mathf.PI) - 90; //Angle in degrees between Ring and Pinky on right hand

               leftHeight = (hand.PalmPosition.y + 0.3f) * 100f;

                //Write Code here to gather data from the left hand
                if (leftPinch > maxLeftPinch)
                {
                    maxLeftPinch = leftPinch;
                }
                if (leftGrab > maxLeftGrab)
                {
                    maxLeftGrab = leftGrab;
                }
                if (leftHeight > maxLeftHeight)
                {
                    maxLeftHeight = leftHeight;
                }


                /* lPinch.text = leftPinch.ToString("F2");
                 lGrab.text = leftGrab.ToString("F2");
                 lHeight.text = leftHeight.ToString("F1");*/

            } //End left hand code
        }
    }
}
