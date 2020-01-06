using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using System;

public class GetHandPosition : MonoBehaviour
{

    Controller controller = new Controller();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("実行中");
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
    }

    // 左手のみの検出処理
    public void outputLeftHand(Hand leftHand)
    {
        foreach (Finger finger in leftHand.Fingers){
            Debug.Log("id :" + finger.Id +  ", 左手指 :" + finger.Type());
        }
        Debug.Log("____________");

    }

    // 右手のみの検出処理
    public void outputRightHand(Hand rightHand)
    {
        foreach (Finger finger in rightHand.Fingers){
            Debug.Log("id :" + finger.Id +  ", 右手指 :" + finger.Type());
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
}
