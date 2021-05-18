using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //
    private int score = 0;
    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.tag);
        switch (collision.collider.tag)
        {
            case "SmallStarTag":
                this.score += 10;

                break;

            case "LargeStarTag":
                this.score += 20;
               
                break;

            case "SmallCloudTag":
                this.score += 10;
                
                break;

            case "LargeCloudTag":
                this.score += 20;
               
                break;

            default:
                break;
        }

        this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";

    }
}
