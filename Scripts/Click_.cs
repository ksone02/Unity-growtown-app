using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Numerics;
using System;

public class Click_ : MonoBehaviour
{
    public BigInteger currentMoney;
    public string saveCurrentMoney;
    public BigInteger clickPerCash, updateMoney, shopUpdateMoney, stationUpdateMoney, churchUpdateMoney, bankUpdateMoney, hallUpdateMoney, hospitalUpdateMoney;
    public string saveclickPerCash, saveupdateMoney, saveshopUpdateMoney, savestationUpdateMoney, savechurchUpdateMoney, savebankUpdateMoney, savehallUpdateMoney, savehospitalUpdateMoney;

    public GameObject currentCash, updateCash, updateClickCash;

    //클릭 애니메이션 처리
    Animator animator;
    public GameObject plusMoneyAni;
    

    private AudioSource audioSource;
    public AudioClip clickSound;

    void Awake() {
        animator = currentCash.GetComponent<Animator>();
        this.audioSource = this.gameObject.GetComponent<AudioSource>();
        this.audioSource.clip = this.clickSound;
        this.audioSource.loop = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Click", false);

        InvokeRepeating("FacAutoCash", 0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        /**if(Application.platform == RuntimePlatform.Android) {
            if(Input.GetTouch(0).phase == TouchPhase.Began) {
                if(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) {
                    makeCash();
                }
            } else {
                animator.SetBool("Click",false);
            }
        } else {
            if(Input.GetMouseButtonDown(0)) {
                if(!EventSystem.current.IsPointerOverGameObject()) {
                    makeCash();
                }
            } else {
                animator.SetBool("Click",false);
            }
        } **/

        //updateCash.GetComponent<Text>().text = "($" + updateMoney + "/s)";
        //updateClickCash.GetComponent<Text>().text = "($" + clickPerCash + "/클릭)";

        updateMoney = shopUpdateMoney + stationUpdateMoney + churchUpdateMoney + bankUpdateMoney + hallUpdateMoney + hospitalUpdateMoney;
        goldText();
        updateMoneyText();
        clickCashText();

    }

    public void makeCash() {

        if(Application.platform == RuntimePlatform.Android) {
            if(Input.touchCount <= 5) {
                //plusMoneyAni.SetActive(true);
                animator.SetBool("Click", true);
                this.audioSource.Play();
                currentMoney = currentMoney + clickPerCash;
                //gameObject.GetComponent<AddMoneyAni>().addMoneyAni();
            }
        } else{
            //plusMoneyAni.SetActive(true);
            animator.SetBool("Click", true);
            this.audioSource.Play();
            currentMoney = currentMoney + clickPerCash;
        }
    }

    public void stopCashAnimation() {
        //plusAnimator.SetBool("isClickOn", false);
        animator.SetBool("Click", true);
    }

    public void FacAutoCash() {
        facilityStore currentFacCountFromFacStore = GameObject.Find("AutoMakeCash").GetComponent<facilityStore>();

        if(currentFacCountFromFacStore.currentShopCount >= 1) {
            shopUpdateMoney = currentFacCountFromFacStore.currentShopCount*currentFacCountFromFacStore.plusShopMoney;
            currentMoney += shopUpdateMoney;
        }

        if(currentFacCountFromFacStore.currentStationCount >= 1) {
            stationUpdateMoney = currentFacCountFromFacStore.currentStationCount*currentFacCountFromFacStore.plusStationMoney;
            currentMoney += stationUpdateMoney;
        }

        if(currentFacCountFromFacStore.currentChurchCount >= 1) {
            churchUpdateMoney = currentFacCountFromFacStore.currentChurchCount*currentFacCountFromFacStore.plusChurchMoney;
            currentMoney += churchUpdateMoney;
        }

        if(currentFacCountFromFacStore.currentBankCount >= 1) {
            bankUpdateMoney = currentFacCountFromFacStore.currentBankCount*currentFacCountFromFacStore.plusBankMoney;
            currentMoney += bankUpdateMoney;
        }

        if(currentFacCountFromFacStore.currentHallCount >= 1) {
            hallUpdateMoney = currentFacCountFromFacStore.currentHallCount*currentFacCountFromFacStore.plusHallMoney;
            currentMoney += hallUpdateMoney;
        }

        if(currentFacCountFromFacStore.currentHospitalCount >= 1) {
            hospitalUpdateMoney = currentFacCountFromFacStore.currentHospitalCount*currentFacCountFromFacStore.plusHosMoney;
            currentMoney += hospitalUpdateMoney;
        }

    }  

    public void goldText() {
        if(currentMoney < 1000000 && currentMoney >= 1000) {
            currentCash.GetComponent<Text>().text = string.Format("{0:F3}", (double)currentMoney/1000) + "A"; // + currentMoney%1000;
        } else if(currentMoney < 1000000000 && currentMoney >= 1000000) {
            currentCash.GetComponent<Text>().text = string.Format("{0:F3}", (double)currentMoney/1000000) + "B"; // + string.Format("{0:n0}", currentMoney%1000000/1000) + "k";
        } else if(currentMoney < 1000) {
            currentCash.GetComponent<Text>().text = currentMoney.ToString();
        } else if(currentMoney >= 1000000000 && currentMoney<1000000000000) {
            currentCash.GetComponent<Text>().text = string.Format("{0:F3}", (double)currentMoney/1000000000) + "C";
        } else if(currentMoney >= 1000000000000 && currentMoney<1000000000000000) {
            currentCash.GetComponent<Text>().text = string.Format("{0:F3}", (double)currentMoney/1000000000000) + "D";
        } else if(currentMoney >= 1000000000000000 && currentMoney<1000000000000000000) {
            currentCash.GetComponent<Text>().text = string.Format("{0:F3}", (double)currentMoney/1000000000000000) + "E";
        } else if(currentMoney >= 1000000000000000000 && currentMoney<BigInteger.Parse("1000000000000000000000")) {
            currentCash.GetComponent<Text>().text = string.Format("{0:F3}", (double)currentMoney/1000000000000000000) + "F";
        } else if(currentMoney >= BigInteger.Parse("1000000000000000000000") && currentMoney < BigInteger.Parse("1000000000000000000000000")) {
            double bigint = ((double)currentMoney/(double)BigInteger.Parse("1000000000000000000000"));
            currentCash.GetComponent<Text>().text = string.Format("{0:F3}", bigint) + "G";
        } else {
            currentCash.GetComponent<Text>().text =  currentMoney.ToString();
        }
    }

    public void updateMoneyText() {
        if(updateMoney < 1000000 && updateMoney >= 1000) {
            updateCash.GetComponent<Text>().text ="($" + string.Format("{0:F2}", (double)updateMoney/1000) + "A" + "/s)"; // + updateMoney%1000;
        } else if(updateMoney < 1000000000 && updateMoney >= 1000000) {
            updateCash.GetComponent<Text>().text ="($" + string.Format("{0:F2}", (double)updateMoney/1000000) + "B" + "/s)"; // + string.Format("{0:n0}", updateMoney%1000000/1000) + "k";
        } else if(updateMoney < 1000) {
            updateCash.GetComponent<Text>().text ="($" + updateMoney.ToString() + "/s)";
        } else if(updateMoney >= 1000000000 && updateMoney<1000000000000) {
            updateCash.GetComponent<Text>().text ="($" + string.Format("{0:F2}", (double)updateMoney/1000000000) + "C" + "/s)";
        } else if(updateMoney >= 1000000000000 && updateMoney<1000000000000000) {
            updateCash.GetComponent<Text>().text ="($" + string.Format("{0:F2}", (double)updateMoney/1000000000000) + "D" + "/s)";
        } else if(updateMoney >= 1000000000000000 && updateMoney<1000000000000000000) {
            updateCash.GetComponent<Text>().text ="($" + string.Format("{0:F2}", (double)updateMoney/1000000000000000) + "E" + "/s)";
        } else if(updateMoney >= 1000000000000000000 && updateMoney<BigInteger.Parse("1000000000000000000000")) {
            updateCash.GetComponent<Text>().text ="($" +  string.Format("{0:F3}", (double)updateMoney/1000000000000000000) + "F" + "/s)";
        } else if(updateMoney >= BigInteger.Parse("1000000000000000000000") && updateMoney < BigInteger.Parse("1000000000000000000000000")) {
            double bigint = ((double)updateMoney/(double)BigInteger.Parse("1000000000000000000000"));
            updateCash.GetComponent<Text>().text ="($" +  string.Format("{0:F3}", bigint) + "G" + "/s)";
        } else {
            updateCash.GetComponent<Text>().text ="($" + updateMoney.ToString() + "/s)";
        }
    }

    public void clickCashText() {
        if(clickPerCash < 1000000 && clickPerCash >= 1000) {
            updateClickCash.GetComponent<Text>().text ="($" + string.Format("{0:F2}", (double)clickPerCash/1000) + "A" + "/탭)"; // + clickPerCash%1000;
        } else if(clickPerCash < 1000000000 && clickPerCash >= 1000000) {
            updateClickCash.GetComponent<Text>().text ="($" + string.Format("{0:F2}", (double)clickPerCash/1000000) + "B" + "/탭)"; // + string.Format("{0:n0}", clickPerCash%1000000/1000) + "k";
        } else if(clickPerCash < 1000) {
            updateClickCash.GetComponent<Text>().text ="($" + clickPerCash.ToString() + "/탭)";
        } else if(clickPerCash >= 1000000000 && clickPerCash<1000000000000) {
            updateClickCash.GetComponent<Text>().text ="($" + string.Format("{0:F2}", (double)clickPerCash/1000000000) + "C" + "/탭)";
        } else if(clickPerCash >= 1000000000000 && clickPerCash<1000000000000000) {
            updateClickCash.GetComponent<Text>().text ="($" + string.Format("{0:F2}", (double)clickPerCash/1000000000000) + "D" + "/탭)";
        } else if(clickPerCash >= 1000000000000000 && clickPerCash<1000000000000000000) {
            updateClickCash.GetComponent<Text>().text ="($" + string.Format("{0:F2}", (double)clickPerCash/1000000000000000) + "E" + "/탭)";
        } else if(clickPerCash >= 1000000000000000000 && clickPerCash<BigInteger.Parse("1000000000000000000000")) {
            updateClickCash.GetComponent<Text>().text ="($" + string.Format("{0:F3}", (double)clickPerCash/1000000000000000000) + "F" + "/탭)";
        } else if(clickPerCash >= BigInteger.Parse("1000000000000000000000") && clickPerCash < BigInteger.Parse("1000000000000000000000000")) {
            double bigint = ((double)clickPerCash/(double)BigInteger.Parse("1000000000000000000000"));
            updateClickCash.GetComponent<Text>().text ="($" + string.Format("{0:F3}", bigint) + "G" + "/탭)";
        } else {
            updateClickCash.GetComponent<Text>().text = "($" + clickPerCash.ToString() + "/탭)";
        }
    }

    public void secretMoney() {
        currentMoney += BigInteger.Parse("100000000000000000000000000");
    }
}