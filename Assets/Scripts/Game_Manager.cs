﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    GameObject lastSelectedObject = null; //this is the last Object selected.
    GameObject selectedObject = null; //this is the currently selected Object

    public void SetSelectedObject(GameObject newSelection)
    {
        /*
        if(newSelection.CompareTag("Student"))
        {
            selectedStudent = newSelection;
            Debug.Log("Selected " + selectedStudent.GetComponent<Student>().studentName.ToString());
            SetStudentSelectionSprite(selectedStudent, true);
        }
        */

        if(selectedObject != null)
        {

            lastSelectedObject = selectedObject;

            switch (lastSelectedObject.tag.ToString())
            {
                case "Student":
                    SetSelectionSprite(selectedObject, false); //deselect it because we're selecting something new
                    break;
                case "Teacher":
                    SetSelectionSprite(selectedObject, false);
                    break;

                default:
                    Debug.LogError("Last object doesn't have a recognized tag!");
                    break;

            }
        }


        switch(newSelection.tag.ToString())
        {
            case "Student":
                selectedObject = newSelection;
                Debug.Log("Selected " + selectedObject.GetComponent<Creature>().creatureName.ToString());
                SetSelectionSprite(selectedObject, true);
                break;
            case "Teacher":
                selectedObject = newSelection;
                SetSelectionSprite(selectedObject, true);
                break;

            default:
                Debug.LogError("New Selection doesn't have a recognized tag!");
                break;
        }

        

    }

    /// <summary>
    /// Either takes sets the Student_Selection_Sprite to enabled or disabled by calling SetSelectedSprite on the Student_Controller script.
    /// </summary>
    /// <param name="gameObject"> The student to toggle selection of </param>
    /// <param name="visibility"> Should the Student_Selection_Sprite be visible? </param>
    private void SetSelectionSprite(GameObject gameObject, bool visibility)
    {
        if(gameObject.CompareTag("Student") || gameObject.CompareTag("Teacher"))
        {
            gameObject.GetComponent<Creature_Controller>().SetSelectedSprite(visibility);
        }
    }

    public bool IsMoveableUnitSelected()
    {
        return selectedObject.CompareTag("Student") || selectedObject.CompareTag("Teacher") ? true : false;
        /*
        if(selectedObject.CompareTag("Student"))
        {
            return true;
        } else
        {
            return false;
        }
        */
    }

    public void MoveStudent(Vector2 newMovementPoint)
    {
        if(selectedObject.CompareTag("Student") || selectedObject.CompareTag("Teacher"))
        {
            selectedObject.GetComponent<Creature_Controller>().SetMovementPoint(newMovementPoint);
        }
    }


}
