using Common.DataGathering.Interfaces;
using System;
using System.Collections.Generic;

namespace DataGathering.Interfaces
{
	public interface IDataGatherer : IDisposable
	{
		IDataItem Get();
		IEnumerable<IDataItem> Stream();
	}
}