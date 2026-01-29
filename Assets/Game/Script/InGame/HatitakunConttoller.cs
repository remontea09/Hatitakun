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
    private float jumpPower = 8f; //ジャンプのパワー

    //ジャンプ可能か
    private bool isJamp = false;

    //移動可能か
    private bool isMove = true;


    private void Start()
    {
        hatitaRig.gravityScale = 2f;
        SkinService.Instance.GetSkinSprites(out rightHatita, out leftHatita);
        hatitaSprite.sprite = rightHatita;

        if(SkinService.Instance.skinType == SkinType.angel)
        {
            jumpPower = 4f;
        }
        else if(SkinService.Instance.skinType == SkinType.devil)
        {
            jumpPower = 10f;
        }
        else if(SkinService.Instance.skinType == SkinType.cat)
        {
            moveSpeed.x += 0.1f;
        }
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
                    hatitaRig.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
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
    
    public void UpJumpPower()
    {
        jumpPower += 1;
    }

    public void DownJumpPower()
    {
        jumpPower -= 1;
    }
}
