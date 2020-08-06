using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basic_Matrix
{
    public class LevelHolder : MonoBehaviour
    {
        LinkedList<Portal> entries = new LinkedList<Portal>();
        LinkedList<Portal> exits = new LinkedList<Portal>();
        int num_lvel;
        int ent_num;
        public int defentr = 0;
        static LevelHolder level;
        public static LevelHolder Level
        {
            get
            {
                if (level == null)
                {
                    level = GameObject.FindObjectOfType<LevelHolder>();
                }
                return level;
            }
        }
        public int Current_Level
        {
            get
            {
                return num_lvel;
            }
        }
        public int Entrnce_Used
        {
            get
            {
                return ent_num;
            }
        }
        public void AddEnt(Entrance new_en)
        {
            if (!(entries.Contains(new_en)))
            {
                entries.AddLast(new_en);
            }
        }
        public void AddExit(Exit new_ex)
        {
            if (!(exits.Contains(new_ex)))
            {
                exits.AddLast(new_ex);
            }
        }
        public void CleanList(LinkedList<Portal> list)
        {
            LinkedListNode<Portal> runner = list.First;
            LinkedListNode<Portal> runner2;
            while (runner != null)
            {
                runner2 = runner.Next;
                if (runner.Value == null)
                {
                    list.Remove(runner);
                }
                runner = runner2;
            }
        }
        public void ExitLevel(Exit exit_to)
        {
            PlayerData.Data.AddLevel(num_lvel, ent_num, exit_to.Num);
            SceneManager.SceneMang.LoadSceneFromExit(num_lvel, exit_to.Num);
        }
        public void EnterLevel(int lvl_num, int num_ent)
        {
            num_lvel = lvl_num;
            PlayerData.Data.current_level = num_lvel;
            ent_num = num_ent;
            OrganizeEnters();
            OrganizeExits();
            (GetPortal(num_ent, entries) as Entrance).Enter();

        }
        public void EnterDefLevel(int lvl)
        {
            EnterLevel(lvl, defentr);
        }
        void OrganizeEnters()
        {
            Entrance[] all_enter = GameObject.FindObjectsOfType<Entrance>();
            Entrance[] order_enter = new Entrance[all_enter.Length];
            foreach (Entrance runner in all_enter)
            {
                order_enter[runner.Num] = runner;
            }
            entries.Clear();
            foreach (Entrance runner in order_enter)
            {
                AddEnt(runner);
            }
        }
        void OrganizeExits()
        {
            Exit[] all_enter = GameObject.FindObjectsOfType<Exit>();
            Exit[] order_enter = new Exit[all_enter.Length];
            foreach (Exit runner in all_enter)
            {
                order_enter[runner.Num] = runner;
            }
            entries.Clear();
            foreach (Exit runner in order_enter)
            {
                AddExit(runner);
            }
        }
        Portal GetPortal(int num, LinkedList<Portal> list)
        {
            foreach (Portal runner in list)
            {
                if (runner.Num == num)
                {
                    return runner;
                }
            }
            return null;
        }

    }
}
