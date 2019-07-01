using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    public Sprite[] beklemeAnim;
    public Sprite[] ziplamaAnim;
    public Sprite[] yurumeAnim;
    int beklemeAnimSayac=0;
    int yurumeAnimSayac=0;
    int ziplamaAnimSayac=0;
    SpriteRenderer SpriteRenderer;
    float horizontal=0;
    float beklemeAnimZaman = 0;
    float yurumeAnimZaman = 0;
    Rigidbody2D fizik;
    Vector3 vec;
    bool ziplamaKontrol=true;
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ziplamaKontrol)
        {
            fizik.AddForce(new Vector2(0, 500));
            ziplamaKontrol = false;
        }   
    }
    void FixedUpdate()
    {
        KarakterHareket();
        Animasyon();
    }
    void Animasyon()
    {
        if (horizontal == 0)
        {
            beklemeAnimZaman += Time.deltaTime;
            if (beklemeAnimZaman>0.05f)
            {
                SpriteRenderer.sprite = beklemeAnim[beklemeAnimSayac++];
                if (beklemeAnimSayac == beklemeAnim.Length)
                {
                    beklemeAnimSayac = 0;
                }
                beklemeAnimZaman = 0;
            }
                
        }
        else if (horizontal > 0)
        {
            yurumeAnimZaman += Time.deltaTime;
            if (yurumeAnimZaman > 0.02f)
            {
                SpriteRenderer.sprite = yurumeAnim[yurumeAnimSayac++];
                if (yurumeAnimSayac == yurumeAnim.Length)
                {
                    yurumeAnimSayac = 0;
                }
                yurumeAnimZaman = 0;
            }
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(horizontal<0)
        {
            yurumeAnimZaman += Time.deltaTime;
            if (yurumeAnimZaman > 0.02f)
            {
                SpriteRenderer.sprite = yurumeAnim[yurumeAnimSayac++];
                if (yurumeAnimSayac == yurumeAnim.Length)
                {
                    yurumeAnimSayac = 0;
                }
                yurumeAnimZaman = 0;
            }
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    void KarakterHareket()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vec = new Vector3(horizontal * 10, fizik.velocity.y, 0);
        fizik.velocity = vec;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ziplamaKontrol = true;//yere temas ettiğimde tekar zıplaması için yapıldı
    }
}
