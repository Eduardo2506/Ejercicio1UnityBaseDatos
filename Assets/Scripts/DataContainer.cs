using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game1
{
    public class DataContainer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI dataText;

        public void SetData(string data)
        {
            dataText.text = data;
        }
    }
}

