namespace Service.Mappers.Base
{
	/// <summary>
	/// The BaseMapper interface
	/// </summary>
	public interface IBaseMapper
	{
		/// <summary>
		/// Maps from entity to DTO
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="TDestination"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		/// <exception cref="NullReferenceException"></exception>
		TDestination Map<TSource, TDestination>(TSource source);
	}
}
