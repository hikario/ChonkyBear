using UnityEngine;


public class GameOverManager : MonoBehaviour
{
	public float restartDelay = 5f;
		
	public Animator anim;                          // Reference to the animator component.
	float restartTimer;
    public FloatContainer health;
    public CollectedItems score;
    public IntContainer endScore;

    void Update ()
	{
		// If the player has run out of health...
		if(health.floatVariable <= 0)
		{
        GameOver();
		}

		if(score.score >= score.endScore )
		{
        Win();
		}
	}
void GameOver()
{
    // ... tell the animator the game is over.
    anim.SetTrigger("GameOver");
    restartTimer += Time.deltaTime;

    if (restartTimer >= restartDelay)
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
void Win()
{
    // ... tell the animator the game is over.
    anim.SetTrigger("YouWin");
    restartTimer += Time.deltaTime;

    if (restartTimer >= restartDelay)
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
}
