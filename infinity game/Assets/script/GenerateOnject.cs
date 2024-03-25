using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GenerateOnject : MonoBehaviour
{
    public GameObject Obstancle;
    float timer;
    float score;
    float cloudtimer;
    public GameObject cloud;

    
    // Update is called once per frame
    void Update()
    {
        manageTimer();
        score += Time.deltaTime;

        displayScore();

        //CreateClouds();
    }

    void manageTimer ()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            addObsatancle();
            timer = 0;
        }
    }

    void addObsatancle ()
    {
        Vector3 positionOfPlayer = GameObject.Find("Player").GetComponent<Player>().initialPosition + Vector3.down * .3f;
        float randomNumber = Random.Range(1, 5);
        GameObject t1, t2, t3, t4;
        t1 = (GameObject)(GameObject.Instantiate(Obstancle, positionOfPlayer + Vector3.right * 20, Quaternion.identity));
        if (randomNumber > 1)
        {
            t2 = (GameObject)(GameObject.Instantiate(Obstancle, positionOfPlayer + Vector3.right * 21, Quaternion.identity));
        }
        if (randomNumber > 2)
        {
            t3 = (GameObject)(GameObject.Instantiate(Obstancle, positionOfPlayer + Vector3.right * 22, Quaternion.identity));
        }
        if (randomNumber > 3)
        {
            t4 = (GameObject)(GameObject.Instantiate(Obstancle, positionOfPlayer + Vector3.right * 21 + Vector3.up, Quaternion.identity));
        }
    }

   /* void CreateClouds ()
    {
        cloudtimer += Time.deltaTime;
        GameObject cloud1;
        Vector3 topRightCorner = GameObject.Find ("topRightCorner").transform.position;
        int altitude = Random.Range(0,2);
        if (cloudtimer >= 10)
        {
            cloud1 = (GameObject)(GameObject.Instantiate(cloud, topRightCorner + (-Vector3.up) * altitude, Quaternion.identity));
            cloudtimer = 0;
        }
    }*/

    void displayScore()
    {
        GameObject.Find("scoreUI").GetComponent<Text>().text = "" + (int)score;
    }
}
