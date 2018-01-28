using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCladmen : MonoBehaviour
{
    private bool isShown = false;

    void Update()
    {
        if (SpicerGameManager.instance.gameMode == GameMode.Stasher)
        {
            if (isShown == false && SpicerGameManager.instance.IsStasherUIShow)
            {
                isShown = true;
                var phone = transform.Find("PhoneCladmen");
                phone.gameObject.SetActive(true);
            }
        }
    }
    
    static public GameObject getChildGameObject(GameObject fromGameObject, string withName) {
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>();
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }
    
    public void StartGame()
    {
        var btn = getChildGameObject(gameObject, "SendButton");
//        var btn = transform.Find("SendButton");
        btn.gameObject.SetActive(false);
        
        var tfObj = getChildGameObject(gameObject, "TitleMessage");
//        var tfObj = gameObject.transform.Find("TitleMessage");
        tfObj.GetComponent<Text>().text = "Transmission complete";
        
        var input = getChildGameObject(gameObject, "InputField");
        var text = input.GetComponent<InputField>().text;
        if (text.Length < 10)
        {
            tfObj.GetComponent<Text>().text = "Error: too small";
        }
        SpicerGameManager.instance.SendLocation(text);
    }
}