using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game1
{
    public class GetRankingView : MonoBehaviour
    {
        [SerializeField] private GameObject container;
        [SerializeField] private GameObject dataContainerPrefab;
        [SerializeField] private GetRankingController getRankingController;

        public void Execute()
        {
            getRankingController.Execute(OnCallback);
        }
        private void OnCallback(UserDataController userDataController)
        {
            foreach (Transform t in container.GetComponentInChildren<Transform>())
            {
                if (t != container.transform)
                {
                    Destroy(t.gameObject);
                }
            }

            foreach (UserController user in userDataController.data)
            {
                GameObject dataContainer = Instantiate(dataContainerPrefab, container.transform);
                dataContainer.GetComponent<DataContainer>().SetData($"{user.nombre_usuario} - {user.puntaje}");
            }
        }
    }
}

