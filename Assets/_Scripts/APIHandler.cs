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
            // string response = "{\"clients\": [{\"isManager\": true,\"id\": 1,\"label\": \"Client1\"},{\"isManager\": false,\"id\": 2,\"label\": \"Client2\"},{\"isManager\": false,\"id\": 3,\"label\": \"Client3\"},{\"isManager\": false,\"id\": 4,\"label\": \"Client3\"},{\"isManager\": false,\"id\": 5,\"label\": \"Client5\"}],\"data\": {\"1\": {\"address\": \"NY\",\"name\": \"Jhon\",\"points\": 123},\"2\": {\"address\": \"NY\",\"name\": \"Dan\",\"points\": 123},\"3\": {\"address\": \"NY\",\"name\": \"Ben\",\"points\": 123}},\"label\": \"All Clients\"}";
            // ClientData fetchedData = JsonUtility.FromJson<ClientData>(response);
            ClientData fetchedData = JsonConvert.DeserializeObject<ClientData>(response);
            // #if UNITY_EDITOR
            //     Debug.Log($"Response: {response}");

            //     Debug.Log($"Label: {fetchedData.label}");

            //     Debug.Log("<color=orange>Client Public Data -> </color>");
            //     foreach (ClientPublicInfo client in fetchedData.clients){
            //         Debug.Log($"Client ID: {client.id}, \nClient Label: {client.label}, \nIs Manager: {client.isManager}");
            //     }

            //     Debug.Log($"<color=orange>Client Personal Data -> </color> {fetchedData.data.Count}");
            //     foreach (KeyValuePair<int, ClientPersonalInfo> kvp in fetchedData.data){
            //         Debug.Log($"Data Key: {kvp.Key}, \nName: {kvp.Value.name}, \nAddress: {kvp.Value.address}, \nPoints: {kvp.Value.points}");
            //     }
            // #endif

            callback?.Invoke(fetchedData);
        }
    }
}