using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using System;

public class GetHandPosition : MonoBehaviour
{

    Controller controller = new Controller();
    public int FingerList;

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
        // // 両手の場合
        else if (rightHand != null && leftHand != null){
            outputBothHands(rightHand, leftHand);
        }
    }

    public void outputRightHand(Hand rightHand)
    {   
        foreach (Finger finger in rightHand.Fingers){
            Debug.Log("id :" + finger.Id +  ", 指 :" + finger.Type());
        }
        Debug.Log("____________");

    }

    public void outputBothHands(Hand rightHand, Hand leftHand)
    {
        Debug.Log ("両手を認知");
    }
}
