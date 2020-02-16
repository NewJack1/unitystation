
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Defines all aspects of a particular occupation
/// </summary>
[CreateAssetMenu(fileName = "Occupation", menuName = "Occupation/Occupation", order = 1)]
public class Occupation : ScriptableObject
{
	[Header("Settings")]
	// Settings defining gameplay-related aspects of the job.

	[FormerlySerializedAs("JobType")]
	[SerializeField]
	[Tooltip("Type of occupation.")]
	private JobType jobType;
	public JobType JobType => jobType;

	[FormerlySerializedAs("InventoryPopulator")]
	[SerializeField]
	[Tooltip("Populator to use to populate the player's inventory" +
			 " on spawn when they choose this occupation.")]
	private ItemStoragePopulator inventoryPopulator;
	public ItemStoragePopulator InventoryPopulator => inventoryPopulator;

	[FormerlySerializedAs("Limit")]
	[SerializeField]
	[Tooltip("Maximum simultaneous players with this occupation. Set to -1 for unlimited")]
	private int limit;
	public int Limit => limit;

	[SerializeField]
	[Tooltip("Priority for selecting this occupation when requested occupation is not" +
			 " available.")]
	private int priority;
	public int Priority => priority;

	[FormerlySerializedAs("AllowedAccess")]
	[SerializeField]
	[Tooltip("Default access allowed for this occupation.")]
	private List<Access> allowedAccess;
	public List<Access> AllowedAccess => allowedAccess;

	[Header("Descriptions")]
	// Information that has no real gameplay impact, but is very useful for the player to see.

	[SerializeField]
	[Tooltip("How much of this job has already been implemented in Unitystation?")]
	[Range(0,100)]
	private int progress = 50;
	public int Progress => progress;


	[FormerlySerializedAs("ChoiceColor")]
	[SerializeField]
	[Tooltip("Color of this occupation's button in the occupation chooser")]
	private Color choiceColor = Color.white;
	public Color ChoiceColor => choiceColor;

	[SerializeField]
	[Tooltip("Display name for this occupation.")]
	private string displayName;
	public string DisplayName => displayName;

	[SerializeField]
	[Tooltip("How difficult is this role to play (especially for a new player)?")]
	private OccupationDifficulty difficulty = OccupationDifficulty.Medium;
	public OccupationDifficulty Difficulty => difficulty;

	/// <summary>
	/// How difficult a job is to play.
	/// "Zero" difficulty should be suitable for a player who's completely new to Unitystation.
	/// All other difficulties should depend on:
	/// - The game knowledge required to play the job
	/// - The skill required to successfully perform the job during a round
	/// </summary>
	public enum OccupationDifficulty
	{
		Zero,
		Low,
		Medium,
		High,
		Extreme
	}

	[SerializeField]
	[Tooltip("A concise description of this job's duties, suitable for being displayed in a single line.")]
	private string descriptionShort = "";
	public string DescriptionShort => descriptionShort;

	[SerializeField]
	[TextArea(15, 20)]
	[Tooltip("An elaborate job description for newcomers. Should say what playing this job usually entails, similar to descriptionShort.")] 
	private string descriptionLong = "";
	public string DescriptionLong => descriptionLong;
}
