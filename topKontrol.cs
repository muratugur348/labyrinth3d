using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topKontrol : MonoBehaviour 
{
    public UnityEngine.UI.Text zaman;
    public UnityEngine.UI.Text menuyedon;
    public bool isGameEnd = false;
    private Rigidbody rg;
    float zamanSayaci=10;
    TextMesh textObject;
    public Material final;
    public AudioSource audioSource;
    public Material sesdegeri;
    void Start()
    {
        audioSource.volume = float.Parse(sesdegeri.name)/3;
        
        textObject = GameObject.Find("hak").GetComponent<TextMesh>();

        changeLanguage(System.Convert.ToInt16(final.name));
        



    }
    public float gerisayim = 1;
    public TextAsset textFile;
    string[,] sozluk = new string[11, 3];
    int dilsayisi;
    
    public void changeLanguage(int dilsayisi)
    {
        this.dilsayisi = dilsayisi;
        string text = textFile.text;
        string[] lines = text.Split('\n');

        
        string satir = "";
        foreach (string value in lines)
        {
            satir += value;

        }

        string[] kelimeler = satir.Split(',');
        int i = 0;
        int j = 0;
        foreach (string value in kelimeler)
        {
            sozluk[i, j] = value;
            j++;

            if (j == 3)
            { j = 0; i++; }

        }
        menuyedon.text = sozluk[5, dilsayisi];
    }
    // Update is called once per frame
    void Update()
    {
        zamanSayaci -= Time.deltaTime;
        zaman.text = System.Convert.ToInt32(zamanSayaci).ToString();
        if (zamanSayaci <= 0)
        {
            Time.timeScale = 0;
            textObject.text = sozluk[9,dilsayisi];
            this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0);

            zamanSayaci = 10;

        }
        if (isGameEnd == true)
        {
            gerisayim -= Time.deltaTime;
            zamanSayaci += Time.deltaTime;
            if (gerisayim <= 0)
            {
                Time.timeScale = 0;
                gerisayim = 1;
            }
        }

    }
    void FixedUpdate()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        Vector3 kuvvet = new Vector3(yatay,0,dikey);
        GetComponent<Rigidbody>().AddForce(kuvvet*5);
        
    }
    public int sayac = 3;
    void OnCollisionEnter(Collision cls)
    {
        if (cls.gameObject.name != "zemin" && cls.gameObject.name != "oyunZemini" && cls.gameObject.name != "final" && isGameEnd!=true)
        {
            audioSource.Play();
         sayac--; }
        if (cls.gameObject.name.Equals("final") && sayac > 0)
        {
            textObject.text = sozluk[8, dilsayisi];
            textObject.fontSize = 20;
            isGameEnd = true;
            this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0);



        }
        else if (sayac == 0 && isGameEnd != true)
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0);

            textObject.text = sozluk[7, dilsayisi];
            Time.timeScale = 0;
        }
        else if (sayac > 0 && isGameEnd != true) {
        textObject.text = sayac + sozluk[6, dilsayisi];
    }
    }
    
}
