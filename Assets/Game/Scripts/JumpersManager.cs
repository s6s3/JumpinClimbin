using UnityEngine;
using System.Collections;

public class JumpersManager : MonoBehaviour {
    public float fieldRadius = 5;
    public int levelUpSpeed = 50;

    [SerializeField, Space(10)]
    public GameObject startJumper;
    public float intervalJumper = 5;
    public int jumperNumberOverPlayer = 5;
    [SerializeField, Range(0, 1)]
    public float powerJumperRate = 0.1f;
    public float entryPointPowerJumper = 50;

    [SerializeField, Space(10)]
    private GameObject jumperPrefab;
    [SerializeField]
    private GameObject powerJumperPrefab;
    [SerializeField]
    private GameObject startJumperPrefab;

    private PlayerManager playerManager;
    private ScoreManager scoreManager;

    private int level = 0;
    
    private float maximumJumperY;

	
    void Start()
    {
        ToTitle();
    }

    public void SetManager(PlayerManager pm, ScoreManager sm)
    {
        playerManager = pm;
        scoreManager = sm;
    }
	
    public void ToTitle()
    {
        GameObject[] jumpers = GameObject.FindGameObjectsWithTag("Jumper");
        foreach (GameObject go in jumpers)
        {
            Destroy(go);
        }

        startJumper = Instantiate(startJumperPrefab);
        startJumper.GetComponent<Rigidbody>().velocity = new Vector3();
        Jumper tmpjump = startJumper.GetComponent<Jumper>();
        tmpjump.playerManager = playerManager;
        maximumJumperY = startJumper.transform.position.y + intervalJumper;
        level = 0;
    }

    public void ToMain()
    {
        
    }
	
	public void UpdateMain () {
        level = scoreManager.GetScore() / levelUpSpeed;

        int round = scoreManager.GetScore() + (10 - scoreManager.GetScore() % 10);
        while(round + intervalJumper * jumperNumberOverPlayer > maximumJumperY)
        {
            if (maximumJumperY > entryPointPowerJumper && Random.value < powerJumperRate) GeneratePowerJumper();
            GenerateNormalJumper();
        }
	
	}

    private void GenerateNormalJumper()
    {
        maximumJumperY += intervalJumper;
        GameObject go = Instantiate(jumperPrefab);
        Vector3 randVec = Random.insideUnitCircle * (fieldRadius + level);
        go.transform.position = new Vector3(randVec.x, maximumJumperY, randVec.y);
        Jumper tmpjump = go.GetComponent<Jumper>();
        tmpjump.playerManager = playerManager;
        SpringJoint spjoint = go.GetComponent<SpringJoint>();
        spjoint.connectedAnchor = go.transform.position + spjoint.anchor;
        
    }

    private void GeneratePowerJumper()
    {
        GameObject go = Instantiate(powerJumperPrefab);
        Vector3 randVec = Random.insideUnitCircle.normalized * ((fieldRadius + level) * 2);
        go.transform.position = new Vector3(randVec.x, maximumJumperY, randVec.y);
        Jumper tmpjump = go.GetComponent<Jumper>();
        tmpjump.playerManager = playerManager;
        SpringJoint spjoint = go.GetComponent<SpringJoint>();
        spjoint.connectedAnchor = go.transform.position + spjoint.anchor;

    }

}
