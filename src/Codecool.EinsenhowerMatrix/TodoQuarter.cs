using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codecool.EinsenhowerMatrix
{
   
    public class TodoQuarter
    {
        
        public List<TodoItem> Items;
        public int ActiveTaskIndex = 0;

       
        public TodoQuarter()
        {
            Items = new List<TodoItem>();
        }

      
        public void AddItem(string title, DateTime deadline)
        {
            if (deadline >= DateTime.Now )
            {
                if (title != null && title !="")
                {
                    Items.Add(new TodoItem(title, deadline));
                }
                else Console.WriteLine("Niemo¿na dodataæ taska bez tytu³u");
            }
            else
            {
                Console.WriteLine("Niemo¿na dodataæ taska z przesz³¹ dat¹");
            }
        }

        public bool ThereIsTaskWithThisDeadline(DateTime date)
        {
            foreach (TodoItem item in Items)
            {
                if (item.Deadline == date)
                    return true;
            }
            return false;
        }

           
        public void AddItem(string title, DateTime deadline, bool isImportant)
        {
            Items.Add(new TodoItem(title, deadline,isImportant));
        }

       
        public void RemoveItem(int index)
        {
            try
            {
                Items.RemoveAt(index);
            }catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Index poza zakresem. {ex.Message}");
            }catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"argument poza zakresem. {ex.Message}");
            }
        }

       
        public void ArchiveItems()
        {
            for (int i = 0; i< Items.Count - 1;  i++)
            {
                if (Items[i].IsDone)
                {
                    RemoveItem(i);
                }
            }
        }
        public void GoUpTaskList()
        {
            if (ActiveTaskIndex > 0)
            {
                ActiveTaskIndex--;
            }
            else
            {
                ActiveTaskIndex = Items.Count() - 1;
            }
        
        }

        public void GoDownTaskList()
        {
            if (ActiveTaskIndex < Items.Count() - 1)
            {
                ActiveTaskIndex++;
            }
            else ActiveTaskIndex = 0;
        }

       
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
           
            foreach (TodoItem item in Items)
            {
                stringBuilder.Append(item.ToString() + "\n");
            }
            return stringBuilder.ToString();
        }

        private void SortToDoItems()
        {
        }
    }
}