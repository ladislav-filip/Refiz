#region Info
// FileName:    EntityList.cs
// Author:      Ladislav Filip
// Created:     28.02.2022
#endregion

namespace Refiz.Queries.Entities.Models;

public record EntityItemList(int Id, string Surname, string Name, string Email) : RecordMarker;