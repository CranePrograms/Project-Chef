using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{

    /// <summary>
    /// I Need to be done for the night here as much as it pains me.
    /// I have no idea how to transfer this dictionary from file utilities over to another script.
    /// If I can do that then I'll be able to work on the rest from there.
    /// </summary>



    public float verticalContentPadding = 2; //this is the vertical padding for each object in the dictionary that goes into the content section of the scroll view.

    private GameObject skillTextPrefab;

    private Dictionary<string, GameObject> skillPanelDictionary = new Dictionary<string, GameObject>();
    private Dictionary<string, int> charSkillDictionary = new Dictionary<string, int>();

    [SerializeField]
    private FileUtilities fileUtilities;

    [SerializeField]
    private GameObject contentParent; //contains the content object of the scroll view which we want to build off.

    // Start is called before the first frame update
    void Start()
    {
        charSkillDictionary = fileUtilities.GetSkills();
        skillTextPrefab = Resources.Load<GameObject>("Skill Text Prefab");
        CreateSkillList();
    }

    private void CreateSkillList()
    {

        //float spacingHeight = CalculateSize(charSkillDictionary.Count);
        //float currentHeight = skillTextPrefab.GetComponent<RectTransform>().rect.height;
        //float currentHeight = 0;

        
        Debug.Log("Count! " + charSkillDictionary.Count);
        foreach(KeyValuePair<string, int> kvp in charSkillDictionary)
        {
            GameObject currentSkillObject = GameObject.Instantiate(skillTextPrefab);
            SkillTextPrefab stp = currentSkillObject.GetComponent<SkillTextPrefab>();
            stp.SetName(kvp.Key);
            stp.SetValue(kvp.Value);
            currentSkillObject.transform.SetParent(contentParent.transform);
            //currentSkillObject.transform.localPosition = new Vector3(0, currentHeight);
            //currentHeight -= spacingHeight;
            skillPanelDictionary.Add(kvp.Key, currentSkillObject); //add the completed object to the dictionary.
        }

    }

    //Takes an Int which is the amount of skills that will be in the list.
    //This figures out what the total space is we need to display each object after taking into account padding. It then returns the number of height units each object may use to fill exactly the space.
    //Returns the amount of units of distance between object placements.
    private float CalculateSize(int skillAmount)
    {
        
        RectTransform contentRect = contentParent.GetComponent<RectTransform>();
        float contentHeight = contentRect.rect.height;
        float prefabHeight = skillTextPrefab.GetComponent<RectTransform>().rect.height;
        float totalHeight = prefabHeight + verticalContentPadding; //this is the amount of space each object takes up.
        float neededSpace = skillAmount * totalHeight; //This is the space needed on the content scrollbar to display all of the skills.
        float neededScale = neededSpace / contentHeight;
        contentRect.localScale = new Vector3(contentRect.localScale.x, neededScale, contentRect.localScale.z);
        //RectTransform contentParentRect = contentParent.GetComponent<RectTransform>();
        

        return totalHeight;

    }

    public void ChangeSelectedCharacter(Dictionary<string, int> newDict)
    {
        foreach(KeyValuePair<string, int> kvp in newDict)
        {
            GameObject tempObj;

            if(skillPanelDictionary.TryGetValue(kvp.Key, out tempObj))
            {
                Debug.Log("This far without Error");
                tempObj.GetComponent<SkillTextPrefab>().SetValue(kvp.Value);
            } else
            {
                Debug.LogError("Couldn't find the skill while changing dictionary's in InfoPanel.cs/ChangeSelectedCharacter!");
            }
        }
    }

    //The list needs to be easy to update.
    //We can probably generate the list at the start and update it as we go.
    //The game object can be the Words on the list. When we initialize it we search each value in our dictionary and update the gameobject text.
    //When the character selected get's an update we then update that skill on the list.
    //When we select a new character it updates the whole list.


}
