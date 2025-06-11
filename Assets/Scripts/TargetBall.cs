using UnityEngine;

public class TargetBall : MonoBehaviour
{
    public TargetManager manager;
    public HitCounter hitCounter;

    public void Hit()
    {
        if (!GameManager.instance.CanHit()) return;

        if (!GameManager.instance.IsTimerRunning())
            GameManager.instance.StartTimer();

        hitCounter.AddHit();
        manager.BallDestroyed(gameObject);
        Destroy(gameObject);
    }
}
