using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Numerics;

public class SaveData : MonoBehaviour
{
    public GameObject Click;
    public GameObject Lv;
    public GameObject HouseData;
    public GameObject FacData;
    public GameObject Population;
    public GameObject LandMark;

    int BackCount = 0;

    void Awake() {
        Load();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            BackCount++;
            if(!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);
        } else if (BackCount == 2) {
            CancelInvoke("DoubleClick");
            Application.Quit();
        }
    }

    void DoubleClick() {
        BackCount = 0;
    }

    public void Save() {
        Debug.Log("저장 성공");
        //Click.GetComponent<Click_>().currentMoney = 5000000000;
        //레벨 저장
        PlayerPrefs.SetInt("Lv", Lv.GetComponent<myLvup>().playerLevel);
        PlayerPrefs.SetInt("Lvplus25", Lv.GetComponent<myLvup>().LvPlus25);
        PlayerPrefs.SetString("currentLvPrice", Lv.GetComponent<myLvup>().currentLvPrice.ToString());
        PlayerPrefs.SetString("Lvtabpercash", Lv.GetComponent<myLvup>().currnetTabperCash.ToString());
        PlayerPrefs.SetString("LvtabperUpdatecash", Lv.GetComponent<myLvup>().currnetUpdateTabperCash.ToString());

        //Click_ 저장
        PlayerPrefs.SetString("Money", Click.GetComponent<Click_>().currentMoney.ToString());
        PlayerPrefs.SetString("MoneyPerSec", Click.GetComponent<Click_>().updateMoney.ToString());
        PlayerPrefs.SetString("MoneyPerClick", Click.GetComponent<Click_>().clickPerCash.ToString());

        PlayerPrefs.SetString("schoolUpdate", Click.GetComponent<Click_>().shopUpdateMoney.ToString());
        PlayerPrefs.SetString("libraryUpdate", Click.GetComponent<Click_>().stationUpdateMoney.ToString());
        PlayerPrefs.SetString("policeUpdate", Click.GetComponent<Click_>().churchUpdateMoney.ToString());
        PlayerPrefs.SetString("parkUpdate", Click.GetComponent<Click_>().bankUpdateMoney.ToString());
        PlayerPrefs.SetString("fireUpdate", Click.GetComponent<Click_>().hallUpdateMoney.ToString());
        PlayerPrefs.SetString("hosUpdate", Click.GetComponent<Click_>().hospitalUpdateMoney.ToString());


        //집 저장
        PlayerPrefs.SetInt("normalHouseCount", HouseData.GetComponent<houseStore>().currentHouseCount);
        PlayerPrefs.SetInt("preHouseCount", HouseData.GetComponent<houseStore>().currentPreHouseCount);
        PlayerPrefs.SetInt("apartCount", HouseData.GetComponent<houseStore>().currentApartmentCount);
        PlayerPrefs.SetInt("preApartCount", HouseData.GetComponent<houseStore>().currentPreApartCount);
        PlayerPrefs.SetInt("buildingCount", HouseData.GetComponent<houseStore>().currentBuildingCount);
        PlayerPrefs.SetInt("preBuildingCount", HouseData.GetComponent<houseStore>().currentPreBuildingCount);

        PlayerPrefs.SetString("housePrice", HouseData.GetComponent<houseStore>().currentPrice.ToString());

        
        //기반시설 저장
        PlayerPrefs.SetInt("schoolCount", FacData.GetComponent<facilityStore>().currentShopCount);
        PlayerPrefs.SetInt("libraryCount", FacData.GetComponent<facilityStore>().currentStationCount);
        PlayerPrefs.SetInt("policeCount", FacData.GetComponent<facilityStore>().currentChurchCount);
        PlayerPrefs.SetInt("parkCount", FacData.GetComponent<facilityStore>().currentBankCount);
        PlayerPrefs.SetInt("fireCount", FacData.GetComponent<facilityStore>().currentHallCount);
        PlayerPrefs.SetInt("hosCount", FacData.GetComponent<facilityStore>().currentHospitalCount);

        PlayerPrefs.SetInt("shopPlus25", FacData.GetComponent<facilityStore>().shopPlus25);
        PlayerPrefs.SetInt("stationPlus25", FacData.GetComponent<facilityStore>().stationPlus25);
        PlayerPrefs.SetInt("churchPlus25", FacData.GetComponent<facilityStore>().churchPlus25);
        PlayerPrefs.SetInt("bankPlus25", FacData.GetComponent<facilityStore>().bankPlus25);
        PlayerPrefs.SetInt("hallPlus25", FacData.GetComponent<facilityStore>().hallPlus25);
        PlayerPrefs.SetInt("hosPlus25", FacData.GetComponent<facilityStore>().hosPlus25);

        PlayerPrefs.SetString("schoolPrice", FacData.GetComponent<facilityStore>().currentShopPrice.ToString());
        PlayerPrefs.SetString("libraryPrice", FacData.GetComponent<facilityStore>().currentStationPrice.ToString());
        PlayerPrefs.SetString("policePrice", FacData.GetComponent<facilityStore>().currentChurchPrice.ToString());
        PlayerPrefs.SetString("parkPrice", FacData.GetComponent<facilityStore>().currentBankPrice.ToString());
        PlayerPrefs.SetString("firePrice", FacData.GetComponent<facilityStore>().currentHallPrice.ToString());
        PlayerPrefs.SetString("hosPrice", FacData.GetComponent<facilityStore>().currentHospitalPrice.ToString());

        PlayerPrefs.SetString("schoolMoney", FacData.GetComponent<facilityStore>().plusShopMoney.ToString());
        PlayerPrefs.SetString("libraryMoney", FacData.GetComponent<facilityStore>().plusStationMoney.ToString());
        PlayerPrefs.SetString("policeMoney", FacData.GetComponent<facilityStore>().plusChurchMoney.ToString());
        PlayerPrefs.SetString("parkMoney", FacData.GetComponent<facilityStore>().plusBankMoney.ToString());
        PlayerPrefs.SetString("fireMoney", FacData.GetComponent<facilityStore>().plusHallMoney.ToString());
        PlayerPrefs.SetString("hosMoney", FacData.GetComponent<facilityStore>().plusHosMoney.ToString());

        //인구 저장
        PlayerPrefs.SetInt("population", Population.GetComponent<PopulationManager>().population);

        //랜드마크 저장
        PlayerPrefs.SetInt("gyeongbok", LandMark.GetComponent<landmarkStore>().GBBool);
        PlayerPrefs.SetInt("pisa", LandMark.GetComponent<landmarkStore>().PSBool);
        PlayerPrefs.SetInt("bigben", LandMark.GetComponent<landmarkStore>().BBBool);
        PlayerPrefs.SetInt("nortdam", LandMark.GetComponent<landmarkStore>().NTBool);
        PlayerPrefs.SetInt("effel", LandMark.GetComponent<landmarkStore>().EFBool);
        PlayerPrefs.SetInt("bruze", LandMark.GetComponent<landmarkStore>().BHBool);
        PlayerPrefs.SetInt("pyramid", LandMark.GetComponent<landmarkStore>().PMBool);

        PlayerPrefs.SetInt("gyeongbokCount", LandMark.GetComponent<landmarkStore>().currentGyeongbokCount);
        PlayerPrefs.SetInt("pisaCount", LandMark.GetComponent<landmarkStore>().currentPisaCount);
        PlayerPrefs.SetInt("bigbenCount", LandMark.GetComponent<landmarkStore>().currentBigbenCount);
        PlayerPrefs.SetInt("nortdamCount", LandMark.GetComponent<landmarkStore>().currentNortdamCount);
        PlayerPrefs.SetInt("effelCount", LandMark.GetComponent<landmarkStore>().currentEffelCount);
        PlayerPrefs.SetInt("bruzeCount", LandMark.GetComponent<landmarkStore>().currentBruzeCount);
        PlayerPrefs.SetInt("pyramidCount", LandMark.GetComponent<landmarkStore>().currentPyramidCount);

        PlayerPrefs.Save();
    }

    public void Load() {
        if(PlayerPrefs.HasKey("Money")) {
            Debug.Log("불러오기성공");

            //레벨 불러오기
            if(!PlayerPrefs.HasKey("currentLvPrice")) {
                PlayerPrefs.SetString("currentLvPrice", "100");
            }
            if(!PlayerPrefs.HasKey("Lvtabpercash")) {
                PlayerPrefs.SetString("Lvtabpercash", "20");
            }
            if(!PlayerPrefs.HasKey("LvtabperUpdatecash")) {
                PlayerPrefs.SetString("LvtabperUpdatecash", "2");
            }
            Lv.GetComponent<myLvup>().saveCurrentLvPrice = PlayerPrefs.GetString("currentLvPrice");
            Lv.GetComponent<myLvup>().currentLvPrice = BigInteger.Parse(Lv.GetComponent<myLvup>().saveCurrentLvPrice);

            Lv.GetComponent<myLvup>().saveCurrentUpdateTabperCash = PlayerPrefs.GetString("LvtabperUpdatecash");
            Lv.GetComponent<myLvup>().currnetUpdateTabperCash = BigInteger.Parse(Lv.GetComponent<myLvup>().saveCurrentUpdateTabperCash);

            Lv.GetComponent<myLvup>().playerLevel = PlayerPrefs.GetInt("Lv");
            Lv.GetComponent<myLvup>().LvPlus25 = PlayerPrefs.GetInt("Lvplus25");

            Lv.GetComponent<myLvup>().saveCurrentTabperCash = PlayerPrefs.GetString("Lvtabpercash");
            Lv.GetComponent<myLvup>().currnetTabperCash = BigInteger.Parse(Lv.GetComponent<myLvup>().saveCurrentTabperCash);

            //돈관련 불러오기(Click)
            Click.GetComponent<Click_>().saveCurrentMoney = PlayerPrefs.GetString("Money");
            Click.GetComponent<Click_>().currentMoney = BigInteger.Parse(Click.GetComponent<Click_>().saveCurrentMoney);

            Click.GetComponent<Click_>().saveclickPerCash = PlayerPrefs.GetString("MoneyPerClick");
            Click.GetComponent<Click_>().clickPerCash = BigInteger.Parse(Click.GetComponent<Click_>().saveclickPerCash);
            
            //집 불러오기
            HouseData.GetComponent<houseStore>().currentHouseCount = PlayerPrefs.GetInt("normalHouseCount");
            HouseData.GetComponent<houseStore>().currentPreHouseCount = PlayerPrefs.GetInt("preHouseCount");
            HouseData.GetComponent<houseStore>().currentApartmentCount = PlayerPrefs.GetInt("apartCount");
            HouseData.GetComponent<houseStore>().currentPreApartCount = PlayerPrefs.GetInt("preApartCount");
            HouseData.GetComponent<houseStore>().currentBuildingCount = PlayerPrefs.GetInt("buildingCount");
            HouseData.GetComponent<houseStore>().currentPreBuildingCount = PlayerPrefs.GetInt("preBuildingCount");

            HouseData.GetComponent<houseStore>().saveCurrentPrice = PlayerPrefs.GetString("housePrice");
            HouseData.GetComponent<houseStore>().currentPrice = BigInteger.Parse(HouseData.GetComponent<houseStore>().saveCurrentPrice);

            //기반시설 불러오기
            FacData.GetComponent<facilityStore>().currentShopCount = PlayerPrefs.GetInt("schoolCount");
            FacData.GetComponent<facilityStore>().currentStationCount = PlayerPrefs.GetInt("libraryCount");
            FacData.GetComponent<facilityStore>().currentChurchCount = PlayerPrefs.GetInt("policeCount");
            FacData.GetComponent<facilityStore>().currentBankCount = PlayerPrefs.GetInt("parkCount");
            FacData.GetComponent<facilityStore>().currentHallCount = PlayerPrefs.GetInt("fireCount");
            FacData.GetComponent<facilityStore>().currentHospitalCount = PlayerPrefs.GetInt("hosCount");

            FacData.GetComponent<facilityStore>().saveShopPrice = PlayerPrefs.GetString("schoolPrice");
            FacData.GetComponent<facilityStore>().currentShopPrice = BigInteger.Parse(FacData.GetComponent<facilityStore>().saveShopPrice);
            FacData.GetComponent<facilityStore>().saveStationPrice = PlayerPrefs.GetString("libraryPrice");
            FacData.GetComponent<facilityStore>().currentStationPrice = BigInteger.Parse(FacData.GetComponent<facilityStore>().saveStationPrice);
            FacData.GetComponent<facilityStore>().saveChurchPrice = PlayerPrefs.GetString("policePrice");
            FacData.GetComponent<facilityStore>().currentChurchPrice = BigInteger.Parse(FacData.GetComponent<facilityStore>().saveChurchPrice);
            FacData.GetComponent<facilityStore>().saveBankPrice = PlayerPrefs.GetString("parkPrice");
            FacData.GetComponent<facilityStore>().currentBankPrice = BigInteger.Parse(FacData.GetComponent<facilityStore>().saveBankPrice);
            FacData.GetComponent<facilityStore>().saveHallPrice = PlayerPrefs.GetString("firePrice");
            FacData.GetComponent<facilityStore>().currentHallPrice = BigInteger.Parse(FacData.GetComponent<facilityStore>().saveHallPrice);
            FacData.GetComponent<facilityStore>().saveHospitalPrice = PlayerPrefs.GetString("hosPrice");
            FacData.GetComponent<facilityStore>().currentHospitalPrice = BigInteger.Parse(FacData.GetComponent<facilityStore>().saveHospitalPrice);

            FacData.GetComponent<facilityStore>().shopPlus25 = PlayerPrefs.GetInt("shopPlus25");
            FacData.GetComponent<facilityStore>().stationPlus25 = PlayerPrefs.GetInt("stationPlus25");
            FacData.GetComponent<facilityStore>().churchPlus25 = PlayerPrefs.GetInt("churchPlus25");
            FacData.GetComponent<facilityStore>().bankPlus25 = PlayerPrefs.GetInt("bankPlus25");
            FacData.GetComponent<facilityStore>().hallPlus25 = PlayerPrefs.GetInt("hallPlus25");
            FacData.GetComponent<facilityStore>().hosPlus25 = PlayerPrefs.GetInt("hosPlus25");

            FacData.GetComponent<facilityStore>().savePlusShop = PlayerPrefs.GetString("schoolMoney");
            FacData.GetComponent<facilityStore>().plusShopMoney = BigInteger.Parse(FacData.GetComponent<facilityStore>().savePlusShop);
            FacData.GetComponent<facilityStore>().savePlusStation = PlayerPrefs.GetString("libraryMoney");
            FacData.GetComponent<facilityStore>().plusStationMoney = BigInteger.Parse(FacData.GetComponent<facilityStore>().savePlusStation);
            FacData.GetComponent<facilityStore>().savePlusChurch = PlayerPrefs.GetString("policeMoney");
            FacData.GetComponent<facilityStore>().plusChurchMoney = BigInteger.Parse(FacData.GetComponent<facilityStore>().savePlusChurch);
            FacData.GetComponent<facilityStore>().savePlusBank = PlayerPrefs.GetString("parkMoney");
            FacData.GetComponent<facilityStore>().plusBankMoney = BigInteger.Parse(FacData.GetComponent<facilityStore>().savePlusBank);
            FacData.GetComponent<facilityStore>().savePlusHall = PlayerPrefs.GetString("fireMoney");
            FacData.GetComponent<facilityStore>().plusHallMoney = BigInteger.Parse(FacData.GetComponent<facilityStore>().savePlusHall);
            FacData.GetComponent<facilityStore>().savePlusHospital = PlayerPrefs.GetString("hosMoney");
            FacData.GetComponent<facilityStore>().plusHosMoney = BigInteger.Parse(FacData.GetComponent<facilityStore>().savePlusHospital);

            //인구 불러오기
            Population.GetComponent<PopulationManager>().population = PlayerPrefs.GetInt("population");

            //랜드마크 불러오기
            LandMark.GetComponent<landmarkStore>().GBBool = PlayerPrefs.GetInt("gyeongbok");
            LandMark.GetComponent<landmarkStore>().PSBool = PlayerPrefs.GetInt("pisa");
            LandMark.GetComponent<landmarkStore>().BBBool = PlayerPrefs.GetInt("bigben");
            LandMark.GetComponent<landmarkStore>().NTBool = PlayerPrefs.GetInt("nortdam");
            LandMark.GetComponent<landmarkStore>().EFBool = PlayerPrefs.GetInt("effel");
            LandMark.GetComponent<landmarkStore>().BHBool = PlayerPrefs.GetInt("bruze");
            LandMark.GetComponent<landmarkStore>().PMBool = PlayerPrefs.GetInt("pyramid");
            LandMark.GetComponent<landmarkStore>().currentGyeongbokCount = PlayerPrefs.GetInt("gyeongbokCount");
            LandMark.GetComponent<landmarkStore>().currentPisaCount = PlayerPrefs.GetInt("pisaCount");
            LandMark.GetComponent<landmarkStore>().currentBigbenCount = PlayerPrefs.GetInt("bigbenCount");
            LandMark.GetComponent<landmarkStore>().currentNortdamCount = PlayerPrefs.GetInt("nortdamCount");
            LandMark.GetComponent<landmarkStore>().currentEffelCount = PlayerPrefs.GetInt("effelCount");
            LandMark.GetComponent<landmarkStore>().currentBruzeCount = PlayerPrefs.GetInt("bruzeCount");
            LandMark.GetComponent<landmarkStore>().currentPyramidCount = PlayerPrefs.GetInt("pyramidCount");


            //에러 fix
            if(!PlayerPrefs.HasKey("MoneyPerSec")) {
                PlayerPrefs.SetString("MoneyPerSec", "0");
            }
            Click.GetComponent<Click_>().saveupdateMoney = PlayerPrefs.GetString("MoneyPerSec");
            Click.GetComponent<Click_>().updateMoney = BigInteger.Parse(Click.GetComponent<Click_>().saveupdateMoney);

            if(!PlayerPrefs.HasKey("schoolUpdate")) {
                PlayerPrefs.SetString("schoolUpdate", "0");
            }
            Click.GetComponent<Click_>().saveshopUpdateMoney = PlayerPrefs.GetString("schoolUpdate");
            Click.GetComponent<Click_>().shopUpdateMoney = BigInteger.Parse(Click.GetComponent<Click_>().saveshopUpdateMoney);

            if(!PlayerPrefs.HasKey("libraryUpdate")) {
                PlayerPrefs.SetString("libraryUpdate", "0");
            }
            Click.GetComponent<Click_>().savestationUpdateMoney = PlayerPrefs.GetString("libraryUpdate");
            Click.GetComponent<Click_>().stationUpdateMoney = BigInteger.Parse(Click.GetComponent<Click_>().savestationUpdateMoney);

            if(!PlayerPrefs.HasKey("policeUpdate")) {
                PlayerPrefs.SetString("policeUpdate", "0");
            }
            Click.GetComponent<Click_>().savechurchUpdateMoney = PlayerPrefs.GetString("policeUpdate");
            Click.GetComponent<Click_>().churchUpdateMoney = BigInteger.Parse(Click.GetComponent<Click_>().savechurchUpdateMoney);

            if(!PlayerPrefs.HasKey("parkUpdate")) {
                PlayerPrefs.SetString("parkUpdate", "0");
            }
            Click.GetComponent<Click_>().savebankUpdateMoney = PlayerPrefs.GetString("parkUpdate");
            Click.GetComponent<Click_>().bankUpdateMoney = BigInteger.Parse(Click.GetComponent<Click_>().savebankUpdateMoney);

            if(!PlayerPrefs.HasKey("fireUpdate")) {
                PlayerPrefs.SetString("fireUpdate", "0");
            }
            Click.GetComponent<Click_>().savehallUpdateMoney = PlayerPrefs.GetString("fireUpdate");
            Click.GetComponent<Click_>().hallUpdateMoney = BigInteger.Parse(Click.GetComponent<Click_>().savehallUpdateMoney);

            if(!PlayerPrefs.HasKey("hosUpdate")) {
                PlayerPrefs.SetString("hosUpdate", "0");
            }
            Click.GetComponent<Click_>().savehospitalUpdateMoney = PlayerPrefs.GetString("hosUpdate");
            Click.GetComponent<Click_>().hospitalUpdateMoney = BigInteger.Parse(Click.GetComponent<Click_>().savehospitalUpdateMoney);



        } else {
            Debug.Log("불러오기실패");
        }
    }

    private void OnApplicationQuit() {
        Save();
    }

    private void OnApplicationPause() {
        Save();
    }
}
