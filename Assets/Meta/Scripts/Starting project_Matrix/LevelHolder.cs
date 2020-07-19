using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basic_Matrix
{
    public class LevelHolder : MonoBehaviour
    {
        LinkedList<Connection> entries = new LinkedList<Connection>();
        LinkedList<Connection> exits = new LinkedList<Connection>();
        int num_level;
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

        public void AddEnt(Entrance new_en)
        {
            LinkedListNode<Connection> runner;
            RemoveEnt();
            runner = exits.First;
            while (runner != null)
            {
                if (runner.Value.SamePortal(new_en))
                {
                    return;
                }
                runner = runner.Next;
            }
            new_en.num_ent = entries.Count;
            new_en.connect_to = entries.Last.Value;
            entries.AddLast(new Connection(new_en, entries.Count));
        }
        public void AddExit(Exit new_ex)
        {
            LinkedListNode<Connection> runner;
            RemoveExit();
            runner = exits.First;
            while (runner != null)
            {
                if (runner.Value.SamePortal(new_ex))
                {
                    return;
                }
                runner = runner.Next;
            }
            exits.AddLast(new Connection(new_ex, exits.Count));
            new_ex.num_exit = exits.Count;
            new_ex.connect_to = exits.Last.Value;
        }
        public void RemoveEnt()
        {
            LinkedListNode<Connection> runner;
            LinkedListNode<Connection> runner_next;
            int num_fix = 0;
            runner = entries.First;
            while (runner != null)
            {
                runner_next = runner.Next;
                if (runner.Value.isBroke())
                {
                    entries.Remove(runner.Value);
                    num_fix--;
                }
                else
                {
                    runner.Value.NumChange(num_fix);
                }
                runner = runner_next;
            }
        }
        public void RemoveExit()
        {
            LinkedListNode<Connection> runner;
            LinkedListNode<Connection> runner_next;
            int num_fix = 0;
            runner = exits.First;
            while (runner != null)
            {
                runner_next = runner.Next;
                if (runner.Value.isBroke())
                {
                    entries.Remove(runner.Value);
                    num_fix--;
                }
                else
                {
                    runner.Value.NumChange(num_fix);
                }
                runner = runner_next;
            }
        }
        public void ExitLevel(Exit exit_to)
        {
            PlayerData.Data.AddLevel(num_level);
            // TODO: link total number of levels
            GlobalUI.Instance.UpdateGamesDoneFields(PlayerData.Data.NumLevels.ToString(), "7"); 
            SceneManager.SceneMang.LoadScene(exit_to.connect_to.scene_num, exit_to.connect_to.target_portal_num);
        }
        public void EnterLevel(int num_ent)
        {
            PlayerData.Data.current_level = num_level;
            OrganizeEnters();
            OrganizeExits();
            Connection enter = ConnectNum(entries, num_ent);
            if (enter.ScenePortal == null || enter.ScenePortal is Exit)
            {
                return;
            }
            (enter.ScenePortal as Entrance).Enter();
        }
        public Connection ConnectNum(LinkedList<Connection> data, int num)
        {
            LinkedListNode<Connection> runner = data.First;
            for (int i = 0; i < num; i++)
            {
                if (runner == null)
                {
                    return new Connection(null, -100);
                }
                runner = runner.Next;
            }
            if (runner == null)
            {
                return new Connection(null, -100);
            }
            return runner.Value;
        }
        void OrganizeEnters()
        {
            Entrance[] all_enter = GameObject.FindObjectsOfType<Entrance>();
            Entrance[] order_enter = new Entrance[all_enter.Length];
            foreach (Entrance runner in all_enter)
            {
                order_enter[runner.num_ent] = runner;
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
                order_enter[runner.num_exit] = runner;
            }
            entries.Clear();
            foreach (Exit runner in order_enter)
            {
                AddExit(runner);
            }
        }
    }
}
