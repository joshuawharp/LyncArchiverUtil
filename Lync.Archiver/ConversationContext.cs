using System;
using System.Text;

namespace Lync.Archiver
{
    public class ConversationContext
    {
        public ConversationContext()
        {
            StartTime = DateTime.Now;
            Verses = new StringBuilder();
        }

        public DateTime StartTime { get; private set; }
        private StringBuilder Verses { get; set; }

        public void AddVerse(string sayer, string verse)
        {
            Verses.Append(Environment.NewLine+ DateTime.Now.ToShortTimeString() + " " + sayer + ":" + verse);
        }

        public String GetConversation()
        {
            return Verses.ToString();
        }
    }
}