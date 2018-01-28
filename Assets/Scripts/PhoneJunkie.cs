using UnityEngine;
using UnityEngine.UI;

public class PhoneJunkie : MonoBehaviour
{
    private bool isLoaded = false;
    private bool isComplete = false;

    void Start()
    {
        transform.Find("PhoneJunkie").gameObject.SetActive(SpicerGameManager.instance.gameMode == GameMode.Junkie);
    }
    
    static public GameObject getChildGameObject(GameObject fromGameObject, string withName) {
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>();
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }
    
    void Update()
    {
        if (SpicerGameManager.instance.gameMode == GameMode.Junkie)
        {
            if (!isLoaded && SpicerGameManager.instance.treasureData != null)
            {
                isLoaded = true;
                var m = SpicerGameManager.instance.treasureData.Message;
//                var tfObj = gameObject.transform.Find("PhoneMessage");
                var tfObj = getChildGameObject(gameObject, "PhoneMessage");
                if (tfObj == null)
                {
                    print("error");
                    return;
                }
                tfObj.GetComponent<Text>().text = m;
            }

            if (!isComplete && SpicerGameManager.instance.IsLocationFound)
            {
                isComplete = true;
//                var tfObj = gameObject.transform.Find("PhoneMessage");
                var tfObj = getChildGameObject(gameObject, "PhoneMessage");
                if (tfObj == null)
                {
                    print("error");
                    return;
                }
                tfObj.GetComponent<Text>().text = "Location found! Objective complete.";
            }
        }
        
        
//        if (Server.Instance != null && isLoaded == false)
//        {
//            Server.Instance.LoadTreasureData(data =>
//            {
//                isLoaded = true;
//                var tf = gameObject.GetComponent<Text>();
//                tf.text = data.Message;
//            });
//        }
    }
}