using TMPro;
using UnityEngine;
using com.RKode.Helper;
using DG.Tweening;

namespace com.RKode{
    public class Popup : Singleton<Popup>{
        [SerializeField] private GameObject popUpWindow;

        [SerializeField] private TextMeshProUGUI _nameLabel;
        [SerializeField] private TextMeshProUGUI _addressLabel;
        [SerializeField] private TextMeshProUGUI _pointsLabel;

        public void SetPopUp(ClientPersonalInfo personInfo){
            SetPopUp(personInfo.name, personInfo.address, personInfo.points);
        }

        public void SetPopUp(string name, string address, int points){
            _nameLabel.text = "Name : " + name;
            _addressLabel.text = "Address : " + address;
            _pointsLabel.text = "Points : " + points;

            popUpWindow.SetActive(true);
        }
    }
}
