using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buffcards : MonoBehaviour
{
    // Start is called before the first frame update
    private Button[] cards;
    private TimeHandling time;
    //List<int> value;
    //List<int> probability;
    int erg = 0;
    float ergF = 0.0f;
    string description;
    GameObject canvas;
    bool canvasActive = true;

    public Animator anim;
    public Animator thisAnim;
    private void Awake()
    {
        canvas = GameObject.Find("Crossfade");
        anim = canvas.GetComponent<Animator>();
        thisAnim = GetComponentInChildren<Animator>();
        anim.speed = 0f;

    }
    void Start()
    {
        //Time.timeScale =0.05f;
        cards = GetComponentsInChildren<Button>();

        //foreach(Button card in cards)
        for(int c = 0; c < 3; c++)
        {
            description = "";
            int buffEffekt = Random.Range(0, 7);
            int debuffEffekt = Random.Range(0, 7);
            Debug.Log("KARTE "+c+" : Buff " + buffEffekt+ " - Debuff "+debuffEffekt);
            buffSelect(buffEffekt, cards[c]);
            debuffSelect(debuffEffekt, cards[c]);
            cards[c].onClick.AddListener(toggleCanvas);
        }

        cards[3].onClick.AddListener(toggleCanvas);


        time = FindObjectOfType<TimeHandling>();
    }

    void shuffleCards()
    {
        cards = GetComponentsInChildren<Button>();

        //foreach(Button card in cards)
        for (int c = 0; c < 3; c++)
        {
            cards[c].onClick.RemoveAllListeners();
            description = "";
            int buffEffekt = Random.Range(0, 7);
            int debuffEffekt = Random.Range(0, 7);
            Debug.Log("KARTE " + c + " : Buff " + buffEffekt + " - Debuff " + debuffEffekt);
            buffSelect(buffEffekt, cards[c]);
            debuffSelect(debuffEffekt, cards[c]);
            cards[c].onClick.AddListener(toggleCanvas);
        }


    }

    void buffSelect(int buffIndex, Button card)
    {
        //int erg;

        switch(buffIndex)
        {
            case 0:
                description = "Timer dauer verdoppelt sich!";
                //card.GetComponentInChildren<Text>().text = description;
                card.onClick.AddListener(buff0);
                break;
            case 1:
                float[] a = new float[] { 5.0f,10.0f,15.0f,20.0f };
                int[] b = new int[] { 50, 85, 95 };
                ergF = valueRandomizerF(a, b);
                description = "Timer läuft "+ergF+"% langsamer runter!";
                //card.GetComponentInChildren<Text>().text = description;
                card.onClick.AddListener(buff1);
                break;
            case 2:
                int[] a2 ={ 1, 2, 3, 10 };
                int[] b2 = { 50, 85, 98 };
                erg = valueRandomizer(a2, b2);
                description = "Angriffe von Gegner fügen "+erg+" Sekunde weniger schaden zu!";
               //card.GetComponentInChildren<Text>().text = description;
                card.onClick.AddListener(buff2);
                break;
            case 3:
                int[] a3 = { 2, 5, 10, 50 };
                int[] b3 = { 40,80,97 };
                erg = valueRandomizer(a3, b3);
                description = "Angriffe von Gegnern fügen "+erg+"% weniger Schaden zu.";
                //card.GetComponentInChildren<Text>().text = description;
                card.onClick.AddListener(buff3);
                break;
            case 4:
                int[] a4 = { 5, 10, 15 };
                int[] b4 = { 50, 80 };
                erg = valueRandomizer(a4, b4);
                description = "Du bewegst dich "+erg+"% schneller";
                //card.GetComponentInChildren<Text>().text = description;
                card.onClick.AddListener(buff4);
                break;
            case 5:
                int[] a5 = { 5, 10, 15 };
                int[] b5 = { 50, 80 };
                erg = valueRandomizer(a5, b5);
                description = "Du erhälst "+erg + "% mehr Attack Speed";
                //card.GetComponentInChildren<Text>().text = description;
                card.onClick.AddListener(buff5);
                break;

                case 6:
                    int[] a6 = { 5, 10, 15 };
                    int[] b6 = { 50, 80 };
                    erg = valueRandomizer(a6, b6);
                    description = "Gegner greifen "+erg+"% langsamer an";
                    //card.GetComponentInChildren<Text>().text = description;
                    card.onClick.AddListener(buff6);
                    break;
        }
    }


    //speedbuff machen
    //AttackSpeed erh�hen

    //LLeben von gegner verringern

    //CD von Special Move verringern
    //Konter Effekte verst�rken

    void debuffSelect(int debuffIndex, Button card)
    {
        switch (debuffIndex)
        {
            case 0:
                description += "\n\n\n - \n\n Timer dauer halbiert sich.";
                card.GetComponentInChildren<Text>().text = description;
                card.onClick.AddListener(debuff0);
                break;
            case 1:
                int[] a = new int[] { 5, 10, 15, 20 };
                int[] b = new int[] { 50, 85, 95 };
                erg = valueRandomizer(a, b);
                description += "\n\n\n - \n\n Timer dauer verringert sich um "+erg+"%.";
                card.GetComponentInChildren<Text>().text = description;
                card.onClick.AddListener(debuff1);
                break;
            case 2:
                int[] a2 = { 1, 2, 3 };
                int[] b2 = { 50, 85 };
                erg = valueRandomizer(a2, b2);
                description += "\n\n\n - \n\n Angriffe von Gegner fügen "+ erg +" Sekunden mehr Schaden zu.";
                card.GetComponentInChildren<Text>().text = description;
                card.onClick.AddListener(debuff2);
                break;
            case 3:
                int[] a3 = { 2, 5, 10, 50 };
                int[] b3 = { 40, 80, 97 };
                erg = valueRandomizer(a3, b3);
                description += "\n\n\n - \n\n Angriffe von Gegner fügen "+erg+"% mehr Schaden zu.";
                card.GetComponentInChildren<Text>().text = description;
                card.onClick.AddListener(debuff3);
                break;
            case 4:
                int[] a4 = { 5, 10, 15 };
                int[] b4 = { 50, 80 };
                erg = valueRandomizer(a4, b4);
                description += "\n\n\n - \n\n Du bewegst dich " + erg+"% langsamer";
                card.GetComponentInChildren<Text>().text = description;
                card.onClick.AddListener(debuff4);
                break;
            case 5:
                int[] a5 = { 5, 10, 15 };
                int[] b5 = { 50, 80 };
                erg = valueRandomizer(a5, b5);
                description += "\n\n\n - \n\n "+ erg + "% weniger Attack-Speed";
                card.GetComponentInChildren<Text>().text = description;
                card.onClick.AddListener(debuff5);
                break;

            case 6:
                int[] a6 = { 5, 10, 15 };
                int[] b6 = { 50, 80 };
                erg = valueRandomizer(a6, b6);
                description += "\n\n\n - \n\n Gegner greifen " + erg+"% schneller an";
                card.GetComponentInChildren<Text>().text = description;
                card.onClick.AddListener(debuff6);
                break;
        }
    }
    void buff0()
    {
        Time.timeScale =1;
        Debug.Log("Buff : Lebenszeit verdoppeln");
        HelpVariables.time *= 2;

    }

    void buff1()
    {
        Time.timeScale =1;
        Debug.Log("Buff : Lebenszeit verlangsamen"+ergF);
        time.decreaseTimeLossPerSecond(ergF);
    }

    void buff2()
    {
        Time.timeScale =1;
        Debug.Log("Buff 2");
    }

    void buff3()
    {
        Time.timeScale =1;
        Debug.Log("Buff 3");
    }

    void buff4()
    {
        Time.timeScale =1;
        Debug.Log("Buff 4");
    }

    void buff5()
    {
        Time.timeScale =1;
        Debug.Log("Buff 5");
    }

    void buff6()
    {
        Time.timeScale =1;
        Debug.Log("Buff 6");
    }


    //__________________
    // ____ DEBUFFS ____
    //__________________
    void debuff0()
    {
        Debug.Log("Debuff : Lebenszeit verdoppeln");
        HelpVariables.time /= 2;
    }

    void debuff1()
    {
        Debug.Log("Debuff : Lebenszeit verlangsamen");
        time.decreaseTimeLossPerSecond(erg);
    }

    void debuff2()
    {
        Debug.Log("deBuff 2");
    }

    void debuff3()
    {
        Debug.Log("deBuff 3");
    }

    void debuff4()
    {
        Debug.Log("deBuff 4");
    }

    void debuff5()
    {
        Debug.Log("deBuff 5");
    }

    void debuff6()
    {
        Debug.Log("deBuff 6");
    }

    private int valueRandomizer(int[] value, int[] probability)
    {
        int erg = 0;

        int random = Random.Range(0, 100);

        for (int i = 0; i< probability.Length; i++)
        {
            if (random <= probability[i])
            {
                return value[i];
            }
        }

        return value[probability.Length];

    }

    private float valueRandomizerF(float[] value, int[] probability)
    {
        int erg = 0;

        int random = Random.Range(0, 100);
        Debug.Log(("random: ")+random);

        for (int i = 0; i < probability.Length; i++)
        {
            if (random <= probability[i])
            {
                Debug.Log("i: "+ i+ "Value[i]: "+ value[i]);
                return value[i];
            }
        }

        return value[probability.Length];

    }

    public void toggleCanvas()
    {
        if (canvasActive)
        {
            thisAnim.SetTrigger("fadeOut");
            StartCoroutine(playTransition());
        } else
        {
            shuffleCards();
            canvasActive = true;
            gameObject.active = true;
            thisAnim.SetTrigger("fadeIn");
        }
    }

    public IEnumerator playTransition()
    {
        yield return new WaitForSeconds(0.5f);
        anim.speed = 1f;
        yield return new WaitForSeconds(1.5f);
        canvasActive = false;
        gameObject.active = canvasActive;
        
    }


    public void playTransition2()
    {

        anim.speed = 1f;
    }
}
