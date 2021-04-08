using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class AddMoneyAni : MonoBehaviour
{
    public GameObject touchAddMoney;

    public GameObject plusAddMoney;
    public GameObject moneyParent;
    public BigInteger addUpdateMoney;
    

    void Awake() {
    }

    void Update() {
        Click_ click_script = gameObject.GetComponent<Click_>();
        addUpdateMoney = click_script.clickPerCash;
    }

    public void plusMoneyAni() {
        UnityEngine.Vector3 MoneyPosition = new UnityEngine.Vector3(5.86f, 25.91f, 0f);
        Click_ clickScript = GameObject.Find("TouchHere").GetComponent<Click_>();
        GameObject MoneyObj = Instantiate(plusAddMoney, MoneyPosition, moneyParent.transform.rotation) as GameObject;
        MoneyObj.transform.SetParent(moneyParent.transform);

        Destroy(MoneyObj, 1f);
    }
    public void addMoneyAni() {
        Click_ click_script = GameObject.Find("TouchHere").GetComponent<Click_>();
        UnityEngine.Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new UnityEngine.Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

        touchAddMoney.transform.position = mousePosition;
        //Debug.Log(mousePosition);
        GameObject instObj = Instantiate(touchAddMoney, mousePosition, transform.rotation) as GameObject;
        instObj.transform.SetParent(click_script.transform);

        if(addUpdateMoney < 1000000 && addUpdateMoney >= 1000) {
            instObj.GetComponent<Text>().text = "+" + string.Format("{0:F2}", (double)addUpdateMoney/1000) + "A"; 
        } else if(addUpdateMoney < 1000000000 && addUpdateMoney >= 1000000) {
            instObj.GetComponent<Text>().text = "+" + string.Format("{0:F2}", (double)addUpdateMoney/1000000) + "B"; 
        } else if(addUpdateMoney < 1000) {
            instObj.GetComponent<Text>().text = "+" + addUpdateMoney.ToString();
        } else if(addUpdateMoney >= 1000000000 && addUpdateMoney<1000000000000) {
            instObj.GetComponent<Text>().text = "+" + string.Format("{0:F2}", (double)addUpdateMoney/1000000000) + "C";
        } else if(addUpdateMoney >= 1000000000000 && addUpdateMoney<1000000000000000) {
            instObj.GetComponent<Text>().text = "+" + string.Format("{0:F2}", (double)addUpdateMoney/1000000000000) + "D";
        } else if(addUpdateMoney >= 1000000000000000 && addUpdateMoney<1000000000000000000) {
            instObj.GetComponent<Text>().text = "+" + string.Format("{0:F2}", (double)addUpdateMoney/1000000000000000) + "E";
        } else if(addUpdateMoney >= 1000000000000000000 && addUpdateMoney<BigInteger.Parse("1000000000000000000000")) {
            instObj.GetComponent<Text>().text ="+" + string.Format("{0:F3}", (double)addUpdateMoney/1000000000000000000) + "F";
        } else if(addUpdateMoney >= BigInteger.Parse("1000000000000000000000") && addUpdateMoney < BigInteger.Parse("1000000000000000000000000")) {
            double bigint = ((double)addUpdateMoney/(double)BigInteger.Parse("1000000000000000000000"));
            instObj.GetComponent<Text>().text ="+" + string.Format("{0:F3}", bigint) + "G";
        } else {
            instObj.GetComponent<Text>().text = "+" + addUpdateMoney.ToString();
        }

        Destroy(instObj, 100f);
    }

}
