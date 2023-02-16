using System.Collections.Generic;

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
		gunFireRate = 1.0f;
		movementSpeed = 1.0f;
	}

	// Attributes
	public static int maxHealth;
	public static int gunDamage;
	public static float gunFireRate;
	public static float movementSpeed;

	// Add whatever you want or need here ...

}
