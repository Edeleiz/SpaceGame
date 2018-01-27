using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class Server: MonoBehaviour
{
    private void Start()
    {
        TestRequest();
    }

    public void TestRequest()
    {
//        LoadTreasureData(data =>
//        {
//            print("hello");
//        });
//        
        var testData = new TreasureData();
        testData.X = 100;
        testData.Y = 200;
        testData.Message = "Check near the lenin statue at the bushes";
        testData.LocationName = "city";
        SendTreasureData(testData, isSuccess =>
        {
            if (isSuccess)
                print("success!");
        });
    }

    public const string SERVER_URL = "http://46.101.200.56:8080";
//    public const string SERVER_URL = "http://localhost:3000";
    public void SendTreasureData(TreasureData data, System.Action<bool> callback)
    {
        StartCoroutine(PostRequest2(callback, data, SERVER_URL + "/sendPackage"));
//        StartCoroutine(Upload(callback, data, SERVER_URL + "/sendPackage"));
        
        
//        StartCoroutine(PostRequest(callback, data, SERVER_URL + "/sendPackage"));
    }

    public void LoadTreasureData(System.Action<TreasureData> callback)
    {
        StartCoroutine(Load(callback, SERVER_URL + "/getPackage"));
    }
    
    private IEnumerator Load(System.Action<TreasureData> callback, string url)
    {
        ServerTreasureData data;
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.Send();

            if (request.isNetworkError) 
            {
                Debug.Log(request.error);
            }
            else 
            {
                Debug.Log(request.downloadHandler.text);
                data = JsonUtility.FromJson<ServerTreasureData>(request.downloadHandler.text);
                callback(TreasureData.FromServerTreasureData(data));
            }
        }
    }
    
    private IEnumerator Upload(System.Action<bool> callback, TreasureData data, string url)
    {
        var formData = new WWWForm();
        formData.AddField("location", data.LocationName);
        formData.AddField("x", data.X);
        formData.AddField("y", data.Y);
        formData.AddField("message", data.Message);
        
        UnityWebRequest www = UnityWebRequest.Post(url, formData);
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
            callback(false);
        }
        else {
            Debug.Log("Form upload complete!");
            callback(true);
        }
    }
    
    private IEnumerator PostRequest(System.Action<bool> callback, TreasureData data, string url)
    {
        var json = "{\"locationName\":\"Moscow\",\"x\":\"150\",\"y\":\"250\",\"message\":\"hello world\"}";
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(json);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.Send();

        Debug.Log("Response: " + request.downloadHandler.text);
        callback(true);
    }
    
    private IEnumerator PostRequest2(System.Action<bool> callback, TreasureData data, string url)
    {
        var json = "{\"locationName\":\"Moscow\",\"x\":\"150\",\"y\":\"250\",\"message\":\"hello world\"}";
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
 
        yield return request.Send();
 
        Debug.Log("Status Code: " + request.responseCode);
        callback(true);
    }
}