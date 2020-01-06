using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using System;

public class GetHandPosition : MonoBehaviour
{

    Controller controller = new Controller();
    public int count = 0;
    // 一時保存用
    // 右手
    public static Leap.Vector R_hand_pos = new Leap.Vector();
    public static Leap.Vector R_hand_vec = new Leap.Vector();
    public static Leap.Vector R_thumb = new Leap.Vector();
    public static Leap.Vector R_index = new Leap.Vector();
    public static Leap.Vector R_middle = new Leap.Vector();
    public static Leap.Vector R_ring = new Leap.Vector();
    public static Leap.Vector R_pinky = new Leap.Vector();
    // 左手
    public static Leap.Vector L_hand_pos = new Leap.Vector();
    public static Leap.Vector L_hand_vec = new Leap.Vector();
    public static Leap.Vector L_thumb = new Leap.Vector();
    public static Leap.Vector L_index = new Leap.Vector();
    public static Leap.Vector L_middle = new Leap.Vector();
    public static Leap.Vector L_ring = new Leap.Vector();
    public static Leap.Vector L_pinky = new Leap.Vector();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Frame frame = controller.Frame();
        HandList hands = frame.Hands;
        Hand leftHand = null, rightHand = null;

        // 右手、左手を取得
        if (hands.Count == 1){
            rightHand = hands[0].IsRight ? hands[0] : null;
            leftHand = hands[0].IsLeft ? hands[0] : null;
        }
        else if (1 < hands.Count & hands.Count < 3){
            rightHand = hands[0].IsRight ? hands[0] : hands[1];
            leftHand = hands[0].IsLeft ? hands[0] : hands[1];
        }
        else {
            rightHand = null;
            leftHand = null;
        }

        // csv出力処理
        // 右手のみの場合
        if (rightHand != null && leftHand == null){
            outputRightHand(rightHand);
        }
        else if (rightHand == null && leftHand != null){
            outputLeftHand(leftHand);
        }
        // // 両手の場合
        else if (rightHand != null && leftHand != null){
            outputBothHands(rightHand, leftHand);
        }

        count++;
        if ( 1 <= count && count < 201){
            Debug.Log("計測中");
        }else if (count <= 201){
            count = 0;
        }
    }

        // 右手のみの検出処理
    public void outputRightHand(Hand rightHand)
    {
        foreach (Finger finger in rightHand.Fingers){
            Debug.Log("id :" + finger.Id +  ", 右手指 :" + finger.Type());
        }
        Debug.Log("____________");

    }

    // 左手のみの検出処理
    public void outputLeftHand(Hand leftHand)
    {
        foreach (Finger finger in leftHand.Fingers){
            Debug.Log("id :" + finger.Id +  ", 左手指 :" + finger.Type());
        }
        Debug.Log("____________");

    }

    // 両手のみの検出処理
    public void outputBothHands(Hand rightHand, Hand leftHand)
    {
        Debug.Log ("両手を認知");
        foreach (Finger finger in rightHand.Fingers){
            Debug.Log("id :" + finger.Id +  ", 右手指 :" + finger.Type());
        }
        
        foreach (Finger finger in leftHand.Fingers){
            Debug.Log("id :" + finger.Id +  ", 左手指 :" + finger.Type());
        }

        Debug.Log("____________");
    }

    // 座標セット
    public void setFingerPos(String hand, int flag, Leap.Vector finger){
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
        }else if(hand == "LeftHand"){
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
