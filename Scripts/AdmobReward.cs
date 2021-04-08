using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using System;
using System.Numerics;

public class AdmobReward : MonoBehaviour
{
    private string rewardID = "ca-app-pub-9614896675925318/6868135455";
    // 실제 광고 ID
    private string rewardTestID = "ca-app-pub-3940256099942544/5224354917";
    // 테스트 광고 ID, 지금은 테스트를 사용

    private RewardedAd rewardedAd;

    private bool rewarded = false;
    public GameObject click;
    public GameObject adAceess;
    public GameObject currentText;

    public GameObject adSuccess;
    public GameObject currentText_2;

    public string AdMoneyToString;

    void Start()
    {
        rewardedAd = new RewardedAd(rewardID);
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request); // 광고 로드

        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // 사용자가 광고를 끝까지 시청했을 때
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        // 사용자가 광고를 중간에 닫았을 때

        adSuccess.SetActive(false);
        adAceess.SetActive(false);
    }

    void Update()
    {
        BigInteger AdMoney = click.GetComponent<Click_>().updateMoney*500;
        updateMoneyText();
        
        if (rewarded)
        {
            closAccessAd();
            currentText_2.GetComponent<Text>().text = "$" + AdMoneyToString + " 획득!";
            adSuccess.SetActive(true);
            click.GetComponent<Click_>().currentMoney += AdMoney;
            rewarded = false;
        }
        currentText.GetComponent<Text>().text = "광고를 시청하고" + "\n" + "$" + AdMoneyToString + " 을 획득하시겠습니까?";
    }

    public void updateMoneyText() {
        BigInteger AdMoney = click.GetComponent<Click_>().updateMoney*300;
        if(AdMoney < 1000000 && AdMoney >= 1000) {
            AdMoneyToString =string.Format("{0:F2}", (double)AdMoney/1000) + "A"; // + AdMoney%1000;
        } else if(AdMoney < 1000000000 && AdMoney >= 1000000) {
            AdMoneyToString =string.Format("{0:F2}", (double)AdMoney/1000000) + "B"; // + string.Format("{0:n0}", AdMoney%1000000/1000) + "k";
        } else if(AdMoney < 1000) {
            AdMoneyToString =AdMoney.ToString();
        } else if(AdMoney >= 1000000000 && AdMoney<1000000000000) {
            AdMoneyToString =string.Format("{0:F2}", (double)AdMoney/1000000000) + "C";
        } else if(AdMoney >= 1000000000000 && AdMoney<1000000000000000) {
            AdMoneyToString =string.Format("{0:F2}", (double)AdMoney/1000000000000) + "D";
        } else if(AdMoney >= 1000000000000000 && AdMoney<1000000000000000000) {
            AdMoneyToString =string.Format("{0:F2}", (double)AdMoney/1000000000000000) + "E";
        } else if(AdMoney >= 1000000000000000000 && AdMoney<BigInteger.Parse("1000000000000000000000")) {
            AdMoneyToString = string.Format("{0:F3}", (double)AdMoney/1000000000000000000) + "F";
        } else if(AdMoney >= BigInteger.Parse("1000000000000000000000") && AdMoney < BigInteger.Parse("1000000000000000000000000")) {
            double bigint = ((double)AdMoney/(double)BigInteger.Parse("1000000000000000000000"));
            AdMoneyToString = string.Format("{0:F3}", bigint) + "G";
        } else {
            AdMoneyToString =AdMoney.ToString();
        }
    }

    public void openAccessAd() {
        adAceess.SetActive(true);
    }
    public void closAccessAd() {
        adAceess.SetActive(false);
    }
    public void closeSuccessAd() {
        adSuccess.SetActive(false);
    }

    public void UserChoseToWatchAd()
    {
        if (rewardedAd.IsLoaded()) // 광고가 로드 되었을 때
        {
            rewardedAd.Show(); // 광고 보여주기
        }
    }

    public void CreateAndLoadRewardedAd() // 광고 다시 로드하는 함수
    {
        rewardedAd = new RewardedAd(rewardID);

        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {  // 사용자가 광고를 닫았을 때
        CreateAndLoadRewardedAd();  // 광고 다시 로드
    }

    private void HandleUserEarnedReward(object sender, Reward e)
    {  // 광고를 다 봤을 때
        rewarded = true; // 변수 true
    }
}
