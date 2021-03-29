using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorService.Library
{
    public class Journal
    {
        private readonly List<JournalEntry> _entries;

        public Journal()
        {
            _entries = new();
        }

        public void AddToJournal(JournalEntry entry)
        {
            _entries.Add(entry);
        }

        public List<JournalEntry> RetrieveByUserDefinedId(string UserDefinedId, string RequestorId)
        {
            List<JournalEntry> result = _entries.Where(x => ((x.UserDefinedId == UserDefinedId) && (x.RequestorId == RequestorId))).ToList();
            result.Sort((x, y) => x.Timestamp.CompareTo(y.Timestamp));
            return result;
        }
    }

    public class JournalEntry
    {
        public string UserDefinedId { get; set; }
        public string RequestorId { get; set; }
        public string OperationName { get; set; }
        public string Calculation { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
