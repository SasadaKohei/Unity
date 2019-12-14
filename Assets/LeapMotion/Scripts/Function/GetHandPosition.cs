using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using System;

public class GetHandPosition : MonoBehaviour
{
    Controller controller = new Controller();
    public static Leap.Vector R_thumb = new Leap.Vector();
    public static Leap.Vector R_index = new Leap.Vector();
    public static Leap.Vector R_middle = new Leap.Vector();
    public static Leap.Vector R_ring = new Leap.Vector();
    public static Leap.Vector R_pinky = new Leap.Vector();
    public static Leap.Vector L_thumb = new Leap.Vector();
    public static Leap.Vector L_index = new Leap.Vector();
    public static Leap.Vector L_middle = new Leap.Vector();
    public static Leap.Vector L_ring = new Leap.Vector();
    public static Leap.Vector L_pinky = new Leap.Vector();

    public static int measurementsNum = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Frame frame = controller.Frame();
        HandList hands = frame.Hands;
        Hand leftHand = hands.Leftmost;
        Hand rightHand = hands.Rightmost;
        FingerList leftFingers = leftHand.Fingers;
        FingerList rightFingers = rightHand.Fingers;
        string identifyHandFlag = "null";
        int fingerFlag = -1;


        if(leftHand.Id != -1){
            identifyHandFlag = "LeftHand";
            foreach(var left_finger in leftFingers){
                fingerFlag = left_finger.Id % 10;
                setFingerPos(identifyHandFlag, left_finger.Id, left_finger.TipPosition);
            }
        }

        if(rightHand.Id != -1){
            identifyHandFlag = "RightHand";
            foreach(var right_finger in rightFingers){
                fingerFlag = right_finger.Id % 10;
                setFingerPos(identifyHandFlag, right_finger.Id, right_finger.TipPosition);
            }
        }
        measurementsNum++;
        if(measurementsNum < 201){
            // dataを配列に格納
            if(leftHand.Id != -1 && leftHand.Id == -1){}
            else if(leftHand.Id == -1 && leftHand.Id != -1){}
            else if(leftHand.Id == -1 && leftHand.Id == -1){}
        }
        else{
            measurementsNum = 0;
        }
        
    }

    void setFingerPos(String hand, int flag, Leap.Vector finger){
        if (hand == "RightHand"){
            switch(flag)
            {
                case 0: 
                    R_thumb.x = finger.x;
                    R_thumb.y = finger.y;
                    R_thumb.z = finger.z;
                    break;
                case 1: 
                    R_index.x = finger.x;
                    R_index.y = finger.y;
                    R_index.z = finger.z;
                    break;
                case 2:
                    R_middle.x = finger.x;
                    R_middle.y = finger.y;
                    R_middle.z = finger.z;
                    break;
                case 3:
                    R_ring.x = finger.x;
                    R_ring.y = finger.y;
                    R_ring.z = finger.z;
                    break;
                case 4:
                    R_pinky.x = finger.x;
                    R_pinky.y = finger.y;
                    R_pinky.z = finger.z;
                    break;
                default:
                    break;
            }
        }
        else if(hand == "LeftHand"){
            switch(flag)
            {
                case 0: 
                    L_thumb.x = finger.x;
                    L_thumb.y = finger.y;
                    L_thumb.z = finger.z;
                    break;
                case 1: 
                    L_index.x = finger.x;
                    L_index.y = finger.y;
                    L_index.z = finger.z;
                    break;
                case 2:
                    L_middle.x = finger.x;
                    L_middle.y = finger.y;
                    L_middle.z = finger.z;
                    break;
                case 3:
                    L_ring.x = finger.x;
                    L_ring.y = finger.y;
                    L_ring.z = finger.z;
                    break;
                case 4:
                    L_pinky.x = finger.x;
                    L_pinky.y = finger.y;
                    L_pinky.z = finger.z;
                    break;
                default:
                    break;
            }
        }
    }
}