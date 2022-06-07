using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject stationBasePrefab; //the station before having anything built

    [SerializeField]
    private GameObject sushiStationPrefab; //The sushi station

    [SerializeField]
    private GameObject barStationPrefab; //the Bar station

    private GameObject selectedPrefab; //The currently selected prefab


    //called when we close the menu.
    public void clearSelectedPrefab()
    {
        selectedPrefab = null;
        Debug.Log("Cleared prefabs");
    }

    public void ChangeSelectedPrefab(GameObject newPrefab)
    {
        selectedPrefab = newPrefab;
        Debug.Log(selectedPrefab.name);
    }



}
