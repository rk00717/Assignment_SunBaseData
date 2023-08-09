using UnityEngine;
using DG.Tweening;

namespace com.RKode{
    public class PopUpUIAnimation : MonoBehaviour {
        private void OnEnable() {
            transform.DOShakeScale(.01f);
        }
    }
}