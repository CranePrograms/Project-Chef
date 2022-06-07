using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelectedSprite(bool SpriteVisibility)
    {
        if(SpriteVisibility)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        } else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void SetMovementPoint(Vector2 newMovementPoint)
    {
        this.GetComponent<Creature_Seeker>().SetTargetPosition(newMovementPoint);
    }

}
