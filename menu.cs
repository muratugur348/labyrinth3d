using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject anamenu;
    public GameObject dillermenu;
    public int dilsayisi;
    public Material final;
    public void PlayGame()
    {
        final.name = (dilsayisi).ToString();
        PlayerPrefs.SetInt("dilsayisi", dilsayisi); // totalScoreKey anahtarıyla totalScore verisini sakla
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void QuitGame()
    {
        Application.Quit(); 
    }
    public void main2languages()
    {
        anamenu.SetActive(false);
        dillermenu.SetActive(true);
    }
    public void languages2main()
    {
        anamenu.SetActive(true);
        dillermenu.SetActive(false);
    }

    public TextAsset textFile;
    public Text geri;
    public Text basla;
    public Text cikis;
    public Text diller;
    public Text baslik1;
    public Text baslik2;
    public Text ses;


    public void changeLanguage(int dilsayisi)
    {
        PlayerPrefs.SetInt("dilsayisi", dilsayisi);
        this.dilsayisi = dilsayisi;
        string text = textFile.text;
        string[] lines = text.Split('\n');

        string[,] sozluk = new string[11,3];
        string satir = "";
        foreach (string value in lines) {
            satir += value;

        }
        
        string[] kelimeler = satir.Split(',');
        int i = 0;
        int j = 0;
        foreach (string value in kelimeler)
        {
            sozluk[i, j] = value;
            j++;
            
            if (j==3)
            { j = 0; i++; }

        }
        geri.text = sozluk[0, dilsayisi];
        basla.text = sozluk[1, dilsayisi];
        cikis.text = sozluk[2, dilsayisi];
        diller.text = sozluk[3, dilsayisi];
        baslik1.text = sozluk[4, dilsayisi] + " 3D";
        baslik2.text = sozluk[4, dilsayisi] +" 3D";
        ses.text = sozluk[10, dilsayisi];
        changeFlag(dilsayisi);

    }
    public Image bayraklar;
    public Sprite turkiye;
    public Sprite ingiltere;
    public Sprite ispanya;
    public void changeFlag(int dilsayisi)
    {
        if (dilsayisi==0)
        {
            bayraklar.sprite = turkiye;
        }
        if (dilsayisi == 1)
        {
            bayraklar.sprite = ingiltere;
        }
        if (dilsayisi == 2)
        {

            bayraklar.sprite = ispanya;
        }
    }
    // Start is called before the first frame update

    void Start()
    {
        if (PlayerPrefs.HasKey("dilsayisi"))  //totalScoreKey anahtarıyla kaydedilmiş bir veri var mı ?
        {
            dilsayisi = PlayerPrefs.GetInt("dilsayisi"); // totalScoreKey anahtarıyla kaydedilmiş veriyi getir
        }
        else
        {
            dilsayisi = 0;

        }

        changeLanguage(dilsayisi);
        changeFlag(dilsayisi);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
