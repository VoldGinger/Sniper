using System;
using UnityEngine;
using UnityEngine.UI;
namespace Health
{
    public class PlayerHealthView : MonoBehaviour
    {
         private Slider _slider;
        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }



        public void SetHp(int value)
        {
            _slider.value = value;
        }
        
        



    }
}
