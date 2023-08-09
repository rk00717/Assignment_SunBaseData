using UnityEngine;

namespace com.RKode{
    public class UIButtons : MonoBehaviour {
        public void OnClickRestart(){
            LevelManager.Instance.ReloadScene();
        }
    }
}