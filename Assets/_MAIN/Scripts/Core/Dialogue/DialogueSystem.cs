using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE
{
    public class DialogueSystem : MonoBehaviour
    {
        public DialogueContainer dialogueContainer; // Assign this in the Unity Inspector
        public ConversationManager conversationManager;
        private TextArchitect architect;

        public static DialogueSystem instance;

        public delegate void DialogueSystemEvent();
        public event DialogueSystemEvent onUserPrompt_Next;

        public bool isRunningConversation => conversationManager.isRunning;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                Initialize();
            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }

        private void Initialize()
        {
            architect = new TextArchitect(dialogueContainer.dialogueText);
            conversationManager = new ConversationManager(architect);
        }

        public void OnUserPrompt_Next()
        {
            onUserPrompt_Next?.Invoke();
        }
        public void ShowSpeakerName(string speakerName = "")
        {
            // Ensure that dialogueContainer and nameContainer are not null before using them
            if (dialogueContainer != null && dialogueContainer.nameContainer != null)
            {
                if (speakerName.ToLower() != "narrator")
                    dialogueContainer.nameContainer.Show(speakerName);
                else
                    HideSpeakerName();
            }
        }

        public void HideSpeakerName()
        {
            // Ensure that dialogueContainer and nameContainer are not null before using them
            if (dialogueContainer != null && dialogueContainer.nameContainer != null)
            {
                dialogueContainer.nameContainer.Hide();
            }
        }

        public void Say(string speaker, string dialogue)
        {
            List<string> conversation = new List<string>() { $"{speaker} \"{dialogue}\"" };
            Say(conversation);
        }

        public void Say(List<string> conversation)
        {
            conversationManager.StartConversation(conversation);
        }
    }
}
