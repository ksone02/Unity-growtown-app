using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLandMark : MonoBehaviour
{
    public GameObject openCurrentLandmark;
    public GameObject GBAvoid, PSAvoid, BBAvoid, NTAvoid, EFAvoid, BHAvoid, PMAvoid;
    public void OpenCurrentLandmark() {
        openCurrentLandmark.SetActive(true);
    }
    public void CloseCurrentLandmark() {
        openCurrentLandmark.SetActive(false);
    }
    void Start() {
        openCurrentLandmark.SetActive(false);
    }
    void Update() {
        landmarkStore LM = GameObject.Find("AutoMakeCash").GetComponent<landmarkStore>();
        if(LM.currentGyeongbokCount==1) {
            GBAvoid.SetActive(false);
        } else if(LM.currentGyeongbokCount==0) {
            GBAvoid.SetActive(true);
        }
        if(LM.currentPisaCount==1) {
            PSAvoid.SetActive(false);
        } else if(LM.currentPisaCount==0) {
            PSAvoid.SetActive(true);
        }
        if(LM.currentBigbenCount==1) {
            BBAvoid.SetActive(false);
        } else if(LM.currentBigbenCount==0) {
            BBAvoid.SetActive(true);
        }
        if(LM.currentNortdamCount==1) {
            NTAvoid.SetActive(false);
        } else if(LM.currentNortdamCount==0) {
            NTAvoid.SetActive(true);
        }
        if(LM.currentEffelCount==1) {
            EFAvoid.SetActive(false);
        } else if(LM.currentEffelCount==0) {
            EFAvoid.SetActive(true);
        }
        if(LM.currentBruzeCount==1) {
            BHAvoid.SetActive(false);
        } else if(LM.currentBruzeCount==0) {
            BHAvoid.SetActive(true);
        }
        if(LM.currentPyramidCount==1) {
            PMAvoid.SetActive(false);
        } else if(LM.currentPyramidCount==0) {
            PMAvoid.SetActive(true);
        }
    }
}
