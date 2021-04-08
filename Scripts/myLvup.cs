using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class myLvup : MonoBehaviour
{
    public GameObject LvLv, click, LvPrice, LvRoom, openCurrentLandmark, updateBtn, updateBtnTxt, LvBtn;
    public int playerLevel = 1;
    public string saveCurrentLvPrice, saveCurrentTabperCash, saveCurrentUpdateTabperCash;
    public BigInteger currentLvPrice = 100, currnetTabperCash=20, currnetUpdateTabperCash = 2;

    public int LvPlus25 = 25;

    private AudioSource audioSource;
    public AudioClip clickSound;

    void Start() {
        this.audioSource = GameObject.Find("ButtonSound").GetComponent<AudioSource>();
        this.audioSource.clip = this.clickSound;
        this.audioSource.loop = false; 

        LvRoom.SetActive(false);
    }

    void Update() {
        LvLv.GetComponent<Text>().text = "레벨(" + playerLevel + ")";
        //LvPrice.GetComponent<Text>().text = currentLvPrice + "원 (+$" + currnetUpdateTabperCash +"/탭)";
        if(playerLevel == LvPlus25) {
            updateBtn.SetActive(true);
            updateBtnTxt.GetComponent<Text>().text = "Lv." + LvPlus25 + "달성! 업그레이드";
        } else {
            
        }
        click.GetComponent<Click_>().clickPerCash = currnetTabperCash;
        changeLvText(currentLvPrice, currnetUpdateTabperCash, LvPrice);

        Color redColor = new Color(255/255f, 57/255f, 57/255f);
        if(click.GetComponent<Click_>().currentMoney >= currentLvPrice) {
            LvBtn.GetComponent<Button>().interactable = true;
            LvPrice.GetComponent<Text>().color = Color.black; 
        }else if(click.GetComponent<Click_>().currentMoney < currentLvPrice) {
            LvBtn.GetComponent<Button>().interactable = false;
            LvPrice.GetComponent<Text>().color = redColor; 
        }
    }

    public void UpdateLvFun() {
        currnetUpdateTabperCash *=2;
        currnetTabperCash *=2;
        LvPlus25 += 25;
        updateBtn.SetActive(false);
    }

    public void GotoLvRoom() {
        LvRoom.SetActive(true);
        openCurrentLandmark.SetActive(false);
    }

    public void LvUpFuc() {
        BigInteger currnetmoneywithLv = click.GetComponent<Click_>().currentMoney;
        if(currnetmoneywithLv >= currentLvPrice) {
            playerLevel++;
            click.GetComponent<Click_>().currentMoney = click.GetComponent<Click_>().currentMoney -currentLvPrice;
            currentLvPrice += currentLvPrice*7/100;
            currnetTabperCash += currnetUpdateTabperCash;
        }
    }

    public void changeLvText(BigInteger Price, BigInteger updateTab, GameObject chageText) {
        if(Price < 1000000 && Price >= 1000 && updateTab < 1000)
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000) + "A"+ " (+$"+ updateTab +"/탭)";
        } 
        else if(Price < 1000000000 && Price >= 1000000 && updateTab < 1000)
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000) + "B"+ " (+$" + updateTab + "/탭)"; 
        }
        else if(Price < 1000000000 && Price >= 1000000 && updateTab >=1000 && updateTab < 1000000)
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000) + "B"+ " (+$"+ string.Format("{0:F2}", (double)updateTab/1000) +"A/탭)";
        }
        else if(Price >= 1000000000 && Price<1000000000000 && updateTab >=1000 && updateTab < 1000000)
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000000) + "C"+ " (+$"+ string.Format("{0:F2}", (double)updateTab/1000) +"A/탭)";
        } 
        else if(Price >= 1000000000000 && Price<1000000000000000 && updateTab < 1000)
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000000000) + "D"+ " (+$" + updateTab + "/탭)";
        } 
        else if(Price >= 1000000000000 && Price<1000000000000000 && updateTab >=1000 && updateTab < 1000000)
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000000000) + "D"+ " (+$"+ string.Format("{0:F2}", (double)updateTab/1000) +"A/탭)";
        } 
        else if(Price >= 1000000000000 && Price<1000000000000000 && updateTab >=1000000 && updateTab < 1000000000)
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000000000) + "D"+ " (+$"+ string.Format("{0:F2}", (double)updateTab/1000000) +"B/탭)";
        } 
        else if(Price >= 1000000000000 && Price<1000000000000000 && updateTab >=1000000000 && updateTab < 1000000000000)
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000000000) + "D"+ " (+$"+ string.Format("{0:F2}", (double)updateTab/1000000000) +"C/탭)";
        } 
        else if(Price >= 1000000000000000 && Price<1000000000000000000 && updateTab < 1000) 
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000000000000) + "E"+ " (+$" + updateTab + "/탭)";
        } 
        else if(Price >= 1000000000000000 && Price<1000000000000000000 && updateTab >=1000 && updateTab < 1000000) 
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000000000000) + "E"+ " (+$"+ string.Format("{0:F2}", (double)updateTab/1000) +"A/탭)";
        } 
        else if(Price >= 1000000000000000 && Price<1000000000000000000 && updateTab >=1000000 && updateTab < 1000000000) 
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000000000000) + "E"+ " (+$"+ string.Format("{0:F2}", (double)updateTab/1000000) +"B/탭)";
        } 
        else if(Price >= 1000000000000000 && Price<1000000000000000000 && updateTab >=1000000000 && updateTab < 1000000000000) 
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000000000000) + "E"+ " (+$"+ string.Format("{0:F2}", (double)updateTab/1000000000) +"C/탭)";
        } 
        else if(Price >= 1000000000000000 && Price<1000000000000000000 && updateTab >=1000000000000 && updateTab < 1000000000000000) 
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000000000000) + "E"+ " (+$"+ string.Format("{0:F2}", (double)updateTab/1000000000000) +"D/탭)";
        } 
        else if(Price >= 1000000000000000000 && Price<BigInteger.Parse("1000000000000000000000") && updateTab >=1000 && updateTab < 1000000) 
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000000000000000) + "F"+ " (+$"+ string.Format("{0:F2}", (double)updateTab/1000) +"A/탭)";
        }
        else if(Price >= 1000000000000000000 && Price<BigInteger.Parse("1000000000000000000000") && updateTab >=1000000 && updateTab < 1000000000) 
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000000000000000) + "F"+ " (+$"+ string.Format("{0:F2}", (double)updateTab/1000000) +"B/탭)";
        }
        else if(Price >= 1000000000000000000 && Price<BigInteger.Parse("1000000000000000000000") && updateTab >=1000000000 && updateTab < 1000000000000) 
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000000000000000) + "F"+ " (+$"+ string.Format("{0:F2}", (double)updateTab/1000000000) +"C/탭)";
        }
        else if(Price >= 1000000000000000000 && Price<BigInteger.Parse("1000000000000000000000") && updateTab >=1000000000000 && updateTab < 1000000000000000) 
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000000000000000) + "F"+ " (+$"+ string.Format("{0:F2}", (double)updateTab/1000000000000) +"D/탭)";
        }
        else if(Price >= 1000000000000000000 && Price<BigInteger.Parse("1000000000000000000000") && updateTab >=1000000000000000 && updateTab < 1000000000000000000) 
        {
            chageText.GetComponent<Text>().text = "$" + string.Format("{0:F2}", (double)Price/1000000000000000000) + "F"+ " (+$"+ string.Format("{0:F2}", (double)updateTab/1000000000000000) +"E/탭)";
        }
        else if(Price < 1000 && updateTab < 1000)
        {
            chageText.GetComponent<Text>().text = "$" + Price.ToString()+ " (+$" + updateTab + "/탭)";
        } 
        else 
        {
            chageText.GetComponent<Text>().text = "$" + "Error빠진부분 살피자..";
        }
        
    }
}
