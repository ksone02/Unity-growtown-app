using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class facilityStore : MonoBehaviour
{
    public GameObject shopCount, stationCount, churchCount, bankCount, hallCount, hospitalCount;

    public GameObject shopPrice, stationPrice, churchPrice, bankPrice, hallPrice, hospitalPrice;

    public GameObject shopImg, stationImg, churchImg, bankImg, hallImg, hospitalImg;

    public GameObject shopBtn, stationBtn, churchBtn, bankBtn, hallBtn, hosBtn;

    public GameObject facilityRoom, openCurrentLandmark;

    public GameObject shopUpdateBtn, stationUpdateBtn, churchUpdateBtn, bankUpdateBtn, hallUpdateBtn, hosUpdateBtn;
    public GameObject shopUpdateBtnTxt, stationUpdateBtnTxt, churchUpdateBtnTxt, bankUpdateBtnTxt, hallUpdateBtnTxt, hosUpdateBtnTxt;


    public int currentShopCount, currentStationCount, currentChurchCount, currentBankCount, currentHallCount, currentHospitalCount;
    public BigInteger currentShopPrice = 1600, currentStationPrice = 86400, currentChurchPrice = 22118000, currentBankPrice = 16588000000, currentHallPrice = 28665000000000, currentHospitalPrice = 98322000000000000;
    public string saveShopPrice, saveStationPrice, saveChurchPrice, saveBankPrice, saveHallPrice, saveHospitalPrice;
    public BigInteger plusShopMoney = 100, plusStationMoney = 1300, plusChurchMoney = 26000, plusBankMoney = 860000, plusHallMoney = 51000000, plusHosMoney = 1400000000;
    public string savePlusShop, savePlusStation, savePlusChurch, savePlusBank, savePlusHall, savePlusHospital;

    public int shopPlus25 = 25, stationPlus25 = 25, churchPlus25 = 25, bankPlus25 = 25, hallPlus25 = 25, hosPlus25 = 25;

    private AudioSource audioSource;
    public AudioClip clickSound;

    //Color color;

    void Start()
    {
        facilityRoom.SetActive(false);

        this.audioSource = GameObject.Find("ButtonSound").GetComponent<AudioSource>();
        this.audioSource.clip = this.clickSound;
        this.audioSource.loop = false;  
    }

    void Update()
    {
        shopCount.GetComponent<Text>().text = "상점(" + currentShopCount + ")";
        //shopPrice.GetComponent<Text>().text = "$" + currentShopPrice + " (+$"+plusShopMoney+"/s)";
        changeFacText(currentShopPrice, shopPrice, plusShopMoney);

        stationCount.GetComponent<Text>().text = "주유소(" + currentStationCount + ")";
        //stationPrice.GetComponent<Text>().text = "$" + currentStationPrice + " (+$"+plusStationMoney+"/s)";
        changeFacText(currentStationPrice, stationPrice, plusStationMoney);

        churchCount.GetComponent<Text>().text = "교회(" + currentChurchCount + ")";
        //churchPrice.GetComponent<Text>().text = "$" + currentChurchPrice + " (+$"+plusChurchMoney+"/s)";
        changeFacText(currentChurchPrice, churchPrice, plusChurchMoney);

        bankCount.GetComponent<Text>().text = "은행(" + currentBankCount + ")";
        //bankPrice.GetComponent<Text>().text = "$" + currentBankPrice + " (+$"+plusBankMoney+"/s)";
        changeFacText(currentBankPrice, bankPrice, plusBankMoney);

        hallCount.GetComponent<Text>().text = "시청(" + currentHallCount + ")";
        //hallPrice.GetComponent<Text>().text = "$" + currentHallPrice + " (+$"+plusHallMoney+"/s)";
        changeFacText(currentHallPrice, hallPrice, plusHallMoney);

        hospitalCount.GetComponent<Text>().text = "병원(" + currentHospitalCount + ")";
        //hospitalPrice.GetComponent<Text>().text = "$" + currentHospitalPrice + " (+$"+plusHosMoney+"/s)";
        

        if(currentShopCount>=1) {
            shopImg.SetActive(true);
        } else if(currentShopCount == 0) {
            shopImg.SetActive(false);
        }
        if(currentStationCount>=1) {
            stationImg.SetActive(true);
        } else if(currentStationCount == 0) {
            stationImg.SetActive(false);
        }
        if(currentChurchCount>=1) {
            churchImg.SetActive(true);
        } else if(currentChurchCount == 0) {
            churchImg.SetActive(false);
        }
        if(currentBankCount>=1) {
            bankImg.SetActive(true);
        } else if(currentBankCount == 0) {
            bankImg.SetActive(false);
        }
        if(currentHallCount>=1) {
            hallImg.SetActive(true);
        } else if(currentHallCount == 0) {
            hallImg.SetActive(false);
        }
        if(currentHospitalCount>=1) {
            hospitalImg.SetActive(true);
        } else if(currentHospitalCount == 0) {
            hospitalImg.SetActive(false);
        }
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();
        myLvup Lv_Script = GameObject.Find("AutoMakeCash").GetComponent<myLvup>();
        //ColorUtility.TryParseHtmlString("FF3939", out color);
        Color redColor = new Color(255/255f, 57/255f, 57/255f);
        if(Click_Script.currentMoney >= currentShopPrice) {
            shopBtn.GetComponent<Button>().interactable = true;
            shopPrice.GetComponent<Text>().color = Color.black; 
        } else {
            shopBtn.GetComponent<Button>().interactable = false;
            shopPrice.GetComponent<Text>().color = redColor; 
        }
        if(Click_Script.currentMoney >= currentStationPrice) {
            stationBtn.GetComponent<Button>().interactable = true;
            stationPrice.GetComponent<Text>().color = Color.black; 
        } else {
            stationBtn.GetComponent<Button>().interactable = false;
            stationPrice.GetComponent<Text>().color = redColor; 
        }
        if(Click_Script.currentMoney >= currentChurchPrice) {
            churchBtn.GetComponent<Button>().interactable = true;
            churchPrice.GetComponent<Text>().color = Color.black; 
        }else {
            churchBtn.GetComponent<Button>().interactable = false;
            churchPrice.GetComponent<Text>().color = redColor; 
        }
        if(Click_Script.currentMoney >= currentBankPrice) {
            bankBtn.GetComponent<Button>().interactable = true;
            bankPrice.GetComponent<Text>().color = Color.black; 
        }else {
            bankBtn.GetComponent<Button>().interactable = false;
            bankPrice.GetComponent<Text>().color = redColor; 
        }
        if(Click_Script.currentMoney >= currentHallPrice) {
            hallBtn.GetComponent<Button>().interactable = true;
            hallPrice.GetComponent<Text>().color = Color.black; 
        }else {
            hallBtn.GetComponent<Button>().interactable = false;
            hallPrice.GetComponent<Text>().color = redColor; 
        }

        if(Click_Script.currentMoney >= currentHospitalPrice && Lv_Script.playerLevel>=500) {
            hosBtn.GetComponent<Button>().interactable = true;
            changeFacText(currentHospitalPrice, hospitalPrice, plusHosMoney);
            hospitalPrice.GetComponent<Text>().color = Color.black; 
        }else if(Click_Script.currentMoney >= currentHospitalPrice && Lv_Script.playerLevel<500){
            hosBtn.GetComponent<Button>().interactable = false;
            hospitalPrice.GetComponent<Text>().text = "플레이어 Lv500 이상 잠금해제";
            hospitalPrice.GetComponent<Text>().color = Color.black; 
        } else if(Click_Script.currentMoney < currentHospitalPrice && Lv_Script.playerLevel>=500) {
            hosBtn.GetComponent<Button>().interactable = false;
            changeFacText(currentHospitalPrice, hospitalPrice, plusHosMoney);
            hospitalPrice.GetComponent<Text>().color = redColor; 
        } else if(Click_Script.currentMoney < currentHospitalPrice && Lv_Script.playerLevel < 500) {
            hosBtn.GetComponent<Button>().interactable = false;
            hospitalPrice.GetComponent<Text>().text = "<color=#FF3939>플레이어 Lv500 이상 잠금해제</color>";
        }
        
        UpdateBtn(currentShopCount, shopUpdateBtn, shopUpdateBtnTxt, shopPlus25);
        UpdateBtn(currentStationCount, stationUpdateBtn, stationUpdateBtnTxt, stationPlus25);
        UpdateBtn(currentChurchCount, churchUpdateBtn, churchUpdateBtnTxt, churchPlus25);
        UpdateBtn(currentBankCount, bankUpdateBtn, bankUpdateBtnTxt, bankPlus25);
        UpdateBtn(currentHallCount, hallUpdateBtn, hallUpdateBtnTxt, hallPlus25);
        UpdateBtn(currentHospitalCount, hosUpdateBtn, hosUpdateBtnTxt, hosPlus25);

    }

    public void GotoFacStore() {
        facilityRoom.SetActive(true);
        openCurrentLandmark.SetActive(false);
    }

    public void BuyShopBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();

        if (Click_Script.currentMoney >= currentShopPrice ) {
            
            currentShopCount++;

            Click_Script.currentMoney = Click_Script.currentMoney - currentShopPrice;
            currentShopPrice += currentShopPrice*7/100;

            this.audioSource.Play();
        } else {

        }
    }

    public void shopUpdateFun() {
        plusShopMoney *=2;
        shopPlus25 += 25;
        shopUpdateBtn.SetActive(false);
    }
    public void stationUpdateFun() {
        plusStationMoney *=2;
        stationPlus25 += 25;
        stationUpdateBtn.SetActive(false);
    }
    public void churchUpdateFun() {
        plusChurchMoney *=2;
        churchPlus25 += 25;
        churchUpdateBtn.SetActive(false);
    }
    public void bankUpdateFun() {
        plusBankMoney *=2;
        bankPlus25 += 25;
        bankUpdateBtn.SetActive(false);
    }
    public void hallUpdateFun() {
        plusHallMoney *=2;
        hallPlus25 += 25;
        hallUpdateBtn.SetActive(false);
    }
    public void hosUpdateFun() {
        plusHosMoney *=2;
        hosPlus25 += 25;
        hosUpdateBtn.SetActive(false);
    }


    public void UpdateBtn(int facCount, GameObject Btn, GameObject BtnTxt, int plus25=25) {
        if(facCount == plus25) {
            Btn.SetActive(true);
            BtnTxt.GetComponent<Text>().text = "Lv." + plus25 + "달성! 업그레이드";
        } else {
            
        }
    }

    public void BuyStationBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();

        if (Click_Script.currentMoney >= currentStationPrice ) {
            
            currentStationCount++;
            
            Click_Script.currentMoney = Click_Script.currentMoney - currentStationPrice;
            currentStationPrice += currentStationPrice*7/100;

            this.audioSource.Play();
        } else {

        }
    }

    public void BuyChurchBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();

        if (Click_Script.currentMoney >= currentChurchPrice ) {
            
            currentChurchCount++;

            Click_Script.currentMoney = Click_Script.currentMoney - currentChurchPrice;
            currentChurchPrice += currentChurchPrice*7/100;

            this.audioSource.Play();
        } else {

        }
    }

    public void BuyBankBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();

        if (Click_Script.currentMoney >= currentBankPrice ) {
            
            currentBankCount++;

            Click_Script.currentMoney = Click_Script.currentMoney - currentBankPrice;
            currentBankPrice += currentBankPrice*7/100;

            this.audioSource.Play();
        } else {

        }
    }

        public void BuyHallBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();

        if (Click_Script.currentMoney >= currentHallPrice ) {
            
            currentHallCount++;

            Click_Script.currentMoney = Click_Script.currentMoney - currentHallPrice;
            currentHallPrice += currentHallPrice*7/100;

            this.audioSource.Play();
        } else {

        }
    }

    public void BuyHospitalBtn() {
        Click_ Click_Script = GameObject.Find("TouchHere").GetComponent<Click_>();

        if (Click_Script.currentMoney >= currentHospitalPrice ) {
            
            currentHospitalCount++;

            Click_Script.currentMoney = Click_Script.currentMoney - currentHospitalPrice;
            currentHospitalPrice += currentHospitalPrice*7/100;

            this.audioSource.Play();
        } else {

        }
    }

    public void changeFacText(BigInteger currentFacPrice, GameObject priceFacObject, BigInteger plusSec) {
        //가격 A +
        if(currentFacPrice < 1000000 && currentFacPrice >= 1000 && plusSec < 1000) {
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000) + "A" + " (+$"+ plusSec +"/s)";
        } else if (currentFacPrice < 1000000 && currentFacPrice >= 1000 && plusSec < 1000000 && plusSec >= 1000) {
            //가격A, +A
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000) + "A" + " (+$"+ string.Format("{0:F2}", (double)plusSec/1000) +"A/s)";
        } else if (currentFacPrice < 1000000 && currentFacPrice >= 1000 && plusSec < 1000000000 && plusSec >= 1000000) {
            //가격A +B
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000) + "A" + " (+$"+ string.Format("{0:F2}", (double)plusSec/1000000) +"B/s)";
        } else if(currentFacPrice < 1000000000 && currentFacPrice >= 1000000 && plusSec < 1000) {
            //가격B +
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000) + "B" + " (+$" + plusSec + "/s)";
        } else if(currentFacPrice < 1000000000 && currentFacPrice >= 1000000 && plusSec < 1000000 && plusSec >= 1000) {
            //가격B +A
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000) + "B" + " (+$"+ string.Format("{0:F2}", (double)plusSec/1000) +"A/s)";
        } else if(currentFacPrice < 1000000000 && currentFacPrice >= 1000000 && plusSec < 1000000000 && plusSec >= 1000000) {
            //가격B +B
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000) + "B" + " (+$"+ string.Format("{0:F2}", (double)plusSec/1000000) +"B/s)";
        } else if(currentFacPrice < 1000000000 && currentFacPrice >= 1000000 && plusSec < 1000000000000 && plusSec >= 1000000000) {
            //가격B +C
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000) + "B" + " (+$"+ string.Format("{0:F2}", (double)plusSec/1000000000) +"C/s)";
        } else if(currentFacPrice >= 1000000000 && currentFacPrice<1000000000000 && plusSec>=1000 && plusSec <1000000) {
            //가격C +A
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000000) + "C" + " (+$"+ string.Format("{0:F2}", (double)plusSec/1000) +"A/s)";
        } else if(currentFacPrice >= 1000000000 && currentFacPrice<1000000000000 && plusSec>=1000000 && plusSec <1000000000) {
            //가격C +B
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000000) + "C" + " (+$"+ string.Format("{0:F2}", (double)plusSec/1000000) +"B/s)";
        } else if(currentFacPrice >= 1000000000 && currentFacPrice<1000000000000 && plusSec>=1000000000 && plusSec <1000000000000) {
            //가격C +C
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000000) + "C" + " (+$"+ string.Format("{0:F2}", (double)plusSec/1000000000) +"C/s)";
        } else if(currentFacPrice >= 1000000000000 && currentFacPrice<1000000000000000 && plusSec < 1000000000 && plusSec>=1000000) {
            //가격 D +B
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000000000) + "D"+ " (+$"+ string.Format("{0:F2}", (double)plusSec/1000000) +"B/s)";
        } else if(currentFacPrice >= 1000000000000 && currentFacPrice<1000000000000000 && plusSec < 1000000000000 && plusSec>=1000000000) {
            //가격 D +C
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000000000) + "D"+ " (+$"+ string.Format("{0:F2}", (double)plusSec/1000000000) +"C/s)";
        } else if(currentFacPrice >= 1000000000000 && currentFacPrice<1000000000000000 && plusSec < 1000000000000000 && plusSec>=1000000000000) {
            //가격 D +D
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000000000) + "D"+ " (+$"+ string.Format("{0:F2}", (double)plusSec/1000000000000) +"D/s)";
        } else if(currentFacPrice >= 1000000000000000 && currentFacPrice<1000000000000000000 && plusSec < 1000000000 && plusSec >= 1000000) {
            //가격E +B
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000000000000) + "E"+ " (+$"+ string.Format("{0:F2}", (double)plusSec/1000000) +"B/s)";
        } else if(currentFacPrice >= 1000000000000000 && currentFacPrice<1000000000000000000 && plusSec < 1000000000000 && plusSec >= 1000000000) {
            //가격E +C
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000000000000) + "E"+ " (+$"+ string.Format("{0:F2}", (double)plusSec/1000000000) +"C/s)";
        } else if(currentFacPrice >= 1000000000000000 && currentFacPrice<1000000000000000000 && plusSec < 1000000000000000 && plusSec >= 1000000000000) {
            //가격E +D
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000000000000) + "E"+ " (+$"+ string.Format("{0:F2}", (double)plusSec/1000000000000) +"D/s)";
        } else if(currentFacPrice >= 1000000000000000 && currentFacPrice<1000000000000000000 && plusSec < 1000000000000000000 && plusSec >= 1000000000000000) {
            //가격E +E
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000000000000) + "E"+ " (+$"+ string.Format("{0:F2}", (double)plusSec/1000000000000000) +"E/s)";
        } else if(currentFacPrice >= 1000000000000000000 && currentFacPrice<BigInteger.Parse("1000000000000000000000") && plusSec < 1000000000 && plusSec >= 1000000) {
            //가격F +B
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000000000000000) + "F"+ " (+$"+ string.Format("{0:F2}", (double)plusSec/1000000) +"B/s)";
        } else if(currentFacPrice >= 1000000000000000000 && currentFacPrice<BigInteger.Parse("1000000000000000000000") && plusSec < 1000000000000 && plusSec >= 1000000000) {
            //가격F +C
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000000000000000) + "F"+ " (+$"+ string.Format("{0:F2}", (double)plusSec/1000000000) +"C/s)";
        } else if(currentFacPrice >= 1000000000000000000 && currentFacPrice<BigInteger.Parse("1000000000000000000000") && plusSec < 1000000000000000 && plusSec >= 1000000000000) {
            //가격F +D
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000000000000000) + "F"+ " (+$"+ string.Format("{0:F2}", (double)plusSec/1000000000000) +"D/s)";
        } else if(currentFacPrice >= 1000000000000000000 && currentFacPrice<BigInteger.Parse("1000000000000000000000") && plusSec < 1000000000000000000 && plusSec >= 1000000000000000) {
            //가격F +E
            priceFacObject.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)currentFacPrice/1000000000000000000) + "F"+ " (+$"+ string.Format("{0:F2}", (double)plusSec/1000000000000000) +"E/s)";
        } else if(currentFacPrice < 1000) {
            //1000 이하
            priceFacObject.GetComponent<Text>().text = "$" + currentFacPrice.ToString()+ " (+$" + plusSec + "/s)";
        } else {
            priceFacObject.GetComponent<Text>().text = "$" + "Error";
        }
    }
}
