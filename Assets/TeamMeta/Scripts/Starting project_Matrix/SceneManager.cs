using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Basic_Matrix
{
    public class SceneManager : MonoBehaviour
    {

        private static SceneManager scenemg;
        public static SceneManager SceneMang
        {
            get
            {
                if (scenemg == null)
                {
                    scenemg = GameObject.FindObjectOfType<SceneManager>();
                }
                return scenemg;
            }
        }

        public void LoadScene(int num_sce,int num_port)
        {
            switch(num_sce)
            {
                case -1:
                    {
                        LoadScene("Start");
                        break;
                    }
                case -2:
                    {
                        LoadScene("End");
                        break;
                    }
                default:
                    {
                        LoadScene("Scene_" + num_sce);
                        LevelHolder.Level.EnterLevel(num_port);
                        break;
                    }
            }
          
        }

        public void LoadScene(string name)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(name);
        }

        public void ResetLevelScene()
        {
            // check scene is not on start or end and actually a level scene
            var sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            if (sceneName != "StartScene" && sceneName != "EndScene")
            {
                LoadScene(sceneName);
            }
        }

    }
}

