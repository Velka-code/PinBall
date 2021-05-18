using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //左矢印キーまたAキーを押した時左フリッパーを動かす
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーまたはDキーを押した時右フリッパーを動かす
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //下矢印キーまたはSキーを押した時両フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            SetAngle(this.flickAngle);
        }


        //矢印キー離された時フリッパーを元に戻す
        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            SetAngle(this.defaultAngle);
        }




        //キー操作とタッチ操作を別々に記載（タッチ用）
        //左右同時にタップしたときの不具合を修正
        //if (Input.touchCount > 0)
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            switch (touch.phase)
            {
                case TouchPhase.Began://タッチしたときフリッパーを動かす
                    float getPos = touch.position.x;

                    if ((getPos < Screen.width / 2) && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle); 
                    }
                    if ((getPos >= Screen.width / 2) && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle); 
                    }
                    if ((getPos < Screen.width / 2) && (getPos > Screen.width / 2))
                    
                    {
                        SetAngle(this.flickAngle);
                    }

                    break;

                case TouchPhase.Ended: //タッチを離したときフリッパーを元に戻す
                    float getPosa = touch.position.x;

                    if ((getPosa < Screen.width / 2) && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                    if ((getPosa >= Screen.width / 2) && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }

                    if ((getPosa < Screen.width / 2) && (getPosa > Screen.width / 2))
                    
                    {
                        SetAngle(this.defaultAngle);
                    }

                    break;
                default:
                    break;
            }

        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}