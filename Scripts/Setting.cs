using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Setting : MonoBehaviour
{
    public GameObject backButton;
    public GameObject resetButton;
    public GameObject savedata;
    public GameObject Click;
    public GameObject FAC;
    public GameObject HOUSE;
    public GameObject LV;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void settingBack() {
        backButton.SetActive(false);
    }
    public void GoSetting() {
        backButton.SetActive(true);
    }
    public void resetBack() {
        resetButton.SetActive(false);
    }
    public void Goreset() {
        resetButton.SetActive(true);
    }
    public void resetOn() {
        PlayerPrefs.DeleteAll();

        Click.GetComponent<Click_>().currentMoney = 0;
        Click.GetComponent<Click_>().clickPerCash = 1;
        
        LV.GetComponent<myLvup>().playerLevel = 1;
        LV.GetComponent<myLvup>().currentLvPrice = 100;
        LV.GetComponent<myLvup>().currnetUpdateTabperCash = 2;
        LV.GetComponent<myLvup>().currnetTabperCash = 20;
        LV.GetComponent<myLvup>().LvPlus25 = 25;

        FAC.GetComponent<facilityStore>().currentShopPrice = 1600;
        FAC.GetComponent<facilityStore>().currentStationPrice = 86400;
        FAC.GetComponent<facilityStore>().currentChurchPrice = 22118000;
        FAC.GetComponent<facilityStore>().currentBankPrice = 16588000000;
        FAC.GetComponent<facilityStore>().currentHallPrice = 28665000000000;
        FAC.GetComponent<facilityStore>().currentHospitalPrice = 98322000000000000;
        FAC.GetComponent<facilityStore>().plusShopMoney = 100;
        FAC.GetComponent<facilityStore>().plusStationMoney = 1300;
        FAC.GetComponent<facilityStore>().plusChurchMoney = 26000;
        FAC.GetComponent<facilityStore>().plusBankMoney = 860000;
        FAC.GetComponent<facilityStore>().plusHallMoney = 51000000;
        FAC.GetComponent<facilityStore>().plusHosMoney = 1400000000;
        FAC.GetComponent<facilityStore>().shopPlus25 = 25;
        FAC.GetComponent<facilityStore>().stationPlus25 = 25;
        FAC.GetComponent<facilityStore>().churchPlus25 = 25;
        FAC.GetComponent<facilityStore>().bankPlus25 = 25;
        FAC.GetComponent<facilityStore>().hallPlus25 = 25;
        FAC.GetComponent<facilityStore>().hosPlus25 = 25;

        HOUSE.GetComponent<houseStore>().currentPrice = 62500;

        PlayerPrefs.SetString("Money", Click.GetComponent<Click_>().currentMoney.ToString());
        PlayerPrefs.SetString("MoneyPerClick", Click.GetComponent<Click_>().clickPerCash.ToString());

        PlayerPrefs.SetString("currentLvPrice", LV.GetComponent<myLvup>().currentLvPrice.ToString());
        PlayerPrefs.SetString("Lvtabpercash", LV.GetComponent<myLvup>().currnetTabperCash.ToString());
        PlayerPrefs.SetInt("Lv", LV.GetComponent<myLvup>().playerLevel);
        PlayerPrefs.SetInt("Lvplus25", LV.GetComponent<myLvup>().LvPlus25);
        PlayerPrefs.SetString("LvtabperUpdatecash", LV.GetComponent<myLvup>().currnetUpdateTabperCash.ToString());

        PlayerPrefs.SetString("housePrice", HOUSE.GetComponent<houseStore>().currentPrice.ToString());

        PlayerPrefs.SetInt("shopPlus25", FAC.GetComponent<facilityStore>().shopPlus25);
        PlayerPrefs.SetInt("stationPlus25", FAC.GetComponent<facilityStore>().stationPlus25);
        PlayerPrefs.SetInt("churchPlus25", FAC.GetComponent<facilityStore>().churchPlus25);
        PlayerPrefs.SetInt("bankPlus25", FAC.GetComponent<facilityStore>().bankPlus25);
        PlayerPrefs.SetInt("hallPlus25", FAC.GetComponent<facilityStore>().hallPlus25);
        PlayerPrefs.SetInt("hosPlus25", FAC.GetComponent<facilityStore>().hosPlus25);

        PlayerPrefs.SetString("schoolPrice", FAC.GetComponent<facilityStore>().currentShopPrice.ToString());
        PlayerPrefs.SetString("libraryPrice", FAC.GetComponent<facilityStore>().currentStationPrice.ToString());
        PlayerPrefs.SetString("policePrice", FAC.GetComponent<facilityStore>().currentChurchPrice.ToString());
        PlayerPrefs.SetString("parkPrice", FAC.GetComponent<facilityStore>().currentBankPrice.ToString());
        PlayerPrefs.SetString("firePrice", FAC.GetComponent<facilityStore>().currentHallPrice.ToString());
        PlayerPrefs.SetString("hosPrice", FAC.GetComponent<facilityStore>().currentHospitalPrice.ToString());

        PlayerPrefs.SetString("schoolMoney", FAC.GetComponent<facilityStore>().plusShopMoney.ToString());
        PlayerPrefs.SetString("libraryMoney", FAC.GetComponent<facilityStore>().plusStationMoney.ToString());
        PlayerPrefs.SetString("policeMoney", FAC.GetComponent<facilityStore>().plusChurchMoney.ToString());
        PlayerPrefs.SetString("parkMoney", FAC.GetComponent<facilityStore>().plusBankMoney.ToString());
        PlayerPrefs.SetString("fireMoney", FAC.GetComponent<facilityStore>().plusHallMoney.ToString());
        PlayerPrefs.SetString("hosMoney", FAC.GetComponent<facilityStore>().plusHosMoney.ToString());

        //->여기는 에러 없음.

        savedata.GetComponent<SaveData>().Load();
        backButton.SetActive(false);
        resetButton.SetActive(false);
        Debug.Log("리셋성공");
    }
}
