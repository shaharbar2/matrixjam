using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Basic_Matrix
{
    [Serializable]
    public struct Connection
    {
         public int scene_num; //number of scene this connect to.
         public int target_portal_num; //number of entrence/exit in the target scene this connect to
         int current_portal; //number of entrence/exit in the current scene this connect to
         Portal scene_portal;

        public Portal ScenePortal
        {
            get
            {
                return scene_portal;
            }
        }
        
        public Connection(Portal here_portal, int num_port)
        {
            scene_portal = here_portal;
            scene_num = -2;
            current_portal = num_port;
            target_portal_num = -2;
        }

        public bool SamePortal(Portal given)
        {
            return (given.Equals(scene_portal));
        }
        public bool isBroke()
        {
            if(scene_portal == null)
            {
                return true;
            }
            return false;
        }
        public void NumChange(int change)
        {
            current_portal += change;
            scene_portal.Num += change;
        }
    }
}
