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

        // 認識
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

        // 出力
        measurementsNum++;
        // dataを配列に格納
        if( 0<= measurementsNum && measurementsNum <= 100){
            Debug.Log("待機中 :" + measurementsNum);
        }
        else if(100 < measurementsNum && measurementsNum <= 300){
            if (100 < measurementsNum && measurementsNum < 175) 
                Debug.Log("手をパー  :" + measurementsNum);
            else Debug.Log("指文字を測定中 : " + measurementsNum);
            // 右手の手話のみ
            if(rightHand.Id != -1 && leftHand.Id == -1){
                float[] rightHandData = new float[21];
                rightHandData = SetData(rightHand.PalmPosition,R_thumb, R_index, R_middle, R_ring, R_pinky,rightHand.PalmNormal);
            }
            // 左手の手話のみ
            else if(rightHand.Id == -1 && leftHand.Id != -1){
                float[] leftHandData = new float[21];
                leftHandData = SetData(leftHand.PalmPosition,L_thumb, L_index, L_middle, L_ring, L_pinky,leftHand.PalmNormal);
            }
            // 両手の手話のみ
            else if(rightHand.Id == -1 && leftHand.Id == -1){

            }
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

    //取得したベクトルを全て配列に格納
    float [] SetData(Leap.Vector hand_pos, Leap.Vector thumb, Leap.Vector index, Leap.Vector middle, Leap.Vector ring, Leap.Vector pinky, Leap.Vector vec_hand){
        //毎フレームごとに必要なデータを格納する配列
        float[] data = new float[21];
        //手の中心座標
        data[0] = hand_pos.x;
        data[1] = hand_pos.y;
        data[2] = hand_pos.z;
        //親指ベクトル
        data[3] = thumb.x;
        data[4] = thumb.y;
        data[5] = thumb.z;
        //人差し指ベクトル
        data[6] = index.x;
        data[7] = index.y;
        data[8] = index.z;
        //中指ベクトル
        data[9] = middle.x;
        data[10] = middle.y;
        data[11] = middle.z;
        //薬指ベクトル
        data[12] = ring.x;
        data[13] = ring.y;
        data[14] = ring.z;
        //小指ベクトル
        data[15] = pinky.x;
        data[16] = pinky.y;
        data[17] = pinky.z;
        //手の平法線
        data[18] = vec_hand.x;
        data[19] = vec_hand.y;
        data[20] = vec_hand.z;
        return data;
    }
}