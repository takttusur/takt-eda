using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TaktTusur.Eda.Infrastructure.Converters;

public class DateTimeOffsetUniversalTimeConverter() : ValueConverter<DateTimeOffset, DateTimeOffset>(
	d => d.ToUniversalTime(),
	d => d.ToUniversalTime());