namespace Lync.Archiver
{
    public interface IArchiver
    {
        void Save(string convKey, ConversationContext convContext);
    }
}