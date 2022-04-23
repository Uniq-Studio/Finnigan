using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawnIn : MonoBehaviour
{
    public GameObject Stone;
    public GameObject Stick;
    public GameObject Leaf;
    public GameObject Snail;

    private int _xPos;
    private int _yPos;
    private int _zPos;
    private int _type;

    private Vector3 _location;

    private bool _doOnce;

    void Update()
    {
        TreeLogic();
    }

    void TreeLogic()
    {
        if (!_doOnce)
        {
            _xPos = RandomNumGen(-5, 5);
            _yPos = RandomNumGen(5, 10);
            _zPos = RandomNumGen(-5, 5);

            _type = RandomNumGen(1, 5);

            switch (_type)
            {
                case 1:
                    SpawnIn(Stone, _xPos, _yPos, _zPos);
                    break;
                case 2:
                    SpawnIn(Stick, _xPos, _yPos, _zPos);
                    break;
                case 3:
                    SpawnIn(Leaf, _xPos, _yPos, _zPos);
                    break;
                case 4:
                    SpawnIn(Snail, _xPos, _yPos, _zPos);
                    break;
            }
            StartCoroutine(Timer());
            _doOnce = true;
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(300);
        _doOnce = false;
    }

    void SpawnIn(GameObject type, int x, int y, int z)
    {
        _location = transform.position + new Vector3(x, y, z);
        Instantiate(type, _location , transform.localRotation);
    }

    int RandomNumGen(int val1, int val2)
    {
        int num = Mathf.RoundToInt(Random.Range(val1, val2));
        return num;
    }
    //https://answers.unity.com/questions/624603/type-function-not-returning-c.html
}
