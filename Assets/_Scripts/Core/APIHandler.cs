using System.Collections;
using com.RKode.Helper;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

namespace com.RKode{
    public class APIHandler: Singleton<APIHandler>{
        public delegate void FetchDataCallback(ClientData data);

        public void TryFetchClientData(FetchDataCallback callback){
            StartCoroutine(FetchClientData(callback));
        }

        private IEnumerator FetchClientData(FetchDataCallback callback){
            using UnityWebRequest webRequest = UnityWebRequest.Get(Constant.API_URL);

            yield return webRequest.SendWebRequest();

            if(webRequest.result != UnityWebRequest.Result.Success){
                #if UNITY_EDITOR
                    Debug.Log("Having issues while connecting to servers...");
                #endif
            }

            string response = webRequest.downloadHandler.text;
            ClientData fetchedData = JsonConvert.DeserializeObject<ClientData>(response);

            callback?.Invoke(fetchedData);
        }
    }
}