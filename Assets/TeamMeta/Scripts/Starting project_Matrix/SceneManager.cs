using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Basic_Matrix
{
    public class SceneManager : MonoBehaviour
    {

        public LevelConnects[] all_connects;
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
        private void Start()
        {
            print(all_connects.LongLength);
        }
        public void LoadScene(int num_sce, int num_port)
        {
            switch (num_sce)
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
                        if (num_sce >= 0)
                        {
                            LoadScene("Scene_" + num_sce);
                            LevelHolder.Level.EnterLevel(num_sce, num_port);
                        }
                        break;
                    }
            }

        }
        public void LoadSceneFromExit(int num_sce, int int_exit)
        {
            Connection ent_point = FindConnectTo(num_sce, int_exit);
            LoadScene(ent_point.scene_to, ent_point.portal_to);
        }
        public void LoadScene(string name)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(name);
        }

        public Connection FindConnectTo(int level, int exit)
        {
            return all_connects[level].FindConnect(exit, true);
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


