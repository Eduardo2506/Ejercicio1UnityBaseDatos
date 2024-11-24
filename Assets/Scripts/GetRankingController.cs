using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Game1
{
    public class GetRankingController : MonoBehaviour
    {
        public void Execute(Action<UserDataController> OnCallback)
        {
            StartCoroutine(SendRequest(OnCallback));
        }
        IEnumerator SendRequest(Action<UserDataController> OnCallback)
        {
            using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/PrograSemana9/EJERCICIO1BASEDATOS/get_ranking.php"))
            {
                yield return www.SendWebRequest();
                if (www.result == UnityWebRequest.Result.ProtocolError || www.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.Log("Error");
                }
                else
                {
                    OnCallback?.Invoke(JsonUtility.FromJson<UserDataController>(www.downloadHandler.text));
                }
            }
        }
    }

}

