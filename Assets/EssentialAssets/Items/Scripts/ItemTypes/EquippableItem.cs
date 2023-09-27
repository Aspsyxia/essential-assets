using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Animator), typeof(AudioSource))]
    public class EquippableItem: MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] protected Renderer itemRenderer;
        
        [Header("Animations")] 
        [SerializeField] protected AnimationClip equipAnimation;
        [SerializeField] protected AnimationClip unEquipAnimation;
        
        [Header("Sound effects")]
        [SerializeField] private AudioClip useSound;
        [SerializeField] private AudioClip equipSound;
        [SerializeField] private AudioClip unEquipSound;

        private Animator _animator;
        private AudioSource _audioSource;
        private bool _isEquipped;
        
        protected virtual void Start()
        {
            UnEquip();
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
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

        protected virtual void Use()
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