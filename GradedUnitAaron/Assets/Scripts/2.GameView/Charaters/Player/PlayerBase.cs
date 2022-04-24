using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public static CharacterBase m_CharacterBase = new CharacterBase();

    public static Transform m_Transform;
    public GameObject hitBox;
    private bool doOnce;

    void Start()
    {
        m_CharacterBase.health = 10;
    }
    

    void Update()
    {
        if (m_CharacterBase.health <= 0)
        {
            Dead();
        }
        m_Transform = transform;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            hitBox.gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            hitBox.gameObject.SetActive(false);
        }
    }

    void Dead()
    {
        //Restart Level from Last Save;
        Debug.LogError("YOU DIED!");
    }
}
