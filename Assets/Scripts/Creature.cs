using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    //These default values exist only to be shown if for some reason any of the Set methods fail.
    public string creatureName = "????";
    public string creatureType = "Missing No.??";
    public bool isTeacher = false; //default is not a teacher.

    public int creatureAge = 999;

    //stats line should be array?
    public int intelligence;
    public int charisma;
    public int endurance;
    public int dexterity;


    public void SetName(string sName)
    {
        creatureName = sName;
    }

    public void SetCreatureType(string sCreature)
    {
        creatureType = sCreature;
    }

    public void SetAge(int sAge)
    {
        creatureAge = sAge;
    }

    public void SetColor(Color newColor)
    {

        Debug.Log(newColor.r.ToString() + " " + newColor.g.ToString() + " " + newColor.b.ToString());

        gameObject.GetComponent<SpriteRenderer>().color = newColor;
        
    }

    public void SetStats(int INT, int CHAR, int END, int DEX)
    {
        intelligence = INT;
        charisma = CHAR;
        endurance = END;
        dexterity = DEX;

    }

    //Use this to add points to any of the stats this student has.
    public void AddStats(int INT = 0, int CHAR = 0, int END = 0, int DEX = 0)
    {
        intelligence += INT;
        charisma += CHAR;
        endurance += END;
        dexterity += DEX;
    }




}
