using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiStation : StationBaseClass
{


    float tickTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        base.stationObject = this.transform.gameObject; //whatever this script is attached to is the station object.
        base.stationType = StationType.Sushi;
    }

    // Update is called once per frame
    void Update()
    {

        tickTimer += Time.deltaTime;
        if (tickTimer >= 3)
        {
            tickTimer = 0;
            if(studentList.Count > 0 && teacherList.Count > 0)
            {
                studentList[0].GetComponent<Creature>().AddStats(END: 1);
            }
            
        }
    }


}

    


