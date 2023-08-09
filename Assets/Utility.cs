namespace com.RKode.Helper {
    public class Singleton<T> : MonoBehaviour where T : Component  {
        public static T Instance{ get; protected set; }

        protected virtual void Awake() {
            if (Instance == null) {
                Instance = this as T;
            }else{
                Debug.Log("Destroyed Singleton " + gameObject.name);
                Destroy(gameObject);
            }
        }
    }

    public class PersistentSingleton<T> : Singleton<T> where T : Component  {
        protected override void Awake() {
            if (Instance == null) {
                Instance = this as T;
                DontDestroyOnLoad(this);
            }else{
                Debug.Log("Destroyed Singleton " + gameObject.name);
                Destroy(gameObject);
            }
        }
    }
}