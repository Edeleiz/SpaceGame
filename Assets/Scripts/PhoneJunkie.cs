using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    private bool isLoaded = false;
    void Update()
    {
        if (Server.Instance != null && isLoaded == false)
        {
            Server.Instance.LoadTreasureData(data =>
            {
                isLoaded = true;
                var tf = gameObject.GetComponent<Text>();
                tf.text = data.Message;
            });
        }
    }
}