using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Infrastructure.Converters;

public class EatingTimeIntConverter() : ValueConverter<EatingTime, int>(
	x => (int)x,
	i => i >= (int)EatingTime.Unknown && i <= (int)EatingTime.Dinner ? (EatingTime)i : EatingTime.Unknown
)
{
}