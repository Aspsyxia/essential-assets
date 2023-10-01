using Core;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Animator), typeof(AudioSource))]
    public class EquippableItem: InputAction
    {
        [Header("References")] 
        [SerializeField] protected Renderer itemRenderer;
        
        [Header("Sound effects")]
        [SerializeField] protected AudioClip useSound;
        [SerializeField] protected AudioClip equipSound;
        [SerializeField] protected AudioClip unEquipSound;

        protected Animator Animator;
        protected AudioSource AudioSource;
        private bool _isEquipped;
        
        protected virtual void Start()
        {
            Animator = GetComponent<Animator>();
            AudioSource = GetComponent<AudioSource>();
            UnEquip();
        }

        protected virtual void Update()
        {
            if (!IsActive) return;
            if (!_isEquipped) return;
            CheckForInput();
        }

        protected virtual void CheckForInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Use();
            }
        }

        protected virtual void Use()
        {
            Animator.Play("Use");
            print($"Used {name}");
        }
        
        public virtual void Equip()
        {
            itemRenderer.enabled = true;
            AudioSource.PlayOneShot(equipSound);
            _isEquipped = true;
        }

        public virtual void UnEquip()
        {
            itemRenderer.enabled = false;
            AudioSource.PlayOneShot(unEquipSound);
            _isEquipped = false;
        }
    }
}