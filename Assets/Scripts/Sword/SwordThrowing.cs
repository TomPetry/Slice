using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Sword
{
    public class SwordThrowing : MonoBehaviour
    {
        private float _dragDistance;
    
        private const int MinAngle = 80;

        [HideInInspector] public bool isTouching = false;
        private const float Speed = 10;

        private Vector2 _start;
        private Vector2 _end;

        [HideInInspector] public Vector2 beginPos;

        private Rigidbody2D _rigid;

        public GameObject respawnPos;
        
        // Start is called before the first frame update
        private void Start()
        {
            _dragDistance = Screen.height * 15 / 100f;
            _rigid = gameObject.GetComponent<Rigidbody2D>();
            
        }

        // Update is called once per frame
        private void Update()
        {
            ThrowSword();
        }

        [SuppressMessage("ReSharper", "InvertIf")]
        private void ThrowSword()
        {
            if (isTouching) return;

            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    _start = touch.position;
                    _end = touch.position;
                    Vector3 position = transform.position;
                    beginPos = position;
                    respawnPos.transform.position = position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    _end = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    _end = touch.position;

                    double angleDeg = CalculateThrowingAngle();
                    int currentMinAngle = CalculateAngleBounds();

                    if ((Mathf.Abs(_end.x - _start.x) > _dragDistance || Mathf.Abs(_end.y - _start.y) > _dragDistance) &&
                        angleDeg <= currentMinAngle + 2 * MinAngle && angleDeg >= currentMinAngle)
                    {
                        isTouching = true;
                        Vector2 direction = new Vector2(_end.x - _start.x, _end.y - _start.y);
                        direction.Normalize();
                        _rigid.velocity = direction * Speed;
                    }
                }
            }
        }

        private int CalculateAngleBounds()
        {
            int currentMinAngle = 0;

            if (beginPos.y < 0)
            {
                currentMinAngle = 90 - MinAngle;
            }
            else currentMinAngle = 270 - MinAngle;

            return currentMinAngle;
        }

        private double CalculateThrowingAngle()
        {
            double angleDeg = Mathf.Atan2(_end.y - _start.y, _end.x - _start.x) * 180 / Math.PI;
            angleDeg = (angleDeg + 360) % 360;
            return angleDeg;
        }
    }
}