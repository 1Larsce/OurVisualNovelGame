using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DIALOGUE
{
    [System.Serializable]
    public class DialogueContainer
    {
        public GameObject root;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI dialogueText;
        internal NameContainer nameContainer; // Corrected type to NameContainer
    }
}
