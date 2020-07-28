using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basic_Matrix
{
    public class Entrance : Portal
    {
         public int num_ent;
         public void Enter()
         {
            GetComponent<StartHelper>().StartHelp(num_ent);
         }
    }
}
