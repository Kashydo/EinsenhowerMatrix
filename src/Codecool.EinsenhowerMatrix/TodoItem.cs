using System;

namespace Codecool.EinsenhowerMatrix
{
    
    public class TodoItem
    {
    
        public string Title { get; set; }

       
        public DateTime Deadline { get; set; }

     
        public bool IsDone { get; set; }

       
        public bool IsImportant { get; set; }

        
        public TodoItem(string title, DateTime deadline)
        {
            Title = title;
            Deadline = deadline;
            IsDone = false;
            IsImportant = false;
        }

        
        public TodoItem(string title, DateTime deadline, bool isImportant)
            : this(title, deadline)
        {
            IsImportant=isImportant;
            IsDone = false;
        }
        public TodoItem(string title, DateTime deadline, bool isImportant, bool isDone): this(title, deadline,isImportant) { 

            IsDone=isDone;
        }


        public void Mark()
        {
            IsDone = true;
        }

        public void UnMark()
        {
            IsDone = false;
        }

        public override string ToString()
        {
            string title = Title;
            string deadline = Deadline.ToString("dd-MM");
            string mark = IsDone ? "[X]" : "[ ]";
            return $"{mark} {deadline} {title}";
        }
    }
}