using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Team
{
    UNION = 1,
    ENEMY = -1,
    NONE = 0
}

public enum STAGESTATE
{
    RUNNING,
    PAUSE,
    LEVELUP,
    STOP,
    ENDING,
    REVIVE,
    NONE
}


public class GameSystem : MonoBehaviour
{
    [SerializeField]
    protected float Hp;
    private float inGameTime;
    public float curGameTime;
    publicint dealthMonsterCount;
    public bool isrevive;
    public float inGameGold;
    public STAGESTATE stageState;

    IEnumerator RunningStage()
    {
        while(true){
            switch (stageState) {
                case STAGESTATE.RUNNING:
                inGameTime += Time.deltaTime;
                break;
                case STAGESTATE.LEVELUP:
                //LEVEL UP
                break;
                case STAGESTATE.PAUSE:
                Time.timeScale = 0;
                break;
                case STAGESTATE.STOP:
                Time.timeScale = 1;
                case STAGESTATE.REVIVE:
                //Revive
                break;
            }
        }
    }

    public void SetStageState(STAGESTATE stageState){
        if (stageState == STAGESTATE.RUNNING || stageState == STAGESTATE.STOP){
            Time.timeScale = 1f;
        } else{
            Time.timeScale = 0f;
        }
        this.stageState = stageState
    }


    public bool ReduceHp(float amount)
    {
		if (amount > Hp)
		{
            Hp = 0;
            return true;
		}

        if (Hp - amount > 0)
        {
            Hp -= amount;
            return true;
        }
        else
        {
            return false;
        }
        
        
        
    }
	/*public virtual void Init()
	 {

		 Hp = 0;
	 }*/

	private void OnEnable()
	{
        Hp = 0;
	}

}
