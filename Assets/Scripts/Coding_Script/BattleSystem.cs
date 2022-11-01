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
    
    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    private string inputLine;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        Debug.Log("Setting up"); 
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "A scary "+ enemyUnit.unitName + " approaches...";
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2.5f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    public void readString(string s)
    {
        inputLine = s;
    }

    IEnumerator PlayerAttack()
    {
        if (inputLine == "print(Hello World)")
        {
            bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

            playerUnit.isAttacking();
            enemyUnit.Hit();

            enemyHUD.setHP(enemyUnit.currentHP);
            dialogueText.text = "Correct code! The attack is a success!";

            yield return new WaitForSeconds(2.5f);

            playerUnit.isNotAttacking();

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
        }else if (state == BattleState.LOST){
            dialogueText.text = "You were defeated.";
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Code to defeat the monster!";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());

    }

}
