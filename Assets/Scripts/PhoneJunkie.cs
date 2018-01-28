using UnityEngine;
using UnityEngine.UI;

public class PhoneJunkie : MonoBehaviour
{
    private bool isLoaded = false;
    void Update()
    {
        gameObject.SetActive(SpicerGameManager.instance.gameMode == GameMode.Junkie);
        
        if (SpicerGameManager.instance.gameMode == GameMode.Junkie && !isLoaded && SpicerGameManager.instance.treasureData != null)
        {
            isLoaded = true;
            var m = SpicerGameManager.instance.treasureData.Message;
            var tfObj = gameObject.transform.Find("ChildName");
            tfObj.GetComponent<Text>().text = m;
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