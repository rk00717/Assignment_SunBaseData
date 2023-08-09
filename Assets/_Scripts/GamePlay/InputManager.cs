using UnityEngine;
using com.RKode.Helper;
using DG.Tweening;

namespace com.RKode{
    public class InputManager : MonoBehaviour {
        private Vector2 _startPosition, _endPosition;

        private void Update() {
            HandleInput();
        }

        private void HandleInput() {
            if(Input.GetMouseButtonDown(0)){
                _startPosition = GameEssentials.GetMousePosition;
            }

            if(Input.GetMouseButtonUp(0)){
                _endPosition = GameEssentials.GetMousePosition;

                CastLine();
            }
        }

        private void CastLine(){
            #if UNITY_EDITOR
                Debug.DrawLine(_startPosition, _endPosition, Color.magenta);
            #endif
            RaycastHit2D[] hits2D = Physics2D.LinecastAll(_startPosition, _endPosition);

            foreach(RaycastHit2D hit in hits2D){
                if(hit.collider.tag.Equals("Dot")){
                    #if UNITY_EDITOR
                        Debug.Log(hit.collider.gameObject.name);
                    #endif

                    hit.collider.transform.DOScale(Vector2.one * .2f, .1f)
                        .SetEase(Ease.Flash)
                        .OnComplete(()=>{
                            Destroy(hit.collider.gameObject);
                        });
                }
            }
        }
    }
}