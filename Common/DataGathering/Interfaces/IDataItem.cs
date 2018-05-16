using Common.DataGathering.Enums;

namespace Common.DataGathering.Interfaces
{
	public interface IDataItem
	{
		DataSource DataSource { get; set; }
		IUser User { get; set; }
		string Content { get; set; }
		IPerception Perception { get; set; }
	}
}