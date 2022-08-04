using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    [SerializeField]
    private Game_Manager gmScript; //This will be the Game_Manager script from the scene

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                gmScript.SetSelectedObject(hit.collider.gameObject);
                /*
                switch(hit.collider.gameObject.tag.ToString())
                {

                    case "Student":
                        Debug.Log("Hit a student");
                        gmScript.SetSelectedObject(hit.collider.gameObject);
                        break;
                    default:
                        break;
                }
                */
            }
            
        }

        if (Input.GetMouseButtonDown(1))
        {

            if(gmScript.IsMoveableUnitSelected())
            {
                Vector3 pointToConvert = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 newMovePoint = new Vector2(pointToConvert.x, pointToConvert.y);
                gmScript.MoveStudent(newMovePoint);
            }
            


        }
    }
}
