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
            //addObsatancle();
            timer = 0;
        }
    }

    void addObsatancle ()
    {
       
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
