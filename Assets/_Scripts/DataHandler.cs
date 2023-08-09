using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.RKode{
    public class DataHandler : MonoBehaviour{
        private ClientData data;
        [SerializeField] private Button labelPrefabs;
        [SerializeField] private Transform labelHolder;

        private void Start() {
            RequestData();
        }

        private void RequestData(){
            APIHandler.Instance.TryFetchClientData(InitData);
        }

        private void InitData(ClientData data) {
            this.data = data;
            DisplayAllClient();
        }

        private void DisplayAllClient(){
            foreach(ClientPublicInfo info in data.clients){
                Button label = Instantiate(labelPrefabs, labelHolder);
                TextMeshProUGUI labelHead = label.GetComponentInChildren<TextMeshProUGUI>();
                labelHead.text = info.label;
            }
        }
    }
}
