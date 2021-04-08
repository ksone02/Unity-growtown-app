using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationManager : MonoBehaviour
{

    public int population;

    public Text currentHumanText;

    public GameObject car1;
    public GameObject car2;
    public GameObject car3;

    void start() {
        
    }
    void Update() {
        currentHumanText.text = population + "명";
        if(population >= 500 && population < 1500) {
            car1.SetActive(true);
            car2.SetActive(false);
            car3.SetActive(false);
        } else if(population >= 1500 && population < 3000) {
            car1.SetActive(true);
            car2.SetActive(true);
            car3.SetActive(false);
        } else if(population >= 3000) {
            car1.SetActive(true);
            car2.SetActive(true);
            car3.SetActive(true);
        } else {
            car1.SetActive(false);
            car2.SetActive(false);
            car3.SetActive(false);
        }
    }

    public void Population() {
        
    }
}
