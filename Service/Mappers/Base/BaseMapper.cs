using AutoMapper;

namespace Service.Mappers.Base
{
	/// <summary>
	/// The BaseMapper
	/// </summary>
	public class BaseMapper : IBaseMapper
	{
		private readonly IMapper _mapper;

		/// <summary>
		/// Create instance of the mapper
		/// </summary>
		/// <param name="mapper"></param>
		public BaseMapper(IMapper mapper)
		{
			this._mapper = mapper;
		}

		/// <inheritdoc/>
		public TDestination Map<TSource, TDestination>(TSource source)
		{
			if (source == null) throw new NullReferenceException(nameof(source));

			return _mapper.Map<TSource, TDestination>(source);
		}
	}
}
