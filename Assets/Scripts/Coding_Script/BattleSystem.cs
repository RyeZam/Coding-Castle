using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public TMPro.TMP_Text dialogueText;
    public TMPro.TMP_Text hintText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public bool yes = true;

    private string inputLine;
    private string x;
    private float timer = 0f;
    private bool yup = false;
    

    private Queue<string> inputs;
    public SampleCodes answers;

    // Start is called before the first frame update
    void Start()
    {   
        inputs = new Queue<string>();
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3.5f)
        {
            yup = true;
        }
    }

    public void Setup(SampleCodes dialogue)
    {
        inputs.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            inputs.Enqueue(sentence);
        }
    }

    IEnumerator SetupBattle()
    {
        Debug.Log("Setting up");
        Setup(answers);
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
            yes = true;

            bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

            playerUnit.isAttacking();
            enemyUnit.Hit();

            enemyHUD.setHP(enemyUnit.currentHP);
            dialogueText.text = "Correct code! The attack is a success!";

            yield return new WaitForSeconds(2.5f);

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
        yield return new WaitForSeconds(1.5f);
        enemyUnit.isNotAttacking();
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
        } else if (state == BattleState.LOST) {
            dialogueText.text = "You were defeated.";
        }
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2.5f);
        FindObjectOfType<SceneMove>().LoadNextScene();
    }

    void PlayerTurn()
    {
        dialogueText.text = "Code to defeat the monster!";

        if (yup == true)
        {
            hintText.text = "Hint";
        }
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());

    }

}
