using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Game1
{
    public class UploadScoreController : MonoBehaviour
    {
        public void Execute(string username, int score, Action<MessageController> OnCallback)
        {
            StartCoroutine(SendRequest(username, score, OnCallback));
        }
        IEnumerator SendRequest(string username, int score, Action<MessageController> OnCallback)
        {
            WWWForm form = new WWWForm();
            form.AddField("nombre_usuario", username);
            form.AddField("puntaje", score);

            using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/PrograSemana9/EJERCICIO1BASEDATOS/upload_score.php", form))
            {
                yield return www.SendWebRequest();
                if (www.result == UnityWebRequest.Result.ProtocolError || www.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.Log("Error");
                }
                else
                {
                    OnCallback?.Invoke(JsonUtility.FromJson<MessageController>(www.downloadHandler.text));
                }
            }
        }
    }

}
