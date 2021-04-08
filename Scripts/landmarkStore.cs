using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class landmarkStore : MonoBehaviour
{
    public GameObject gyeongbokPrice, pisaPrice, bigbenPrice, nortdamPrice, effelPrice, bruzePrice, pyramidPrice;
    public GameObject GBBtn, PSBtn, BBBtn, NTBtn, EFBtn, BHBtn, PMBtn;

    bool GBBuy, PSBuy, BBBuy, NTBuy, EFBuy, BHBuy, PMBuy;
    public int GBBool, PSBool, BBBool, NTBool, EFBool, BHBool, PMBool;

    public int currentGyeongbokPrice, currentPisaPrice, currentBigbenPrice, currentNortdamPrice, currentEffelPrice, currentBruzePrice, currentPyramidPrice;
    public int currentGyeongbokCount, currentPisaCount, currentBigbenCount, currentNortdamCount, currentEffelCount, currentBruzeCount, currentPyramidCount;

    public GameObject landmarkRoom, openCurrentLandmark;

    private AudioSource audioSource;
    public AudioClip clickSound;
  
    void Start()
    {
        landmarkRoom.SetActive(false);
        this.audioSource = GameObject.Find("ButtonSound").GetComponent<AudioSource>();
        this.audioSource.clip = this.clickSound;
        this.audioSource.loop = false;  
    }


    void Update()
    {
        if(GBBool ==1)
            GBBuy = false;
        else if(GBBool ==0)
            GBBuy = true;
        
        GBBtn.GetComponent<Button>().interactable = GBBuy;

        
        if(PSBool ==1)
            PSBuy = false;
        else if(PSBool ==0)
            PSBuy = true;
        PSBtn.GetComponent<Button>().interactable = PSBuy;

        
        if(BBBool ==1)
            BBBuy = false;
        else if(BBBool ==0)
            BBBuy = true;
        BBBtn.GetComponent<Button>().interactable = BBBuy;

        
        if(NTBool ==1)
            NTBuy = false;
        else if(NTBool ==0)
            NTBuy = true;
        NTBtn.GetComponent<Button>().interactable = NTBuy;

        
        if(EFBool ==1)
            EFBuy = false;
        else if(EFBool ==0)
            EFBuy = true;
        EFBtn.GetComponent<Button>().interactable = EFBuy;

        
        if(BHBool ==1)
            BHBuy = false;
        else if(BHBool ==0)
            BHBuy = true;
        BHBtn.GetComponent<Button>().interactable = BHBuy;

        
        if(PMBool ==1)
            PMBuy = false;
        else if(PMBool ==0)
            PMBuy = true;
        PMBtn.GetComponent<Button>().interactable = PMBuy;

        PopulationManager pop = GameObject.Find("populationManager").GetComponent<PopulationManager>();

        if(currentGyeongbokCount == 0 && pop.population >= 500) {
            GBBool = 0;
            gyeongbokPrice.GetComponent<Text>().text = "$" + currentGyeongbokPrice + " ($/s +20%)";
        } else if(currentGyeongbokCount==1 && pop.population >= 500) {
            GBBool =1;
            gyeongbokPrice.GetComponent<Text>().text = "$" + currentGyeongbokPrice + " ($/s +20%, 적용중)";
        } else {
            GBBool = 1;
            gyeongbokPrice.GetComponent<Text>().text = "$" + currentGyeongbokPrice + " ($/s +20%, 인구500명 잠금해제)";
        }

        if(currentPisaCount == 0 && pop.population >=800) {
            PSBool = 0;
            pisaPrice.GetComponent<Text>().text = "$" + currentPisaPrice + " ($/s +20%)";
        } else if(currentPisaCount == 1 && pop.population >= 800) {
            PSBool =1;
            pisaPrice.GetComponent<Text>().text = "$" + currentPisaPrice + " ($/s +20%, 적용중)";
        } else {
            PSBool = 1;
            pisaPrice.GetComponent<Text>().text = "$" + currentPisaPrice + " ($/s +20%, 인구800명 잠금해제)";
        }

        if(currentBigbenCount == 0 && pop.population >= 1500) {
            BBBool = 0;
            bigbenPrice.GetComponent<Text>().text = "$" + currentBigbenPrice + " ($/s +20%)";
        } else if(currentBigbenCount == 1 && pop.population >= 1500) {
            BBBool =1;
            bigbenPrice.GetComponent<Text>().text = "$" + currentBigbenPrice + " ($/s +20%, 적용중)";
        } else {
            BBBool = 1;
            bigbenPrice.GetComponent<Text>().text = "$" + currentBigbenPrice + " ($/s +20%, 인구1500명 잠금해제)";
        }

        if(currentNortdamCount == 0 && pop.population >= 3000) {
            NTBool = 0;
            nortdamPrice.GetComponent<Text>().text = "$" + currentNortdamPrice + " ($/s +20%)";
        } else if(currentNortdamCount == 1 && pop.population >= 3000) {
            NTBool =1;
            nortdamPrice.GetComponent<Text>().text = "$" + currentNortdamPrice + " ($/s +20%, 적용중)";
        } else {
            NTBool = 1;
            nortdamPrice.GetComponent<Text>().text = "$" + currentNortdamPrice + " ($/s +20%, 인구3000명 잠금해제)";
        }

        if(currentEffelCount == 0 && pop.population >= 5000) {
            EFBool = 0;
            effelPrice.GetComponent<Text>().text = "$" + currentEffelPrice + " ($/s +20%)";
        } else if(currentEffelCount == 1 && pop.population >= 5000) {
            EFBool =1;
            effelPrice.GetComponent<Text>().text = "$" + currentEffelPrice + " ($/s +20%, 적용중)";
        } else {
            EFBool = 1;
            effelPrice.GetComponent<Text>().text = "$" + currentEffelPrice + " ($/s +20%, 인구5000명 잠금해제)";
        }

        if(currentBruzeCount == 0 && pop.population >= 8000) {
            BHBool = 0;
            bruzePrice.GetComponent<Text>().text = "$" + currentBruzePrice + " ($/s +20%)";
        } else if(currentBruzeCount == 1 && pop.population >= 8000) {
            BHBool =1;
            bruzePrice.GetComponent<Text>().text = "$" + currentBruzePrice + " ($/s +20%, 적용중)";
        } else {
            BHBool = 1;
            bruzePrice.GetComponent<Text>().text = "$" + currentBruzePrice + " ($/s +20%, 인구8000명 잠금해제)";
        }

        if(currentPyramidCount == 0 && pop.population >= 15000) {
            PMBool = 0;
            pyramidPrice.GetComponent<Text>().text = "$" + currentPyramidPrice + " ($/s +20%)";
        } else if(currentPyramidCount == 1 && pop.population >= 15000) {
            PMBool =1;
            pyramidPrice.GetComponent<Text>().text = "$" + currentPyramidPrice + " ($/s +20%, 적용중)";
        } else {
            PMBool = 1;
            pyramidPrice.GetComponent<Text>().text = "$" + currentPyramidPrice + " ($/s +20%, 인구15000명 잠금해제)";
        }
    }
    public void GotoLandStore() {
        landmarkRoom.SetActive(true);
        openCurrentLandmark.SetActive(false);
    }

    public void BuyGyeonbokBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();
        facilityStore currentFacCountFromFacStore = GameObject.Find("AutoMakeCash").GetComponent<facilityStore>();

        if (Click_Script.currentMoney >= currentGyeongbokPrice ) {
            Click_Script.updateMoney = Click_Script.updateMoney + Click_Script.updateMoney/10*2;

            Click_Script.currentMoney = Click_Script.currentMoney - currentGyeongbokPrice;
            GBBool = 1;
            currentGyeongbokCount =1;

            currentFacCountFromFacStore.plusShopMoney += currentFacCountFromFacStore.plusShopMoney/10*2;
            currentFacCountFromFacStore.plusStationMoney += currentFacCountFromFacStore.plusStationMoney/10*2;
            currentFacCountFromFacStore.plusChurchMoney += currentFacCountFromFacStore.plusChurchMoney/10*2;
            currentFacCountFromFacStore.plusBankMoney += currentFacCountFromFacStore.plusBankMoney/10*2;
            currentFacCountFromFacStore.plusHallMoney += currentFacCountFromFacStore.plusHallMoney/10*2;
            currentFacCountFromFacStore.plusHosMoney += currentFacCountFromFacStore.plusHosMoney/10*2;

            this.audioSource.Play();
        } 
    }
    public void BuyPisaBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();
        facilityStore currentFacCountFromFacStore = GameObject.Find("AutoMakeCash").GetComponent<facilityStore>();

        if (Click_Script.currentMoney >= currentPisaPrice ) {
            Click_Script.updateMoney = Click_Script.updateMoney + Click_Script.updateMoney/10*2;

            Click_Script.currentMoney = Click_Script.currentMoney - currentPisaPrice;
            PSBool = 1;
            currentPisaCount =1;

            currentFacCountFromFacStore.plusShopMoney += currentFacCountFromFacStore.plusShopMoney/10*2;
            currentFacCountFromFacStore.plusStationMoney += currentFacCountFromFacStore.plusStationMoney/10*2;
            currentFacCountFromFacStore.plusChurchMoney += currentFacCountFromFacStore.plusChurchMoney/10*2;
            currentFacCountFromFacStore.plusBankMoney += currentFacCountFromFacStore.plusBankMoney/10*2;
            currentFacCountFromFacStore.plusHallMoney += currentFacCountFromFacStore.plusHallMoney/10*2;
            currentFacCountFromFacStore.plusHosMoney += currentFacCountFromFacStore.plusHosMoney/10*2;

            this.audioSource.Play();
        } 
    }
    public void BuyBigbenBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();
        facilityStore currentFacCountFromFacStore = GameObject.Find("AutoMakeCash").GetComponent<facilityStore>();

        if (Click_Script.currentMoney >= currentBigbenPrice ) {
            Click_Script.updateMoney = Click_Script.updateMoney + Click_Script.updateMoney/10*2;
            Click_Script.currentMoney = Click_Script.currentMoney - currentBigbenPrice;
            BBBool = 1;
            currentBigbenCount =1;

            currentFacCountFromFacStore.plusShopMoney += currentFacCountFromFacStore.plusShopMoney/10*2;
            currentFacCountFromFacStore.plusStationMoney += currentFacCountFromFacStore.plusStationMoney/10*2;
            currentFacCountFromFacStore.plusChurchMoney += currentFacCountFromFacStore.plusChurchMoney/10*2;
            currentFacCountFromFacStore.plusBankMoney += currentFacCountFromFacStore.plusBankMoney/10*2;
            currentFacCountFromFacStore.plusHallMoney += currentFacCountFromFacStore.plusHallMoney/10*2;
            currentFacCountFromFacStore.plusHosMoney += currentFacCountFromFacStore.plusHosMoney/10*2;

            this.audioSource.Play();
        } 
    }
    public void BuyNortdamBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();
        facilityStore currentFacCountFromFacStore = GameObject.Find("AutoMakeCash").GetComponent<facilityStore>();

        if (Click_Script.currentMoney >= currentNortdamPrice ) {
            Click_Script.updateMoney = Click_Script.updateMoney + Click_Script.updateMoney/10*2;
            Click_Script.currentMoney = Click_Script.currentMoney - currentNortdamPrice;
            NTBool = 1;
            currentNortdamCount =1;

            currentFacCountFromFacStore.plusShopMoney += currentFacCountFromFacStore.plusShopMoney/10*2;
            currentFacCountFromFacStore.plusStationMoney += currentFacCountFromFacStore.plusStationMoney/10*2;
            currentFacCountFromFacStore.plusChurchMoney += currentFacCountFromFacStore.plusChurchMoney/10*2;
            currentFacCountFromFacStore.plusBankMoney += currentFacCountFromFacStore.plusBankMoney/10*2;
            currentFacCountFromFacStore.plusHallMoney += currentFacCountFromFacStore.plusHallMoney/10*2;
            currentFacCountFromFacStore.plusHosMoney += currentFacCountFromFacStore.plusHosMoney/10*2;

            this.audioSource.Play();
        } 
    }
    public void BuyEffelBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();
        facilityStore currentFacCountFromFacStore = GameObject.Find("AutoMakeCash").GetComponent<facilityStore>();

        if (Click_Script.currentMoney >= currentEffelPrice ) {
            Click_Script.updateMoney = Click_Script.updateMoney + Click_Script.updateMoney/10*2;
            Click_Script.currentMoney = Click_Script.currentMoney - currentEffelPrice;
            EFBool = 1;
            currentEffelCount=1;

            currentFacCountFromFacStore.plusShopMoney += currentFacCountFromFacStore.plusShopMoney/10*2;
            currentFacCountFromFacStore.plusStationMoney += currentFacCountFromFacStore.plusStationMoney/10*2;
            currentFacCountFromFacStore.plusChurchMoney += currentFacCountFromFacStore.plusChurchMoney/10*2;
            currentFacCountFromFacStore.plusBankMoney += currentFacCountFromFacStore.plusBankMoney/10*2;
            currentFacCountFromFacStore.plusHallMoney += currentFacCountFromFacStore.plusHallMoney/10*2;
            currentFacCountFromFacStore.plusHosMoney += currentFacCountFromFacStore.plusHosMoney/10*2;

            this.audioSource.Play();
        } 
    }
    public void BuybruzeBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();
        facilityStore currentFacCountFromFacStore = GameObject.Find("AutoMakeCash").GetComponent<facilityStore>();

        if (Click_Script.currentMoney >= currentBruzePrice ) {
            Click_Script.updateMoney = Click_Script.updateMoney + Click_Script.updateMoney/10*2;
            Click_Script.currentMoney = Click_Script.currentMoney - currentBruzePrice;
            BHBool = 1;
            currentBruzeCount =1;

            currentFacCountFromFacStore.plusShopMoney += currentFacCountFromFacStore.plusShopMoney/10*2;
            currentFacCountFromFacStore.plusStationMoney += currentFacCountFromFacStore.plusStationMoney/10*2;
            currentFacCountFromFacStore.plusChurchMoney += currentFacCountFromFacStore.plusChurchMoney/10*2;
            currentFacCountFromFacStore.plusBankMoney += currentFacCountFromFacStore.plusBankMoney/10*2;
            currentFacCountFromFacStore.plusHallMoney += currentFacCountFromFacStore.plusHallMoney/10*2;
            currentFacCountFromFacStore.plusHosMoney += currentFacCountFromFacStore.plusHosMoney/10*2;

            this.audioSource.Play();
        } 
    }
    public void BuyPyramidBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();
        facilityStore currentFacCountFromFacStore = GameObject.Find("AutoMakeCash").GetComponent<facilityStore>();

        if (Click_Script.currentMoney >= currentPyramidPrice ) {
            Click_Script.updateMoney = Click_Script.updateMoney + Click_Script.updateMoney/10*2;
            Click_Script.currentMoney = Click_Script.currentMoney - currentPyramidPrice;
            PMBool = 1;
            currentPyramidCount=1;

            currentFacCountFromFacStore.plusShopMoney += currentFacCountFromFacStore.plusShopMoney/10*2;
            currentFacCountFromFacStore.plusStationMoney += currentFacCountFromFacStore.plusStationMoney/10*2;
            currentFacCountFromFacStore.plusChurchMoney += currentFacCountFromFacStore.plusChurchMoney/10*2;
            currentFacCountFromFacStore.plusBankMoney += currentFacCountFromFacStore.plusBankMoney/10*2;
            currentFacCountFromFacStore.plusHallMoney += currentFacCountFromFacStore.plusHallMoney/10*2;
            currentFacCountFromFacStore.plusHosMoney += currentFacCountFromFacStore.plusHosMoney/10*2;

            this.audioSource.Play();
        } 
    }
}
