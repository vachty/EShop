namespace Service.Mappers.Base
{
	/// <summary>
	/// The BaseMapper interface
	/// </summary>
	public interface IBaseMapper
	{
		TDestination Map<TSource, TDestination>(TSource source);
	}
}
