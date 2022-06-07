using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationBaseClass: MonoBehaviour
{
    public GameObject stationObject; //This is the station object of this station it can be any type like Sushi, Bar, Fancy stuff.
    public StationType stationType;

    public Transform teacherPoint; //The object with hitbox where the teacher should stand to interact with the station.
    public Transform studentPoint; //The object wtih hitbox where the student should stand to interact with the station.

    public GameObject student; //The student interacting with the station
    public GameObject teacher;  //The teacher interacting with the station

    private float intelligenceMod = 1.0f;
    private float charismaMod = 1.0f;
    private float enduranceMod = 1.0f;
    private float dexterityMod = 1.0f; //All of the potential modifiers for the station some may not be used at each station.
                                       //Mostly just here as preplanning for station upgrades.

    public enum StationType
    {
        Sushi,
        Bar,
        Steak,
    }

    #region Getter/Setter Functions
    public float GetIntelligenceMod()
    {
        return intelligenceMod;
    }

    public void SetIntelligenceMod(float newIntMod)
    {
        intelligenceMod = newIntMod;
    }

    public float GetCharismaMod()
    {
        return charismaMod;
    }

    public void SetCharismaMod(float newCharMod)
    {
        charismaMod = newCharMod;
    }

    public float GetEnduranceMod()
    {
        return enduranceMod;
    }

    public void SetEnduranceMod(float newEndMod)
    {
        enduranceMod = newEndMod;
    }

    public float GetDexterityMod()
    {
        return dexterityMod;
    }

    public void SetDexterityMod(float newDexMod)
    {
        dexterityMod = newDexMod;
    }

    #endregion

    public void SetStationStudent(GameObject newStudent)
    {
        if(newStudent.CompareTag("Student"))
        {
            student = newStudent;
            Debug.Log("Set a new student! " + newStudent.name);
        }
    }

    public void RemoveStationStudent()
    {
        student = null;
    }

    public void SetStationTeacher(GameObject newTeacher)
    {
        if (newTeacher.CompareTag("Teacher"))
        {
            teacher = newTeacher;
        }
    }

    public void RemoveStationTeacher()
    {
        teacher = null;
    }



    //We want to be able to upgrade the station
    //We can leave this for right now but essentially each station has to have some kind of modifiers to it?
    //Make that modifier editable through calls to the base class.
    //Take care of this through some Upgrade_Manager script later.

    //We want each station to be able to upgrade certain students stat points.
    //A weighted random event triggers
    //We make a call to the student script?
    //Upgrades the students stat points accordingly.


    //We want each station to be able to generate traits for the students.
    //I don't know how I want to implement traits yet?
    //Seperate file like names? probably not need to have stat effects too.
    //Seperate class?
    //Unsure yet

    //A weighted random event triggers.
    //This makes a call to Game/Trait manager
    //That script makes a call to the given student to add the traits and affect stats accordingly.
}
