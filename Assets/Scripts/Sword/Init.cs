using UnityEngine;

namespace Sword
{
    public class Init : MonoBehaviour
    {
        // Start is called before the first frame update
        private Sprite _currentSprite;
        private BoxCollider2D _coll;
        private SpriteRenderer _spr;

        [HideInInspector]
        public int damage;

        [HideInInspector] 
        public int shield;

        public int fullShield;
        public int maxBounces;
        
        [HideInInspector] 
        public int currentBounces;
        private void Start()
        {
            gameObject.SetActive(true);
            damage = 1;
            _coll = gameObject.GetComponentInChildren<BoxCollider2D>();
            _spr = gameObject.GetComponentInChildren<SpriteRenderer>();
            UpdateCollider();
        }

        // Update is called once per frame
        private void UpdateCollider()
        {
            Bounds sprite = _spr.sprite.bounds;

            _coll.size = sprite.size;
            _coll.offset = sprite.center;
        }

        public void restoreShields()
        {
            shield = fullShield;
        }

        public void restoreBounces()
        {
            currentBounces = maxBounces;
        }
    }
}