using UnityEditor.ShaderGraph.Serialization;
using UnityEditor.Tilemaps;
using UnityEngine;

public class HatitaController : MonoBehaviour
{

    //inspectorからつける
    [SerializeField] private GameObject hatitakun;
    [SerializeField] private SpriteRenderer hatitaSprite;
    [SerializeField] private Rigidbody2D hatitaRig;
    [SerializeField] private Sprite rightHatita;
    [SerializeField] private Sprite leftHatita;

    

    //ステータス
    private Vector2 moveSpeed = new Vector2(0.1f, 0); //移動速度
    private float jampPower = 8f; //ジャンプのパワー

    //ジャンプ可能か
    private bool isJamp = false;

    //移動可能か
    private bool isMove = true;


    private void Awake()
    {
        hatitaRig.gravityScale = 2f;
        //SkinService.Instance.SetSkin(rightHatita, leftHatita);
    }


    //移動
    private void Update()
    {
        
        if (isMove)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Vector2 transform = hatitakun.transform.position;
                transform -= moveSpeed;
                hatitakun.transform.position = transform;
                hatitaSprite.sprite = leftHatita;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector2 transform = hatitakun.transform.position;
                transform += moveSpeed;
                hatitakun.transform.position = transform;
                hatitaSprite.sprite = rightHatita;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isJamp)
                {
                    isJamp = true;
                    hatitaRig.AddForce(Vector2.up * jampPower, ForceMode2D.Impulse);
                }
            }
        }
    }

    //地面と当たったらジャンプ可能に
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJamp = false;
        }
    }
    

    public void ChangeIsMove(bool b)
    {
        isMove = b;
    }
}
