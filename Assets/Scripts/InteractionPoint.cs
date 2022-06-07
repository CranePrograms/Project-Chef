using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPoint : MonoBehaviour
{

    public GameObject attachedStation; //this is the station this point is attached to.


    void Start()
    {
        attachedStation = this.transform.parent.gameObject;
        Debug.Log("Interaction point attached to " + attachedStation.name.ToString());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger is working!");
        switch(collision.gameObject.tag.ToString())
        {
            case "Student":
                //We don't actually know what the script we're calling will be called.
                //It could be SushiStation BarStation etc etc
                attachedStation.SendMessage("SetStationStudent", collision.gameObject);
                break;
            case "Teacher":

                break;

            default:
                Debug.LogError("Error something other than a teacher or student is causing a collision at " + this.transform.position.ToString());
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("We left the trigger!");
        switch (collision.gameObject.tag.ToString())
        {
            case "Student":
                
                //This could create a bug if two students somehow enter the same station must be dealt with soon tm.
                attachedStation.SendMessage("RemoveStationStudent");
                break;
            case "Teacher":

                break;

            default:
                Debug.LogError("Error something other than a teacher or student is causing a collision at " + this.transform.position.ToString());
                break;
        }
    }



}
