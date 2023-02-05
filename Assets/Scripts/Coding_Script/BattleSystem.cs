using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    Scene currScene;
    int Respawn;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public TMPro.TMP_Text dialogueText;
    public TMPro.TMP_Text hintText;
    public TMPro.TMP_Text nameText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public bool yes = true;

    private string inputLine;
    private string x;
    //private float timer = 0f;
    //private bool yup = false;
    

    private Queue<string> inputs;
    public SampleCodes answers;

    private Queue<string> outputs;
    public Dialogue outs;
    public Animator outAnim;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Code");
        inputs = new Queue<string>();
        outputs = new Queue<string>();
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        Respawn = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        /*timer += Time.deltaTime;
        if (timer > 3.5f)
        {
            //yup = true;
            SaveStats();
        }*/
    }

    public void Setup(SampleCodes dialogue)
    {
        inputs.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            inputs.Enqueue(sentence);
        }
    }

    public void OutSetup(Dialogue dialogue)
    {
        outAnim.SetBool("isOpen", true);
        nameText.text = dialogue.name;

        outputs.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            outputs.Enqueue(sentence);
        }
    }

    public void DisplayNextSentence()
    {
        if (outputs.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = outputs.Dequeue();

        //StopCoroutine(TypeSentence());
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        hintText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            hintText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        outAnim.SetBool("isOpen", false);
    }

    IEnumerator SetupBattle()
    {
        Debug.Log("Setting up");
        Setup(answers);
        OutSetup(outs);
        State.lvlState = "Code";
        //save
        //SaveStats();
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        //playerUnit.currentHP = Inventory.currentHP;
        dialogueText.text = "A scary " + enemyUnit.unitName + " approaches...";
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        x = readString();

        yield return new WaitForSeconds(2.5f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    /*void SaveStats()
    {
        currScene = SceneManager.GetActiveScene();
        int currentLevel = currScene.buildIndex;
        Inventory.crrlvl = currentLevel;
    }*/

    public string readString()
    {
        string rightInput = inputs.Dequeue();
        return rightInput;
    }

    public void inputString(string s)
    {
        inputLine = s;
    }

    public void inputClear()
    {
        inputLine = inputLine.Remove(0);
    }

    IEnumerator PlayerAttack()
    {
        if (inputLine == x)
        {
            DisplayNextSentence();

            yes = true;

            bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

            playerUnit.isAttacking();
            enemyUnit.Hit();

            enemyHUD.setHP(enemyUnit.currentHP);
            dialogueText.text = "Correct code! The attack is a success!";

            yield return new WaitForSeconds(1.5f);

            playerUnit.isNotAttacking();
            inputClear();

            if (inputs.Count == 0)
            {
                state = BattleState.WON;
            }
            else
            {
                x = readString();
            }

            yes = true;

            yield return new WaitForSeconds(2f);

            if (isDead)
            {
                state = BattleState.WON;
                enemyUnit.Dead();
                EndBattle();
            }
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        yes = false;
        dialogueText.text = "Wrong Code! " + enemyUnit.unitName + " attacks!";
        enemyUnit.isAttacking();
        playerUnit.Hit();
        yield return new WaitForSeconds(1.5f);
        enemyUnit.isNotAttacking();
        playerUnit.isNotAttacking();
        CodingClear.deduct++;
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.setHP(playerUnit.currentHP);
        yield return new WaitForSeconds(1.5f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You slain the " + enemyUnit.unitName + " !";
            FindObjectOfType<CodingClear>().ScoreComputation();
        } else if (state == BattleState.LOST) {
            playerUnit.Dead();
            dialogueText.text = "You were defeated.";
            StartCoroutine(RespawnLvl());
        } 
    }

    public void OnNext()
    {
        FindObjectOfType<SceneMove>().LoadNextScene();
    }

    IEnumerator RespawnLvl()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(Respawn);
    }

    /*IEnumerator NextLevel()
    {
        //yield return new WaitForSeconds(2.5f);
        FindObjectOfType<SceneMove>().LoadNextScene();
    }*/

    void PlayerTurn()
    {
        dialogueText.text = "Code to defeat the monster!";

        /*if (yup == true)
        {
            hintText.text = "Hint";
        }*/
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

}
