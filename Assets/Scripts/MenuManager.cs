using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    private GameObject stationPanel;

    [SerializeField]
    private StationManager smScript;


    public void ToggleStationPanel()
    {

        if (stationPanel.activeSelf == true)
        {
            stationPanel.SetActive(false);
            smScript.clearSelectedPrefab();
        } else
        {
            stationPanel.SetActive(true);
        }
        
        
    }

    

}
