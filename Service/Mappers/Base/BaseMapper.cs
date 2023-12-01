using AutoMapper;

namespace Service.Mappers.Base
{
	/// <summary>
	/// The BaseMapper
	/// </summary>
	public class BaseMapper : IBaseMapper
	{
		private readonly IMapper _mapper;

		public BaseMapper(IMapper mapper)
		{
			this._mapper = mapper;
		}

		public TDestination Map<TSource, TDestination>(TSource source)
		{
			if (source == null) throw new NullReferenceException(nameof(source));

			return _mapper.Map<TSource, TDestination>(source);
		}
	}
}
