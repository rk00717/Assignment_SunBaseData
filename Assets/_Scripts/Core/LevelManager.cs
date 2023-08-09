using com.RKode.Helper;
using UnityEngine.SceneManagement;

namespace com.RKode{
    public class LevelManager : Singleton<LevelManager> {
        public void ReloadScene(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}