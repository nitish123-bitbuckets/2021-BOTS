using Godot;
using System;

public class Rail : SpaceProjectile, SpaceDamagable
{
    public bool PartialHoming = false;
    public float Acceleration = 100f;
    public float RotationDeadband = 0.3f;
    public float RotationSpeed = 30f;
    public Node2D Target;
    public void Hit()
    {
        Destroyed = true;
        QueueFree();
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        if (PartialHoming)
        {
            float targetAngle = GetAngleTo(Target.GlobalPosition);
            if (Mathf.Abs(targetAngle) >= RotationDeadband)
            {
                if (targetAngle > 0)
                {
                    Rotate(-RotationSpeed * delta);
                }
                else
                {
                    Rotate(RotationSpeed * delta);
                }
            }
            AddForce(Rotation, Acceleration * delta);

        }
    }
}
