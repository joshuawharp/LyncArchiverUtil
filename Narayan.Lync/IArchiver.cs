using System;
using System.Collections.Generic;
using System.Text;

namespace Lync.Archiver
{
    public interface IArchiver
    {
        void Save(string convKey, ConversationContext convContext);
    }
}
