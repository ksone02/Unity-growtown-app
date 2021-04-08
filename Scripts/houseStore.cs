using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class houseStore : MonoBehaviour
{
    public GameObject normalhouseCount, prehouseCount, apartmentCount, preApartCount, buildingCount, preBuildingCount;

    public GameObject normalhousePrice, prehousePrice, apartmentPrice, preApartPrice, buildingPrice, preBuildingPrice;

    public GameObject normalhouseImg, normalhouseImg2, normalhouseImg3, normalhouseImg4,
    prehouseImg, prehouseImg2, prehouseImg3, prehouseImg4,
    apartmentImg, apartmentImg2, apartmentImg3, apartmentImg4,
    preApartImg, preApartImg2, preApartImg3, preApartImg4,
    buildingImg, buildingImg2, buildingImg3, buildingImg4,
    preBuildingImg, preBuildingImg2, preBuildingImg3, preBuildingImg4;

    public GameObject houseStoreButton, openCurrentLandmark;

    public GameObject houseBtn, preHouseBtn, apartBtn, preApartBtn, buildingBtn, preBuildingBtn;

    public GameObject houseLock, preHouseLock, apartLock, preApartLock, buildingLock, preBuildingLock;

    public int currentHouseCount, currentPreHouseCount, currentApartmentCount, currentPreApartCount, currentBuildingCount, currentPreBuildingCount;
    public BigInteger currentPrice = 62500;
    public string saveCurrentPrice;

    private AudioSource audioSource;
    public AudioClip clickSound;

    void Start()
    {
        houseStoreButton.SetActive(false);

        this.audioSource = GameObject.Find("ButtonSound").GetComponent<AudioSource>();
        this.audioSource.clip = this.clickSound;
        this.audioSource.loop = false;   
    }

    void Update()
    {
        //버튼 텍스트 관리
        normalhouseCount.GetComponent<Text>().text = "일반 주택(" + currentHouseCount + "/4)";
        changeText(normalhousePrice);

        prehouseCount.GetComponent<Text>().text = "프리미엄 주택(" + currentPreHouseCount + "/4)";
        changeText(prehousePrice);

        apartmentCount.GetComponent<Text>().text = "일반 아파트(" + currentApartmentCount + "/4)";
        changeText(apartmentPrice);

        preApartCount.GetComponent<Text>().text = "프리미엄 아파트(" + currentPreApartCount + "/4)";
        changeText(preApartPrice);

        buildingCount.GetComponent<Text>().text = "빌딩(" + currentBuildingCount + "/4)";
        changeText(buildingPrice);

        preBuildingCount.GetComponent<Text>().text = "프리미엄 빌딩(" + currentPreBuildingCount + "/4)";
        changeText(preBuildingPrice);
        
        //이미지 생성 관리
        countImg(currentHouseCount, normalhouseImg, normalhouseImg2, normalhouseImg3, normalhouseImg4);
        countImg(currentPreHouseCount, prehouseImg, prehouseImg2, prehouseImg3, prehouseImg4);
        countImg(currentApartmentCount, apartmentImg, apartmentImg2, apartmentImg3, apartmentImg4);
        countImg(currentPreApartCount, preApartImg, preApartImg2, preApartImg3, preApartImg4);
        countImg(currentBuildingCount, buildingImg, buildingImg2, buildingImg3, buildingImg4);
        countImg(currentPreBuildingCount, preBuildingImg, preBuildingImg2, preBuildingImg3, preBuildingImg4);


        facilityStore fac_script = GameObject.Find("AutoMakeCash").GetComponent<facilityStore>();
        interactableHouseBtn(fac_script.currentShopCount, houseBtn, normalhousePrice, houseLock);
        interactableHouseBtn(fac_script.currentShopCount, preHouseBtn, prehousePrice, preHouseLock);
        interactableBtn(fac_script.currentStationCount, currentHouseCount, currentPreHouseCount, apartBtn, apartmentPrice, apartLock);
        interactableBtn(fac_script.currentStationCount, currentHouseCount, currentPreHouseCount, preApartBtn, preApartPrice, preApartLock);
        interactableBtn(fac_script.currentChurchCount, currentApartmentCount, currentPreApartCount, buildingBtn, buildingPrice, buildingLock);
        interactableBtn(fac_script.currentChurchCount, currentApartmentCount, currentPreApartCount, preBuildingBtn, preBuildingPrice, preBuildingLock);

        LimCount(currentHouseCount, houseBtn);
        LimCount(currentPreHouseCount, preHouseBtn);
        LimCount(currentApartmentCount, apartBtn);
        LimCount(currentPreApartCount, preApartBtn);
        LimCount(currentBuildingCount, buildingBtn);
        LimCount(currentPreBuildingCount, preBuildingBtn);
    }

    public void LimCount(int count, GameObject btn) {
        if(count >=4) {
            btn.GetComponent<Button>().interactable = false;
        }
    }

    public void interactableHouseBtn(int count, GameObject btn, GameObject price, GameObject lockBtn) { 
        Click_ click_script = GameObject.Find("TouchHere").GetComponent<Click_>();
        Color redColor = new Color(255/255f, 57/255f, 57/255f);
        if(count >= 1 && click_script.currentMoney >= currentPrice) {
            btn.GetComponent<Button>().interactable = true;
            lockBtn.SetActive(false);
            price.GetComponent<Text>().color = Color.black;
        } else if(count>=1 && click_script.currentMoney <= currentPrice){
            btn.GetComponent<Button>().interactable = false;
            price.GetComponent<Text>().color = redColor;
            lockBtn.SetActive(false);
        } else if(count< 1) {
            btn.GetComponent<Button>().interactable = false;
            lockBtn.SetActive(true);
        }
    }
    public void interactableBtn(int count,int first, int second, GameObject btn, GameObject price, GameObject lockBtn) { 
        Click_ click_script = GameObject.Find("TouchHere").GetComponent<Click_>();
        Color redColor = new Color(255/255f, 57/255f, 57/255f);
        if(count >= 1 && first + second >= 5 && click_script.currentMoney >= currentPrice) {
            btn.GetComponent<Button>().interactable = true;
            price.GetComponent<Text>().color = Color.black;
            lockBtn.SetActive(false);
        } else if(count >= 1 && first + second >= 5 && click_script.currentMoney <= currentPrice){
            btn.GetComponent<Button>().interactable = false;
            price.GetComponent<Text>().color = redColor;
            lockBtn.SetActive(false);
        } else if(count <= 1 || first + second <= 5) {
            lockBtn.SetActive(true);
            btn.GetComponent<Button>().interactable = false;
            price.GetComponent<Text>().color = Color.black;
        }
    }

    public void changePrice() {
        int allCount = currentHouseCount + currentPreHouseCount + currentApartmentCount + currentPreApartCount + currentBuildingCount + currentPreBuildingCount;

        if(allCount < 2 && allCount >= 1) {
            currentPrice *= 5;
        } else if (allCount == 2) {
            currentPrice *= (long)53.24;
        } else if (allCount <9 && allCount >=3) {
            currentPrice *= 11;
        } else if (allCount < 59 && allCount >= 9) {
            currentPrice *= 7;
        }
    }

    public void countImg(int currentCount, GameObject HouseImg, GameObject HouseImg2, GameObject HouseImg3, GameObject HouseImg4) {
        if(currentCount == 1) {
            HouseImg.SetActive(true);
            HouseImg2.SetActive(false);
            HouseImg3.SetActive(false);
            HouseImg4.SetActive(false);
        } else if(currentCount == 2) {
            HouseImg.SetActive(true);
            HouseImg2.SetActive(true);
            HouseImg3.SetActive(false);
            HouseImg4.SetActive(false);
        } else if(currentCount == 3) {
            HouseImg.SetActive(true);
            HouseImg2.SetActive(true);
            HouseImg3.SetActive(true);
            HouseImg4.SetActive(false);
        } else if(currentCount == 4) {
            HouseImg.SetActive(true);
            HouseImg2.SetActive(true);
            HouseImg3.SetActive(true);
            HouseImg4.SetActive(true);
        } else if(currentCount == 0) {
            HouseImg.SetActive(false);
            HouseImg2.SetActive(false);
            HouseImg3.SetActive(false);
            HouseImg4.SetActive(false);
        }
    }

    public void GotoHouseStore() {
        houseStoreButton.SetActive(true);
        openCurrentLandmark.SetActive(false);
    }

    public void BuyNormalHouseBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();
        PopulationManager population_Script = GameObject.Find("populationManager").GetComponent<PopulationManager>();
        myLvup lv_script = GameObject.Find("AutoMakeCash").GetComponent<myLvup>();
        facilityStore fac_script = GameObject.Find("AutoMakeCash").GetComponent<facilityStore>();

        if (Click_Script.currentMoney >= currentPrice ) {
            population_Script.population = population_Script.population +5;
            currentHouseCount
            ++;
            Click_Script.currentMoney = Click_Script.currentMoney - currentPrice;

            //탭당돈, 초당돈 2배증가
            lv_script.currnetTabperCash *= 2;
            lv_script.currnetUpdateTabperCash *= 2;
            fac_script.plusShopMoney *= 2;
            fac_script.plusStationMoney *= 2;
            fac_script.plusChurchMoney *= 2;
            fac_script.plusBankMoney *= 2;
            fac_script.plusHallMoney *= 2;
            fac_script.plusHosMoney *= 2;

            //구매기준 가격변경
            changePrice();

            this.audioSource.Play();
        } else {

        }
    }

    public void BuyPremiumHouseBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();
        PopulationManager population_Script = GameObject.Find("populationManager").GetComponent<PopulationManager>();
        myLvup lv_script = GameObject.Find("AutoMakeCash").GetComponent<myLvup>();
        facilityStore fac_script = GameObject.Find("AutoMakeCash").GetComponent<facilityStore>();

        if (Click_Script.currentMoney >= currentPrice ) {
            population_Script.population = population_Script.population + 15;
            
            currentPreHouseCount++;
            Click_Script.currentMoney = Click_Script.currentMoney - currentPrice;

            //탭당돈, 초당돈 2배증가
            lv_script.currnetTabperCash *= 2;
            fac_script.plusShopMoney *= 2;
            fac_script.plusStationMoney *= 2;
            fac_script.plusChurchMoney *= 2;
            fac_script.plusBankMoney *= 2;
            fac_script.plusHallMoney *= 2;
            fac_script.plusHosMoney *= 2;

            //구매기준 가격변경
            changePrice();

            this.audioSource.Play();
        } else {

        }
    }

    public void BuyApartBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();
        PopulationManager population_Script = GameObject.Find("populationManager").GetComponent<PopulationManager>();
        myLvup lv_script = GameObject.Find("AutoMakeCash").GetComponent<myLvup>();
        facilityStore fac_script = GameObject.Find("AutoMakeCash").GetComponent<facilityStore>();

        if (Click_Script.currentMoney >= currentPrice ) {
            population_Script.population = population_Script.population + 40;
            
            currentApartmentCount++;
            Click_Script.currentMoney = Click_Script.currentMoney - currentPrice;

            //탭당돈, 초당돈 2배증가
            lv_script.currnetTabperCash *= 2;
            fac_script.plusShopMoney *= 2;
            fac_script.plusStationMoney *= 2;
            fac_script.plusChurchMoney *= 2;
            fac_script.plusBankMoney *= 2;
            fac_script.plusHallMoney *= 2;
            fac_script.plusHosMoney *= 2;

            //구매기준 가격변경
            changePrice();

            this.audioSource.Play();
        } else {

        }
    }

    public void BuyPreApartBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();
        PopulationManager population_Script = GameObject.Find("populationManager").GetComponent<PopulationManager>();
        myLvup lv_script = GameObject.Find("AutoMakeCash").GetComponent<myLvup>();
        facilityStore fac_script = GameObject.Find("AutoMakeCash").GetComponent<facilityStore>();

        if (Click_Script.currentMoney >= currentPrice ) {
            population_Script.population = population_Script.population + 90;
            
            currentPreApartCount++;
            Click_Script.currentMoney = Click_Script.currentMoney - currentPrice;

            //탭당돈, 초당돈 2배증가
            lv_script.currnetTabperCash *= 2;
            fac_script.plusShopMoney *= 2;
            fac_script.plusStationMoney *= 2;
            fac_script.plusChurchMoney *= 2;
            fac_script.plusBankMoney *= 2;
            fac_script.plusHallMoney *= 2;
            fac_script.plusHosMoney *= 2;

            //구매기준 가격변경
            changePrice();

            this.audioSource.Play();
        } else {

        }
    }
    public void BuyBuildingBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();
        PopulationManager population_Script = GameObject.Find("populationManager").GetComponent<PopulationManager>();
        myLvup lv_script = GameObject.Find("AutoMakeCash").GetComponent<myLvup>();
        facilityStore fac_script = GameObject.Find("AutoMakeCash").GetComponent<facilityStore>();

        if (Click_Script.currentMoney >= currentPrice ) {
            population_Script.population = population_Script.population + 150;
            
            currentBuildingCount++;
            Click_Script.currentMoney = Click_Script.currentMoney - currentPrice;

            //탭당돈, 초당돈 2배증가
            lv_script.currnetTabperCash *= 2;
            fac_script.plusShopMoney *= 2;
            fac_script.plusStationMoney *= 2;
            fac_script.plusChurchMoney *= 2;
            fac_script.plusBankMoney *= 2;
            fac_script.plusHallMoney *= 2;
            fac_script.plusHosMoney *= 2;

            //구매기준 가격변경
            changePrice();

            this.audioSource.Play();
        } else {

        }
    }
    
    public void BuyPreBuildingBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();
        PopulationManager population_Script = GameObject.Find("populationManager").GetComponent<PopulationManager>();
        myLvup lv_script = GameObject.Find("AutoMakeCash").GetComponent<myLvup>();
        facilityStore fac_script = GameObject.Find("AutoMakeCash").GetComponent<facilityStore>();

        if (Click_Script.currentMoney >= currentPrice ) {
            population_Script.population = population_Script.population + 350;
            
            currentPreBuildingCount++;
            Click_Script.currentMoney = Click_Script.currentMoney - currentPrice;

            //탭당돈, 초당돈 2배증가
            lv_script.currnetTabperCash *= 2;
            fac_script.plusShopMoney *= 2;
            fac_script.plusStationMoney *= 2;
            fac_script.plusChurchMoney *= 2;
            fac_script.plusBankMoney *= 2;
            fac_script.plusHallMoney *= 2;
            fac_script.plusHosMoney *= 2;

            //구매기준 가격변경
            changePrice();

            this.audioSource.Play();
        } else {

        }
    }
    public void changeText(GameObject priceObject) {
        if(currentPrice < 1000000 && currentPrice >= 1000) {
            priceObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentPrice/1000) + "A" + " $/탭, $/s 두배 증가";
        } else if(currentPrice < 1000000000 && currentPrice >= 1000000) {
            priceObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentPrice/1000000) + "B" + " $/탭, $/s 두배 증가"; 
        } else if(currentPrice < 1000) {
            priceObject.GetComponent<Text>().text = "$" + currentPrice.ToString() + " $/탭, $/s 두배 증가";
        } else if(currentPrice >= 1000000000 && currentPrice<1000000000000) {
            priceObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentPrice/1000000000) + "C" + " $/탭, $/s 두배 증가";
        } else if(currentPrice >= 1000000000000 && currentPrice<1000000000000000) {
            priceObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentPrice/1000000000000) + "D" + " $/탭, $/s 두배 증가";
        } else if(currentPrice >= 1000000000000000 && currentPrice<1000000000000000000) {
            priceObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentPrice/1000000000000000) + "E" + " $/탭, $/s 두배 증가";
        } else if(currentPrice >= 1000000000000000000 && currentPrice<BigInteger.Parse("1000000000000000000000")) {
            priceObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentPrice/1000000000000000000) + "F" + " $/탭, $/s 두배 증가";
        } else if(currentPrice >= BigInteger.Parse("1000000000000000000000") && currentPrice<BigInteger.Parse("1000000000000000000000000")) {
            priceObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentPrice/(double)BigInteger.Parse("1000000000000000000000")) + "G" + " $/탭, $/s 두배 증가";
        } else if(currentPrice >= BigInteger.Parse("1000000000000000000000000") && currentPrice<BigInteger.Parse("1000000000000000000000000000")) {
            priceObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentPrice/(double)BigInteger.Parse("1000000000000000000000000")) + "H" + " $/탭, $/s 두배 증가";
        } else if(currentPrice >= BigInteger.Parse("1000000000000000000000000000") && currentPrice<BigInteger.Parse("1000000000000000000000000000000")) {
            priceObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentPrice/(double)BigInteger.Parse("1000000000000000000000000000")) + "I" + " $/탭, $/s 두배 증가";
        } else {
            priceObject.GetComponent<Text>().text = "$" + currentPrice.ToString();
        }
    }
}
