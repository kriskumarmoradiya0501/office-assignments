using System;

namespace IncomeExpenseTracker.Models
{
    // One row of data = one income or expense entry.
    // Kept as a plain class with simple public fields so it is easy to read.
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }       // "Income" or "Expense"
        public string Category { get; set; }   // Salary, Food, Travel, etc.
        public decimal Amount { get; set; }

        // Used when writing / reading the CSV file for Import & Export.
        public string ToCsvLine()
        {
            // Wrap description in quotes in case it contains a comma.
            return $"{Id},{Date:yyyy-MM-dd},\"{Description}\",{Type},{Category},{Amount}";
        }

        public static Transaction FromCsvLine(string line)
        {
            // Very simple CSV parser that understands one quoted field (Description).
            // Format: Id,Date,"Description",Type,Category,Amount
            var firstQuote = line.IndexOf('"');
            var lastQuote = line.LastIndexOf('"');

            string idPart = line.Substring(0, line.IndexOf(',')).Trim();
            string description = line.Substring(firstQuote + 1, lastQuote - firstQuote - 1);
            string rest = line.Substring(lastQuote + 1).TrimStart(',');
            string[] restParts = rest.Split(',');

            var t = new Transaction
            {
                Id = int.Parse(idPart),
                Date = DateTime.Parse(line.Substring(line.IndexOf(',') + 1, firstQuote - line.IndexOf(',') - 2)),
                Description = description,
                Type = restParts[0],
                Category = restParts[1],
                Amount = decimal.Parse(restParts[2])
            };
            return t;
        }
    }
}
