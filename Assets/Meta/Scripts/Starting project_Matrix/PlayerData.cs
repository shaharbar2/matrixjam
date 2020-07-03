using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basic_Matrix
{
    public class PlayerData : MonoBehaviour
    {

        public int current_level;
        int complete_levels = 0;
        LinkedList<int> finish_levels = new LinkedList<int>();
        //more data

        static PlayerData data;
        public static PlayerData Data
        {
            get
            {
                if (data == null)
                {
                    data = GameObject.FindObjectOfType<PlayerData>();
                }
                return data;
            }
        }

        public void AddLevel(int finish_level)
        {
            if (!HaveLevel(finish_level))
            {
                complete_levels++;
                finish_levels.AddLast(finish_level);
            }
        }
        public bool HaveLevel(int have_this)
        {
            return finish_levels.Contains(have_this);
        }
        public int NumLevels
        {
            get
            {
                return complete_levels;
            }
        }
    }
}
