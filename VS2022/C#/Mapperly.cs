using Riok.Mapperly.Abstractions;

public class CarModel { }
public class CarShortModel { }

public class CarDTO { }
public class CarShortDTO { }

//Optional for use DI
public interface ICarMapper
{
    public CarDTO CarModelToCarDTO(CarModel carModel);
    public CarDTO CarModelToCarShortDTO(CarModel carModel);
    public CarShortDTO CarShortModelToCarShortDTO(CarShortModel carModel);
}

[Mapper]
public partial class CarMapper: ICarMapper
{
    public partial CarDTO CarModelToCarDTO(CarModel carModel);
    public partial CarDTO CarModelToCarShortDTO(CarModel carModel);
    public partial CarShortDTO CarShortModelToCarShortDTO(CarShortModel carModel);
}

[Mapper]
public static partial class CarMapperStatic
{
    public static partial CarDTO CarModelToCarDTO(CarModel  carModel);
    public static partial CarDTO CarModelToCarShortDTO(CarModel  carModel);
    public static partial CarShortDTO CarShortModelToCarShortDTO(CarShortModel carModel);
}

public class MapUseDI
{
    private ICarMapper _mapper;
    public UseVar_DI(ICarMapper mapper) => _mapper = mapper;
    public CarDTO Use(CarModel model) => _mapper.CarModelToCarDTO(model);
}

public class MapUseInstance 
{
    public CarDTO Map(CarModel model)
    {
        CarMapper mapper = new();
        mapper.CarModelToCarDTO(model);
    }
}

public class MapUseStatic
{
    public CarDTO Map(CarModel model) => CarMapperStatic(model);
}
