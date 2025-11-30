using System.Collections.Generic;
using JacobHomanics.Timer;
using JacobHomanics.Core.OverlapShape;
using JacobHomanics.HealthSystem;
using UnityEngine;
using UnityEngine.Events;
using JacobHomanics.Timer.Extensions;

public class TargetManagerSpin : MonoBehaviour
{
    public TargetManager targetManager;
    public float variancePercentage;

    public float damage;

    public OverlapShape shape;

    public Timer timer;

    public Health selfHealth;

    //Event for timer not reached
    // Reset timer on use
    //Event for Attack
    //Change to try attack

    public UnityEvent OnCooldown;

    public UnityEvent OnSuccess;

    public TimedAction castbar;

    [System.Serializable]
    public struct Spell
    {
        public Sprite sprite;
        public string name;
        public float castTime;

        public string action;
    }

    public Spell spell1;


    public Spell CastingSpell
    {
        get;
        private set;
    }

    void OnEnable()
    {
        if (castbar)
            castbar.OnTimeComplete.AddListener(OnDurationReached);
    }

    void OnDisable()
    {
        if (castbar)
            castbar.OnTimeComplete.RemoveListener(OnDurationReached);

    }

    public void Cast(Spell spell)
    {
        castbar.Cast(spell.sprite, spell.name, spell.castTime);
        CastingSpell = spell;
    }


    void OnDurationReached()
    {
        DoSpell();
    }


    void DoSpell()
    {
        if (selfHealth)
        {
            var diff = damage * (variancePercentage / 100f);
            var rn = Random.Range(damage - diff, damage + diff);
            selfHealth.Heal(rn);
            OnSuccess?.Invoke();
            return;
        }
    }


    void Update()
    {
        if (!selfHealth)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            castbar.CancelCast();
        }

        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            castbar.CancelCast();

    }

    public void StartCast()
    {
        Cast(spell1);
    }

    public void TryAttack()
    {

        if (!timer.IsDurationReached())
        {
            Debug.Log("Cooldown invoked");
            OnCooldown?.Invoke();
            return;
        }


        List<Transform> hitRoots = new List<Transform>();

        var cols = shape.Cast();

        foreach (var col in cols)
        {
            bool isPresent = false;

            foreach (var root in hitRoots)
            {
                if (root == col.transform.root)
                {
                    isPresent = true;
                    break;
                }
            }

            if (!isPresent)
            {
                var diff = damage * (variancePercentage / 100f);
                var rn = Random.Range(damage - diff, damage + diff);
                col.transform.root.GetComponentInChildren<Health>().Damage(rn);
                hitRoots.Add(col.transform.root);
            }
        }

        OnSuccess?.Invoke();

    }
}
