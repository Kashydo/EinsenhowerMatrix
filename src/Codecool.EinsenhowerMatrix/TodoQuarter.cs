using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codecool.EinsenhowerMatrix
{
    /// <summary>
    /// Class that represents quarter for items from different categories
    /// </summary>
    public class TodoQuarter
    {
        /// <summary>
        /// Gets or sets list of items
        /// </summary>
        public List<TodoItem> Items;
        public int ActiveTaskIndex = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoQuarter"/> class.
        /// </summary>
        public TodoQuarter()
        {
            Items = new List<TodoItem>();
        }

        /// <summary>
        /// Add item to list
        /// </summary>
        /// <param name="title">title of item</param>
        /// <param name="deadline">deadline of item</param>
        public void AddItem(string title, DateTime deadline)
        {
            if (deadline >= DateTime.Now )
            {
                if (title != null)
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

            /// <summary>
            /// Add item to list
            /// </summary>
            /// <param name="title">title of item</param>
            /// <param name="deadline">deadline of item</param>
            /// <param name="isImportant">boolean that indicates whenever item is important or not</param>
            public void AddItem(string title, DateTime deadline, bool isImportant)
        {
            Items.Add(new TodoItem(title, deadline,isImportant));
        }

        /// <summary>
        /// Removes item instance under given index
        /// </summary>
        /// <param name="index">index of </param>
        public void RemoveItem(int index)
        {
            try
            {
                Items.RemoveAt(index);
            }catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Nie ma takiego indeksu. {ex}");
            }
        }

        /// <summary>
        /// Destroys all done item
        /// </summary>
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
            //   ActiveTaskIndex = ActiveTaskIndex > 0 ? ActiveTaskIndex-1 : TodoItems.Count() - 1;
        }

        public void GoDownTaskList()
        {
            if (ActiveTaskIndex < Items.Count() - 1)
            {
                ActiveTaskIndex++;
            }
            else ActiveTaskIndex = 0;
        }

        /// <summary>
        /// Returns human readable representation of quarter
        /// </summary>
        /// <returns>string with all nested items</returns>
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