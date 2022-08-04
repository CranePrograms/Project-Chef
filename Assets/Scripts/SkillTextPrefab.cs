using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTextPrefab : MonoBehaviour
{

    const string skillNameText = "Skill Name Text";
    const string skillValueText = "Skill Value";

    Text skillName;
    Text skillValue;

    private void Awake()
    {
        skillName = this.gameObject.transform.Find(skillNameText).GetComponent<Text>();
        skillValue = this.gameObject.transform.Find(skillValueText).GetComponent<Text>();
    }

    public void SetName(string name)
    {
        skillName.text = name;
    }

    public void SetValue(int value)
    {
        skillValue.text = value.ToString();
    }


}
