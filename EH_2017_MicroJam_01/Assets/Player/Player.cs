using UnityEngine;

public class Player : MonoBehaviour {

    public int Vite = 3;
    public KeyCode TastoAppiattito = KeyCode.W;
    public KeyCode TastAllungato = KeyCode.S;

    private StatoDelBlob _state;
    public StatoDelBlob State
    {
        get { return _state; }
        set
        {
            _state = value;
        }
    }

    float currentSpentTime = 0;
    public TextMesh text;
    public GameObject GameOver;

    Animator animator;

    // Use this for initialization
    void Start () {
        State = StatoDelBlob.Sfera;
        animator = GetComponent<Animator>();
        if(text)
            text.text = "Vite: " + Vite;

        if (GameOver)
            GameOver.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(TastoAppiattito))
        {
            ChangeState(StatoDelBlob.Piatto);
        }else if (Input.GetKey(TastAllungato))
        {
            ChangeState(StatoDelBlob.Lungo);
        }
        else
        {
            ChangeState(StatoDelBlob.Sfera);
        }
    }

    void ChangeState(StatoDelBlob _state)
    {
        currentSpentTime += Time.deltaTime;

        if(currentSpentTime >= 1)
        {
            State = _state;
            animator.SetInteger("BlobState", (int)State);
            currentSpentTime = 0;
        }
    }

    public void Die()
    {
        Vite--;
        if(text)
            text.text = "Vite: " + Vite;

        if(Vite < 0)
        {
            if (text)
                text.text = "";

            if (GameOver)
                GameOver.SetActive(true);

            Time.timeScale = 0;
        }
    }
}

public enum StatoDelBlob
{
    Sfera,
    Piatto,
    Lungo
}
