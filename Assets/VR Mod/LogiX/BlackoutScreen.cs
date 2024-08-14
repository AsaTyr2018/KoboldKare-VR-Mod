using System.Collections;
using UnityEngine;

public class BlackoutScreen : MonoBehaviour
{
    [SerializeField] private GameObject loadingObject;
     

    private void Awake()
    {
        StartCoroutine(LoadingScreen());
    } 

    IEnumerator LoadingScreen()
    { 
        while (true)
        { 
            loadingObject.SetActive(true);
            yield return new WaitUntil(() => !FoxVRLoader.loadingScene);
              
            loadingObject.SetActive(false);
            yield return new WaitUntil(() => FoxVRLoader.loadingScene);
             
        } 
    }
}
