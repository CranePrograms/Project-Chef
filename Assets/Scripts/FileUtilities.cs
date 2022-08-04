using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileUtilities: MonoBehaviour
{

    const string Name_File = "Chef_Names.txt";
    const string Creature_File = "Creature_Names.txt";
    const string Skills_File = "Skills.txt";

    List<string> nameOptions = new List<string>();
    List<string> creatureOptions = new List<string>();
    Dictionary<string, int> skillDictionary = new Dictionary<string, int>();

    void Awake()
    {
        LoadNames();
        LoadCreatures();
        LoadSkills();
    }

    private void LoadNames()
    {

        var sr = new StreamReader(Application.dataPath + "/Resources/" + Name_File);
        var fileContents = sr.ReadToEnd();
        sr.Close();  

        var lines = fileContents.Split("\n"[0]);
        foreach (string line in lines)
        {
            nameOptions.Add(line);
            //Debug.Log(line);
        }

        

    }

    private void LoadCreatures()
    {

        var sr = new StreamReader(Application.dataPath + "/Resources/" + Creature_File);
        var fileContents = sr.ReadToEnd();
        sr.Close();

        var lines = fileContents.Split("\n"[0]);
        foreach (string line in lines)
        {
            creatureOptions.Add(line);
            //Debug.Log(line);
        }

        

    }

    private void LoadSkills()
    {
        var sr = new StreamReader(Application.dataPath + "/Resources/" + Skills_File);
        var fileContents = sr.ReadToEnd();
        sr.Close();

        var lines = fileContents.Split("\n"[0]);
        foreach (string line in lines)
        {
            //Debug.Log("Testing Skills! " + line);
            skillDictionary.Add(line, 0); //add the skill with an initial value of 0;
        }

        
    }

    public List<string> GetNames()
    {
        return nameOptions;
    }

    public List<string> GetCreatures()
    {
        return creatureOptions;
    }

    public Dictionary<string, int> GetSkills()
    {
        foreach(KeyValuePair<string, int> kvp in skillDictionary)
        {
            Debug.Log("this is a skill! " + kvp.Key);
        }
        return skillDictionary;
    }

    public void GetSkills(Dictionary<string, int> newDict)
    {
        foreach(KeyValuePair<string, int> kvp in skillDictionary)
        {
            newDict.Add(kvp.Key, kvp.Value);
        }
    }

}
