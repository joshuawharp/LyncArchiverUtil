using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lync.Archiver
{
    public class ConversationContext
    {
        public DateTime StartTime { get; private set; }
        private StringBuilder Verses { get; set; }
        public ConversationContext()
        {
            this.StartTime = DateTime.Now;
            Verses = new StringBuilder();
        }
        public void AddVerse(string sayer, string verse)
        {
            Verses.Append(DateTime.Now.ToShortTimeString() + " " + sayer + ":" + verse + Environment.NewLine);
        }

        public String GetConversation()
        {
            return this.Verses.ToString();
        }
    }
}
