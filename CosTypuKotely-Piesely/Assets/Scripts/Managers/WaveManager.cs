using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
    [SerializeField]
    private bool isWave = false;
    [SerializeField]
    private Spawn spawner;
    public bool IsWave { get => isWave; set => isWave = value; }
    [SerializeField]
    private StatementTextUI statementTextUI;
    [SerializeReference]
    private WaveEndConditionBase x = new WaveEndEnemyCountCondition();

    public Float EnemiesCounter { get; set; }
    public Spawn Spawner { get => spawner; set => spawner = value; }

    public event System.Action OnWaveStart = delegate { };
    public event System.Action OnWaveEnd = delegate { };

    private void Start()
    {
        EnemiesCounter = new Float(0);
        // EnemiesCounter.OnValueChanged += CheckWaveEnd;
    }

    private void OnDisable()
    {
        // EnemiesCounter.OnValueChanged -= CheckWaveEnd;
    }

    // public void CheckWaveEnd(float amount)
    // {
    //     if (amount <= 0)
    //     {
    //         EndWave();
    //     }
    // }

    public void ChangeWaveState(bool state)
    {
        isWave = state;
        InputManager.Instance.ActionMapSetActiv("States", !state);
    }

    public void StartWave()
    {
        ChangeWaveState(true);
        InputManager.Instance.ActionMapSetActiv("Building", false);
        InputManager.Instance.ActionMapSetActiv("Shooting", true);
        statementTextUI.ShowText("Wave Start");
        Player.Instance.PlayerBuild.ShowTemplate(false);
        ResetWave();
        OnWaveStart();
        Spawner.StartWave();
        x.Attach();
    }

    private void ResetWave()
    {
        EnemiesCounter.SetValue(0);
    }

    public void EndWave()
    {
        x.Detach();
        ChangeWaveState(false);
        statementTextUI.ShowText("Wave End");
        OnWaveEnd();
    }
}
