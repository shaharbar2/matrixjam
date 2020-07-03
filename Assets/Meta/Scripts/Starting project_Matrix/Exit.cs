using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basic_Matrix
{
    public class Exit : Portal
    {
        public int num_exit;
        public void EndLevel()
        {
            LevelHolder.Level.ExitLevel(this);
        }
    }
}
