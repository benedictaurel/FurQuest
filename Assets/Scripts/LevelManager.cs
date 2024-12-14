using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    IEnumerator LoadSceneAsync(string sceneName) {
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneName);

        Player.Instance.transform.position = new(-2.96f, -3.81f);

        yield return new WaitForSeconds(1);
    }

    public void LoadScene(string sceneName) {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
}
