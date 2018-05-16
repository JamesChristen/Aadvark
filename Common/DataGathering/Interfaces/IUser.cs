using Common.DataGathering.Enums;

namespace Common.DataGathering.Interfaces
{
	public interface IUser
	{
		DataSource Source { get; set; }
		string Identifier { get; set; }
		double Importance { get; set; }
	}
}