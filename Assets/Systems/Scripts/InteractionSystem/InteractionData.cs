using System;
using UnityEngine;

namespace EssentialAssets.InteractionSystem
{
    [Serializable]
    public struct InteractionData
    {
        public InteractionType Type;
        public string InteractionLabel;

        public InteractionData(InteractionType type, string interactionLabel)
        {
            Type = type;
            InteractionLabel = interactionLabel;
        }
    }
}