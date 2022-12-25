using Microsoft.AspNetCore.Components.Web;

namespace Flower_shop.Services.Implimentations
{
    public class ColorSettingsService : IColorSettingsService
    {
        private IColorRepository _colorRepository;
        private IMapper _mapper;
        public ColorSettingsService(
            IColorRepository colorRepository,
            IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public ColorViewModel GetColorByAssignment(string name)
        {
            return _mapper.Map<ColorViewModel>(_colorRepository.GetByAssignment(name));
        }
        
    }
}
