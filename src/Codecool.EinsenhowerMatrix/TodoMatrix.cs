using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Codecool.EinsenhowerMatrix
{
    
    public class TodoMatrix
    {
        
        public Dictionary<string, TodoQuarter> Quarters { get; set; }

        TodoItem ActiveItem = null;
        public string ActiveQuarterKey = "IU";

       
        public TodoMatrix()
        {
           CreateQuarters();
        }

        
        public void AddItem(string title, DateTime date, bool isImportant = false)
        {
            if (!ThereIsDeadlineAlready(date))
            {

                string status;

                double days = (date - DateTime.Now).TotalDays;
                if (!isImportant)
                {
                    status = days > 3 ? "NN" : "NU";
                }
                else
                {
                    status = days > 3 ? "IN" : "IU";
                }
                TodoQuarter quarter = Quarters[status];
                quarter.AddItem(title, date, isImportant);
                ActiveQuarterKey = status; 
                ActiveItem = ActiveItem = quarter.Items.LastOrDefault();
            }
            else
            {
                Console.WriteLine("Ju¿ masz deadline w tym dniu");
            }
        }

        private bool ThereIsDeadlineAlready(DateTime date)
        {
            foreach (var quater in Quarters.Values) {
                if (quater.ThereIsTaskWithThisDeadline(date))
                {
                    return true;
                }
            }
            return false;
        }

        public void ArchiveItems()
        {
            foreach (string key in Quarters.Keys)
            {
                Quarters[key].ArchiveItems();
            }
        }

        
        public void AddItemsFromFile(string filePath)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string title = parts[0].Trim();
                    DateTime deadline = DateTime.Parse(parts[1].Trim());
                    bool isImportant = bool.Parse(parts[2].Trim());
                    AddItem(title, deadline, isImportant);
                }

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Plik nie zosta³ znaleziony. Szczegó³y: {ex.Message}");
            }
        }

       
        public void SaveItemsToFile(string filePath)
        {
            List<string> linesToSave = new List<string>();
            foreach (var quarter in Quarters.Values)
            {
                foreach (var item in quarter.Items)
                {
                    string itemLine = $"{item.Title},{item.Deadline},{item.IsImportant}";
                    linesToSave.Add(itemLine);
                }
            }
            System.IO.File.WriteAllLines(filePath, linesToSave);
        }

      
        public override string ToString()
        {
            

            string iuList = Quarters["IU"].ToString();
            string inList = Quarters["IN"].ToString();
            string nuList = Quarters["NU"].ToString();
            string nnList = Quarters["NN"].ToString();

            string[] iuLines = iuList.Split('\n');
            string[] inLines = inList.Split('\n');
            string[] nuLines = nuList.Split('\n');
            string[] nnLines = nnList.Split('\n');

            int maxLines = Math.Max(
                iuLines.Length, Math.Max(inLines.Length, Math.Max(nuLines.Length, nnLines.Length)));

            StringBuilder matrixBuilder = new StringBuilder();

            matrixBuilder.AppendLine(
                "    |            URGENT              |           NOT URGENT           |  ");
            matrixBuilder.AppendLine(
                "  --|--------------------------------|--------------------------------|--");

            for (int i = 0; i < maxLines; i++)
            {
                matrixBuilder.Append("I   | ");

                if (i < iuLines.Length)
                    matrixBuilder.Append(iuLines[i].PadRight(32));
                else
                    matrixBuilder.Append("                             ");

                matrixBuilder.Append("| ");

                if (i < inLines.Length)
                    matrixBuilder.Append(inLines[i].PadRight(32));
                else
                    matrixBuilder.Append("                            ");

                matrixBuilder.AppendLine("|");


            }

            matrixBuilder.AppendLine(
                "  --|--------------------------------|--------------------------------|--");

            for (int i = 0; i < maxLines; i++)
            {
                matrixBuilder.Append("NI  | ");

                if (i < nuLines.Length)
                    matrixBuilder.Append(nuLines[i].PadRight(32));
                else
                    matrixBuilder.Append("                              ");

                matrixBuilder.Append("| ");

                if (i < nnLines.Length)
                    matrixBuilder.Append(nnLines[i].PadRight(32));
                else
                    matrixBuilder.Append("                             ");

                matrixBuilder.AppendLine("|");
            }

            matrixBuilder.AppendLine(
                "  --|--------------------------------|--------------------------------|--");

            return matrixBuilder.ToString();
        }
       

        private DateTime ConvertToDateFrom(string representation)
        {
            return DateTime.ParseExact(representation, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        private void CreateQuarters()
        {
            Quarters = new Dictionary<string, TodoQuarter>
            {
                { "IU", new TodoQuarter()},
                { "IN", new TodoQuarter()},
                { "NU", new TodoQuarter()},
                { "NN", new TodoQuarter()}
            };

        }
    }
}