using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class store_back : MonoBehaviour
{

    public GameObject backButton;

    
    void Start()
    {
    }

    void Update()
    {

    }

    public void GetBack() {
        backButton.SetActive(false);
    }
}
