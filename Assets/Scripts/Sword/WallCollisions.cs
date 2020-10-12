using Enemies;
using Master;
using UnityEngine;

namespace Sword
{
    public class WallCollisions : MonoBehaviour
    {
        private Rigidbody2D _rigid;
        private SpawnEnemies _spawn;

        private SwordThrowing _swordThrowing;
        private MasterCounter _master;
        private Init _init;

        // Start is called before the first frame update
        void Start()
        {
            _swordThrowing = GetComponent<SwordThrowing>();
            _rigid = gameObject.GetComponent<Rigidbody2D>();
            _spawn = GameObject.Find("SpawnArea").GetComponent<SpawnEnemies>();
            _master = GameObject.Find("GameMaster").GetComponent<MasterCounter>();
            _init = GetComponent<Init>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("StopWall"))
            {
                if (_init.currentBounces > 0)
                {
                    _rigid.velocity *= new Vector2(1,-1);
                    _init.currentBounces--;
                }
                else
                {
                    _spawn.SpawnEnemyAmount(1);
                    stopSword();
                    _master.EndOfTurn();
                }
            }

            if (other.gameObject.CompareTag("TeleportWall"))
            {
                transform.position = _swordThrowing.beginPos;
                _rigid.velocity = Vector2.zero;
                _swordThrowing.isTouching = false;
            }

            if (other.gameObject.CompareTag("Bounce"))
            {
                _rigid.velocity *= new Vector2(-1, 1);
            }
        }

        public void stopSword()
        {
            _rigid.velocity = Vector2.zero;
            _swordThrowing.isTouching = false;
            _init.restoreBounces();
            _init.restoreShields();
        }
    }
}