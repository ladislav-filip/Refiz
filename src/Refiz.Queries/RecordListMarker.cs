namespace Refiz.Queries;

public record RecordListMarker<T>(long Count, IEnumerable<T> Data) where T: RecordMarker { }