
public interface IPowerDown {
	string title { get; }			// Name
	string description { get; }		// What does it do?

	void Activate(); // Do it
}

public class HealthDown : IPowerDown
{
	public string title { get { return "Weakling"; } }
	public string description { get { return "Health -10"; } }

    public void Activate() {
		PlayerAttributes.maxHealth -= 10;
	}
}

public class BulletsDown : IPowerDown
{
	public string title { get { return "Slow shooter"; } }
	public string description { get { return "Rate of fire -50%"; } }

    public void Activate() {
		PlayerAttributes.gunFireRate *= 0.5f;
	}
}
