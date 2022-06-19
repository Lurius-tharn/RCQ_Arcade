using UnityEngine;

public class FirstGameManager : MonoBehaviour
{
    // Values and methods for testing
    public static bool effectsEnabled = true;
    public static bool startEnabled = true;
    public static bool updateEnabled = true;
    public static bool ballsEnabled = true;
    public static bool testEnabled;


    public static FirstGameManager instance;

    public static Player player;
    public static int score;


    public GameObject playerPrefab;
    public GameObject rugbyBallPrefab;
    public GameObject bombPrefab;
    public GameObject mainCanvasPrefab;
    public bool partyFinished;
    public bool staunt;
    public float time = 60;
    [HideInInspector] public float ballSpawnDelay = 1.0f;
    [HideInInspector] public float ballSpawnTimer;

    private void Start()
    {
        if (startEnabled)
            player = Instantiate(playerPrefab, new Vector2(-3230, 363), Quaternion.identity)
                .GetComponentInChildren<Player>();
        else
            player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity)
                .GetComponentInChildren<Player>();
        partyFinished = false;
        staunt = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!partyFinished)
        {
            UpdateTimers();
            if (ballSpawnTimer <= 0.0f && ballsEnabled && !rugbyBallPrefab.scene.IsValid()) SpawnRugbyBall();
            if (Random.Range(1, 2500) < 2) SpawnBomb();
            if (time < 25) rugbyBallPrefab.GetComponentInChildren<Rigidbody2D>().gravityScale = Random.Range(300, 700);
        }
    }

    private void OnEnable()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Time.timeScale = 1.0f;
        score = 0;
    }

    public static void InitializeTestingEnvironment(bool start, bool update, bool effects, bool balls, bool test)
    {
        effectsEnabled = effects;
        startEnabled = start;
        updateEnabled = update;
        ballsEnabled = balls;
        testEnabled = test;
    }


    private void UpdateTimers()
    {
        if (ballSpawnTimer > 0.0f)
            ballSpawnTimer -= Time.deltaTime;
    }

    public void SpawnRugbyBall()
    {
        BallController ball;


        if (Camera.main != null)
        {
            Vector2 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(
                Random.Range(-0f, 1f),
                1f));
            ball = Instantiate(rugbyBallPrefab, spawnPosition
                ,
                Quaternion.identity).GetComponentInChildren<BallController>();
        }

        else
        {
            ball = Instantiate(rugbyBallPrefab, Vector2.zero, Quaternion.identity).GetComponent<BallController>();
        }


        ballSpawnTimer = ballSpawnDelay;
    }

    public void SpawnBomb()
    {
        BombController bomb;

        Vector2 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(
            Random.Range(-0f, 1f),
            1f));
        if (Camera.main != null)
            bomb = Instantiate(bombPrefab, spawnPosition
                ,
                Quaternion.identity).GetComponentInChildren<BombController>();

        else
            bomb = Instantiate(bombPrefab, Vector2.zero, Quaternion.identity).GetComponent<BombController>();


        ballSpawnTimer = ballSpawnDelay;
    }
}