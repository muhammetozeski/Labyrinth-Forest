using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MainGame.GroundSystem
{
    /*
     * NOT: ÖNCEKİ YERLERİ YOK ETMEYİ DAHA YAZMADIK. ONU YAZ!
     */
    enum directions { up, down, right, left, topRight, topLeft, downRight, downLeft }
    public class GroundSettings : ScriptableObject
    {
        private Vector3 _groundPosition;
        public Vector3 GroundPosition
        {
            get { return _groundPosition; }
            set
            {
                CheckX(value);
                _groundPosition = value;
            }
        }

        [SerializeField] private float _creatingDistance = 1000f;
        public float CreatingDistance { get { return _creatingDistance; } private set { } }
        
        [SerializeField] private float _groundSize = 6000f;
        public float GroundSize { get { return _groundSize; } private set { } }

        [SerializeField] Transform Player;

        bool  up = false, down = false;
        GameObject UpGround, DownGround, RightGround, LeftGround, TopRightGround, TopLeftGround, DownRightGround, DownLeftGround;

        void CheckX(Vector3 value)
        {
            if (Mathf.Abs(value.x) == CreatingDistance)
            {
                if (value.x < 0)
                {
                    //player is going to right
                    if (LeftGround)
                        Destroy(LeftGround);
                    if (TopLeftGround)
                        Destroy(TopLeftGround);
                    if (DownLeftGround)
                        Destroy(DownLeftGround);

                    
                    CreateGround(directions.right, value, DetermineDistance(directions.right, value));

                    if (CheckZ(value))
                    {
                        if (up)
                        {
                            CreateGround(directions.topRight, value, DetermineDistance(directions.up, value));
                        }
                        if (down)
                        {
                            CreateGround(directions.downRight, value, DetermineDistance(directions.down, value));
                        }
                    }
                }
                else if (value.x > 0)
                {
                    //player is going to left
                    if(RightGround)
                        Destroy(RightGround);
                    if (TopRightGround)
                        Destroy(TopRightGround);
                    if (DownRightGround)
                        Destroy(DownRightGround);
                    CreateGround(directions.left, value, DetermineDistance(directions.left, value));
                    if (CheckZ(value))
                    {
                        if (up)
                        {
                            CreateGround(directions.topLeft, value, DetermineDistance(directions.up, value));
                        }
                        if (down)
                        {
                            CreateGround(directions.downLeft, value, DetermineDistance(directions.down, value));
                        }
                    }
                }
            }
            else if (!CheckZ(value) && value.x == 0 && value.z == 0)
            {
                Destroy(UpGround);
                Destroy(DownGround);
                Destroy(LeftGround);
                Destroy(RightGround);
                Destroy(TopLeftGround);
                Destroy(TopRightGround);
                Destroy(DownLeftGround);
                Destroy(DownRightGround);
            }
        }
        bool CheckZ(Vector3 value)
        {
            if (Mathf.Abs(value.z) == CreatingDistance)
            {
                if (value.z < 0)
                {
                    //player is going to down
                    up = false;
                    down = true;
                    if (UpGround)
                        Destroy(UpGround);
                    if (TopRightGround)
                        Destroy(TopRightGround);
                    if (TopLeftGround)
                        Destroy(TopLeftGround);
                    CreateGround(directions.down, value, DetermineDistance(directions.down, value));
                }

                if (value.z > 0)
                {
                    //player is going to up
                    down = false;
                    up = true;
                    if (DownGround)
                        Destroy(DownGround);
                    if (DownRightGround)
                        Destroy(DownRightGround);
                    if (DownLeftGround)
                        Destroy(DownLeftGround);
                    CreateGround(directions.up, value, DetermineDistance(directions.up, value));
                }
                return true;
            }
            else
                return false;
        }
        void CreateGround(directions direction, Vector3 value, bool _necessaryDistance)
        {
            GameObject _choosenGround = ChooseGround();
            Vector3 _newGroundPosition;
            
            if (direction == directions.up && UpGround == null && _necessaryDistance)
            {
                _newGroundPosition = value + (Vector3.up * GroundSize);
                UpGround = Instantiate(_choosenGround, _newGroundPosition, Quaternion.identity);
            }
            else if (direction == directions.down && DownGround == null && _necessaryDistance)
            {
                _newGroundPosition = value + (Vector3.down * GroundSize);
                DownGround = Instantiate(_choosenGround, _newGroundPosition, Quaternion.identity);
            }
            else if (direction == directions.left && LeftGround == null && _necessaryDistance)
            {
                _newGroundPosition = value + (Vector3.left * GroundSize);
                LeftGround = Instantiate(_choosenGround, _newGroundPosition, Quaternion.identity);
            }
            else if (direction == directions.right && RightGround == null && _necessaryDistance)
            {
                _newGroundPosition = value + (Vector3.right * GroundSize);
                RightGround = Instantiate(_choosenGround, _newGroundPosition, Quaternion.identity);
            }
            else if (direction == directions.topLeft && TopLeftGround == null && _necessaryDistance)
            {
                _newGroundPosition = value + (Vector3.right * GroundSize) + (Vector3.up * GroundSize);
                TopLeftGround = Instantiate(_choosenGround, _newGroundPosition, Quaternion.identity);
            }
            else if (direction == directions.topRight && TopRightGround == null && _necessaryDistance)
            {
                _newGroundPosition = value + (Vector3.right * GroundSize) + (Vector3.up * GroundSize);
                TopRightGround = Instantiate(_choosenGround, _newGroundPosition, Quaternion.identity);
            }
            else if (direction == directions.downLeft && DownLeftGround == null && _necessaryDistance)
            {
                _newGroundPosition = value + (Vector3.left * GroundSize) + (Vector3.down * GroundSize);
                DownLeftGround = Instantiate(_choosenGround, _newGroundPosition, Quaternion.identity);
            }
            else if (direction == directions.downRight && DownRightGround == null && _necessaryDistance)
            {
                _newGroundPosition = value + (Vector3.right * GroundSize) + (Vector3.down * GroundSize);
                DownRightGround = Instantiate(_choosenGround, _newGroundPosition, Quaternion.identity);
            }
        }

        GameObject ChooseGround()//TASLAK FONKSİYON!
        {
            GameObject _choosenGround = new GameObject();
            Debug.LogError("Taslak fonksiyon \"ChooseGround\" kullanılmakta!");
            return _choosenGround;
        }

        bool DetermineDistance(directions direction, Vector3 value)
        {
            float _distance = 0; //groundSize/4 ile (groundSize/4) + creatingDistance arasında ise devam etsin
            bool _necessaryDistance;
            if (direction == directions.up)
            {
                _distance = Player.position.y - value.y;
            }
            else if (direction == directions.down)
            {
                _distance = Mathf.Abs(Player.position.y - value.y);
            }
            else if (direction == directions.right)
            {
                _distance = Player.position.x - value.x;
            }
            else if (direction == directions.left)
            {
                _distance = Mathf.Abs(Player.position.x - value.x);
            }
            _necessaryDistance = _distance > GroundSize / 4 && _distance < (GroundSize / 4) + CreatingDistance;

            return _necessaryDistance;
        }
    }
}
