using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basic_Matrix
{
    public class Portal : MonoBehaviour
    {
        readonly public int id = ID;
        public int num_portal;
        static int port_id = 0;
        static int ID
        {
            get
            {
                port_id++;
                return port_id;
            }
        }

        public int Num
        {
            get
            {
                return num_portal;
            }
            set
            {
                if (value >= 0)
                {
                    num_portal = value;
                }
            }
        }
        public override bool Equals(object other)
        {
            if (other is Portal)
            {
                return (other as Portal).id == id;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
