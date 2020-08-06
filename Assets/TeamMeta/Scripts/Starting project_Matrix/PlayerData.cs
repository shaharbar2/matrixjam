using System.Collections.Generic;
using UnityEngine;

namespace Basic_Matrix
{
    public class PlayerData : MonoBehaviour
    {

        public int current_level;
        int complete_levels = 0;
        LinkedList<Connection> been_connections = new LinkedList<Connection>();
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

        public void AddLevel(int finish_level, int ent, int exit)
        {
            if (!HaveLevel(finish_level))
            {
                complete_levels++;
            }
            been_connections.AddLast(new Connection(finish_level, ent, finish_level, exit));
        }
        public bool HaveLevel(int have_this)
        {
            foreach (Connection con in been_connections)
            {
                if (con.scene_from == have_this)
                {
                    return true;
                }
            }
            return false;
        }
        public int NumLevels
        {
            get
            {
                return complete_levels;
            }
        }
        public Connection LastCon
        {
            //return the last connection (i.e level) the player has finished. 
            //get LastCon.scene_from for last level finished, LastCon.portal_from for entrence used, and Lastcon.portal_to for exit used.
            get
            {
                return been_connections.Last.Value;
            }
        }
    }
}
