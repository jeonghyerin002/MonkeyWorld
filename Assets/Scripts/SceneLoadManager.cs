using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public string nextSceneName;  // 이동할

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;

            if(nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.Log("다음 씬이 없습니다.");
            }
            GameManager.Instance.GoToNextround(nextSceneName);
        }
        else
        {
            Debug.Log("아이템을 모두 모아야 이동할 수 있어!");
        }
    }

    }
