using System;
using UnityEngine;

namespace Inventory
{
    public class EquippableItem: MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] protected Renderer itemRenderer;
        [Header("Animations")] 
        [SerializeField] protected AnimationClip equipAnimation;
        [SerializeField] protected AnimationClip unEquipAnimation;
            
        private bool _isEquipped;

        protected virtual void Start()
        {
            UnEquip();
        }

        protected virtual void Update()
        {
            if (!_isEquipped) return;
            CheckForInput();
        }

        protected virtual void CheckForInput()
        {
            if (Input.GetMouseButton(0))
            {
                Use();
            }
        }

        public virtual void Use()
        {
            print($"Used {name}");
        }
        
        public virtual void Equip()
        {
            itemRenderer.enabled = true;
            _isEquipped = true;
        }

        public virtual void UnEquip()
        {
            itemRenderer.enabled = false;
            _isEquipped = false;
        }
    }
}