using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

    private int m_Lives = 3;
    private int m_Bricks = 0;
    private int m_Level = 0;
    private bool InGame;
    public Text TxtLives;
    public Text TxtWon;
    public Text TxtGameOver;
    public float m_ResetDelay = 1.0f;
    public GameObject[] BricksPrefab;
    public GameObject PaddlePrefab;
    public GameObject DeathParticles;

    public static GM instance = null;

    private GameObject ClonePaddle;
    private GameObject CloneBricks;

    // Use this for initialization
    void Start () {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        Setup();
    }
	private void Setup() {
        TxtGameOver.enabled = TxtWon.enabled=false;
        SetupPaddle();
        CloneBricks=Instantiate(BricksPrefab[m_Level], transform.position, Quaternion.identity);
        m_Bricks = GameObject.FindGameObjectsWithTag("Destroyable").Length;
        InGame = true;
    }
    private void SetupPaddle() {
        TxtLives.text = "Lives: " + m_Lives.ToString() + "\nLevel: " + m_Level.ToString() ;
        ClonePaddle = Instantiate(PaddlePrefab, transform.position, Quaternion.identity);
    }

    private void CheckGameOver() {
        if(m_Bricks<=0) {
            m_Level++;
            TxtWon.enabled=(true);
            Time.timeScale = 0.25f;
            Invoke("Reset", m_ResetDelay);
            InGame = false;
        }
        if (m_Lives <= 0) {
            m_Level = 0;
            TxtGameOver.enabled = (true);
            Time.timeScale = 0.25f;
            Invoke("Reset", m_ResetDelay);
            InGame = false;
        }

    }
    private void Reset() {
        m_Lives = 3;
        Destroy(ClonePaddle);
        Destroy(CloneBricks);
        Time.timeScale = 1f;
        Invoke("Setup", m_ResetDelay);
        //  UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    }
    public void DestroyBrick() {
        m_Bricks--;
        CheckGameOver();
    }
    public void LooseLive() {
        if (!InGame) return;
        m_Lives--;
        Instantiate(DeathParticles, ClonePaddle.transform.position, Quaternion.identity);
        Destroy(ClonePaddle);
        Invoke("SetupPaddle", m_ResetDelay);
        CheckGameOver();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
