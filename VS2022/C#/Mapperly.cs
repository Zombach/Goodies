using Riok.Mapperly.Abstractions;

public class CarModel { }
public class CarShortModel { }

public class CarDTO { }
public class CarShortDTO { }

[Mapper]
public partial class CarMapper
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
