using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Basic_Matrix
{


    //this script is used it two ways:
    //A: to connect an exit (scene_from,portal_from) to the entrence (scene_to,portal_to) it need to load, if this exit is used.
    //B: to save the trip a player has made in a level. from entrenece (scene from[level num],portal_from) to exit(scene_to[level], portal_to).

    [Serializable]
    public struct Connection
    {
        public int scene_from;
        public int portal_from;
        public int scene_to; //number of scene this connect to.
        public int portal_to; //number of entrence/exit in the target scene this connect to
        public Connection(int ent_sce, int ent_por, int exit_sce, int exit_por)
        {
            scene_from = ent_sce;
            portal_from = ent_por;
            scene_to = exit_sce;
            portal_to = exit_por;
        }
    }
}
