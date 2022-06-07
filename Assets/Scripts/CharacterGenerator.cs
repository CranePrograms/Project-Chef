using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CharacterGenerator : MonoBehaviour
{

    const string Name_File = "Chef_Names.txt";
    const string Creature_File = "Creature_Names.txt";

    public List<string> nameOptions = new List<string>();
    public List<string> creatureOptions = new List<string>();

    //I'll eventually need something that provides ages based on creature type.
    const int MAX_AGE = 100;
    const int MIN_AGE = 4;

    //stats line should be array?
    int intelligence;
    int charisma;
    int endurance;
    int dexterity;

    [SerializeField]
    private GameObject studentPrefab;

    private void Start()
    {
        LoadNames();
        LoadCreatures();
    }


    public void TestMakeStudent()
    {

        GameObject newStudent = Instantiate(studentPrefab, new Vector3(0,0,0), Quaternion.identity);
        Creature studentScript = newStudent.GetComponent<Creature>();
        studentScript.SetAge(GenerateAge());
        studentScript.SetName(GenerateName());
        studentScript.SetCreatureType(GenerateCreatureType());
        studentScript.SetColor(GenerateColor());
        GenerateStats();
        studentScript.SetStats(intelligence, charisma, endurance, dexterity);
        

    }

    private string GenerateName()
    {

        int max = nameOptions.Count;

        int rng = Random.Range(0, max);

        return nameOptions[rng];


    }

    private string GenerateCreatureType()
    {

        int max = creatureOptions.Count;

        int rng = Random.Range(0, max);

        return creatureOptions[rng];

    }

    private int GenerateAge()
    {

        return Random.Range(MIN_AGE, MAX_AGE);

    }

    private Color GenerateColor()
    {

        //Numbers have to be divided by 255 because the range is 0 - 1f.
        return new Color(Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, 1);
        

    }

    private void GenerateStats()
    {

        intelligence = Random.Range(0, 11);
        charisma = Random.Range(0, 11);
        endurance = Random.Range(0, 11);
        dexterity = Random.Range(0, 11);

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


}
