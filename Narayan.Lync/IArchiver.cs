using System;
using System.Collections.Generic;
using System.Text;

namespace Narayan.Lync
{
    public interface IArchiver
    {
        void Save(string convKey, ConversationContext convContext);
    }
}
