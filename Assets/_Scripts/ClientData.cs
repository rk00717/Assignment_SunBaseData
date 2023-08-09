using System.Collections.Generic;

namespace com.RKode{
    [System.Serializable]
    public class ClientPublicInfo{
        public bool isManager;
        public int id;
        public string label;
    }

    [System.Serializable]
    public class ClientPersonalInfo{
        public string address = "N/A";
        public string name = "N/A";
        public int points = 0;
    }

    [System.Serializable]
    public class ClientData{
        public ClientPublicInfo[] clients;
        public Dictionary<int, ClientPersonalInfo> data = new Dictionary<int, ClientPersonalInfo>();
        public string label;
    }
}