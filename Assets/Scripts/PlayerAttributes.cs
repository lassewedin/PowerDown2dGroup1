using System.Collections.Generic;


public enum Ammo {
    semiShot,
    autoShot,
}

public static class PlayerAttributes
{
	public static List<IPowerDown> powerDowns = new List<IPowerDown>();

	static PlayerAttributes() {
		Initialize();
	}

	public static void Initialize() {
		powerDowns.Clear();

		maxHealth = 100;
		gunDamage = 100;
		fireCoolDown = 0.2f;
		movementSpeed = 1.0f;
		projectileSpeed = 1.0f;

		ammo = Ammo.autoShot;
	}

	// Attributes
	public static int maxHealth;
	public static int gunDamage;
	public static float fireCoolDown;
	public static float movementSpeed;
	public static float projectileSpeed;
    public static Ammo ammo;

	// Add whatever you want or need here ...

}
