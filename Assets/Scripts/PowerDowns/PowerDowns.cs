
using UnityEngine;

public interface IPowerDown {
	string title { get; }			// Name
	string description { get; }		// What does it do?

	void Activate(); // Do it
}

public class HealthDown : IPowerDown
{
	public string title { get { return "Weakling"; } }
	public string description { get { return "Max health -10"; } }

    public void Activate() {
		PlayerAttributes.maxHealth -= 10;
	}
}

public class FireRateDown : IPowerDown
{
	public string title { get { return "Slow shooter"; } }
	public string description { get { return "Rate of fire -30%"; } }

    public void Activate() {
		PlayerAttributes.fireCoolDown *= 1.30f;
	}
}

public class DamageDown : IPowerDown
{
	public string title { get { return "Damage down"; } }
	public string description { get { return "Damage -25%"; } }

    public void Activate() {
		PlayerAttributes.gunDamage -= (int)(PlayerAttributes.gunDamage * 0.25f);
	}
}

public class BulletSpeedDown : IPowerDown
{
	public string title { get { return "Slow bullets"; } }
	public string description { get { return "Bullet speed -25%"; } }

    public void Activate() {
		PlayerAttributes.projectileSpeed = Mathf.Max(0.1f, PlayerAttributes.projectileSpeed - 0.25f);
	}
}

public class MovementDown : IPowerDown
{
	public string title { get { return "Creepy crawler"; } }
	public string description { get { return "Movement speed -25%"; } }

    public void Activate() {
		PlayerAttributes.movementSpeed = Mathf.Max(0.1f, PlayerAttributes.movementSpeed - 0.25f);
	}
}
