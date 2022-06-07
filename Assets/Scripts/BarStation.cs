using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarStation : StationBaseClass
{

    float tickTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        base.stationObject = this.transform.gameObject; //whatever this script is attached to is the station object.
        base.stationType = StationType.Bar;
    }

    // Update is called once per frame
    void Update()
    {
        tickTimer += Time.deltaTime;
        if (tickTimer >= 3)
        {
            tickTimer = 0;
            if (student != null)
            {
                student.GetComponent<Creature>().AddStats(CHAR: 1);
            }

        }
    }
}
