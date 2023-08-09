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
        public string address;
        public string name;
        public int points;
    }

    [System.Serializable]
    public class ClientData{
        public ClientPublicInfo[] clients;
        public Dictionary<int, ClientPersonalInfo> data = new Dictionary<int, ClientPersonalInfo>();
        public string label;
    }
}