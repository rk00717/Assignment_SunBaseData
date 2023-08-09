using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.RKode{
    public enum ClientType{ All, ManagerOnly, NonManager }

    public class DataHandler : MonoBehaviour{
        private ClientData data;
        [SerializeField] private Button labelPrefabs;
        [SerializeField] private Transform labelHolder;

        private void Awake() {
            RequestData();
        }

        private void RequestData(){
            APIHandler.Instance.TryFetchClientData(InitData);
        }

        private void InitData(ClientData data) {
            this.data = data;
            UpdateList(0);
        }

        private ClientPersonalInfo RequestClientPersonalInfo(int clientID){
            if(data.data.TryGetValue(clientID, out ClientPersonalInfo value)) return value;

            return new ClientPersonalInfo();
        }

        public void UpdateList(int value){
            Debug.Log(value);
            switch(value){
                case 0:
                    DisplayClient(ClientType.All);
                    break;
                case 1:
                    DisplayClient(ClientType.ManagerOnly);
                    break;
                case 2:
                    DisplayClient(ClientType.NonManager);
                    break;
                default:
                    DisplayClient(ClientType.All);
                    break;
            }
        }

        private void DisplayClient(ClientType type){
            ClearList();

            foreach(ClientPublicInfo info in data.clients){
                if(
                    (type == ClientType.ManagerOnly && !info.isManager) ||
                    (type == ClientType.NonManager && info.isManager)
                ){
                    continue;
                } 

                Button label = Instantiate(labelPrefabs, labelHolder);
                TextMeshProUGUI labelHead = label.GetComponentInChildren<TextMeshProUGUI>();
                labelHead.text = info.label;
                label.onClick.AddListener(()=>{
                    Popup.Instance.SetPopUp(RequestClientPersonalInfo(info.id));
                });
            }
        }

        private void ClearList(){
            foreach(Transform child in labelHolder){
                Destroy(child.gameObject);
            }
        }
    }
}
