using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Lync.Model.Conversation;
using Microsoft.Lync.Model;

namespace Narayan.Lync
{
    public class ConversationArchiver:IDisposable
    {
        private ConversationManager converMgr;
        private Dictionary<string, ConversationContext> conversationContent;
        private bool _disposed;

        public ConversationArchiver()
        {
            if (!System.IO.Directory.Exists(Configuration.FileArchivePath))
            {
                System.IO.Directory.CreateDirectory(Configuration.FileArchivePath);
            }
            converMgr = LyncClient.GetClient().ConversationManager;
            converMgr.ConversationAdded += conversation_ConversationAdded;
            conversationContent = new Dictionary<string, ConversationContext>();
        }
        
        public void Dispose()
        {
            Dispose(true);

            // Use SupressFinalize in case a subclass 
            // of this type implements a finalizer.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // If you need thread safety, use a lock around these  
            // operations, as well as in your methods that use the resource. 
            if (!_disposed)
            {
                if (disposing)
                {
                    
                }
                // Indicate that the instance has been disposed.
                converMgr.ConversationAdded -= conversation_ConversationAdded;
                converMgr = null;
                conversationContent = null;
                _disposed = true;
            }
        }
        
        private string calculateKey(IList<Participant> participants)
        {
            var convKey = String.Empty;
            for(int index =1;index<participants.Count;index++)
            {
                convKey += (string)(participants[index].Contact.GetContactInformation(ContactInformationType.DisplayName));
            }
            return convKey;
        }

        private void conversation_ConversationAdded(object sender, ConversationManagerEventArgs e)
        {
            Conversation conversation = e.Conversation;

            conversation.ParticipantAdded += new EventHandler<ParticipantCollectionChangedEventArgs>(conversation_ParticipantAdded);
            conversation.ParticipantRemoved += new EventHandler<ParticipantCollectionChangedEventArgs>(conversation_ParticipantRemoved);

            if (e.Conversation.Modalities.ContainsKey(ModalityTypes.InstantMessage) && e.Conversation.Modalities[ModalityTypes.InstantMessage] != null)
            {
                var imModality = (InstantMessageModality)e.Conversation.Modalities[ModalityTypes.InstantMessage];
                imModality.InstantMessageReceived += new EventHandler<MessageSentEventArgs>(conversation_InstantMessageSent);
            }

            conversation.StateChanged += new EventHandler<ConversationStateChangedEventArgs>(conversation_StateChanged);
        }

        private void conversation_InstantMessageSent(object sender, MessageSentEventArgs e)
        {
            var modality = sender as InstantMessageModality;
            var participants = modality.Conversation.Participants;
            //Caclulate Key
            
            string name = (string)modality.Participant.Contact.GetContactInformation(ContactInformationType.DisplayName);
            
            var convKey = calculateKey(participants);
            
            if (conversationContent.ContainsKey(convKey))
            {
                var onGoingConv = conversationContent[convKey];
                onGoingConv.AddVerse(name,e.Text);
            }
            else
            {
                var newConv = new ConversationContext();
                newConv.AddVerse(name,e.Text);
                conversationContent.Add(convKey,newConv);
            }      
        }

        private void conversation_InstantMessageReceived(object sender, MessageSentEventArgs e)
        {
            var modality = sender as InstantMessageModality;
            var participants = modality.Conversation.Participants;
            //Caclulate Key

            string name = (string)modality.Participant.Contact.GetContactInformation(ContactInformationType.DisplayName);

            var convKey = calculateKey(participants);

            if (conversationContent.ContainsKey(convKey))
            {
                var onGoingConv = conversationContent[convKey];
                onGoingConv.AddVerse(name, e.Text);
            }
            else
            {
                var newConv = new ConversationContext();
                newConv.AddVerse(name, e.Text);
                conversationContent.Add(convKey, newConv);
            }
        }

        private void conversation_StateChanged(object sender, ConversationStateChangedEventArgs e)
        {
            if (e.NewState == ConversationState.Terminated)
            {
                var conversation = sender as Conversation;
                var participants = conversation.Participants;
                var convKey = calculateKey(participants);
                
                try
                {
                    var convItem = conversationContent[convKey];

                    var archivers = ArchiveHelper.GetArchivers();
                    foreach (var arcer in archivers)
                    {
                        Parallel.Invoke(() => arcer.Save(convKey, convItem));
                    }
                    
                }
                finally
                {
                    conversationContent.Remove(convKey);
                    conversation.ParticipantAdded += new EventHandler<ParticipantCollectionChangedEventArgs>(conversation_ParticipantAdded);
                    conversation.ParticipantRemoved += new EventHandler<ParticipantCollectionChangedEventArgs>(conversation_ParticipantRemoved);

                    if (conversation.Modalities.ContainsKey(ModalityTypes.InstantMessage) && conversation.Modalities[ModalityTypes.InstantMessage] != null)
                    {
                        var imModality = (InstantMessageModality)conversation.Modalities[ModalityTypes.InstantMessage];
                        imModality.InstantMessageReceived -= new EventHandler<MessageSentEventArgs>(conversation_InstantMessageSent);
                    }

                    conversation.StateChanged -= new EventHandler<ConversationStateChangedEventArgs>(conversation_StateChanged);
                }
            }
        }

        private void conversation_ParticipantAdded(object sender, ParticipantCollectionChangedEventArgs e)
        {
            //Conversation conversation = sender as Conversation;
            Participant otherParty = e.Participant;
            if (!e.Participant.IsSelf)
            {
                if (otherParty.Modalities.ContainsKey(ModalityTypes.InstantMessage) && otherParty.Modalities[ModalityTypes.InstantMessage] != null)
                {
                    var imModality = (InstantMessageModality)otherParty.Modalities[ModalityTypes.InstantMessage];
                    imModality.InstantMessageReceived += new EventHandler<MessageSentEventArgs>(conversation_InstantMessageReceived);
                }
            }
        }

        private void conversation_ParticipantRemoved(object sender, ParticipantCollectionChangedEventArgs e)
        {
            Participant otherParty = e.Participant;
            if (!e.Participant.IsSelf)
            {
                if (otherParty.Modalities.ContainsKey(ModalityTypes.InstantMessage) && otherParty.Modalities[ModalityTypes.InstantMessage] != null)
                {
                    var imModality = (InstantMessageModality)otherParty.Modalities[ModalityTypes.InstantMessage];
                    imModality.InstantMessageReceived -= new EventHandler<MessageSentEventArgs>(conversation_InstantMessageReceived);
                }
            }
        }

    }
}
