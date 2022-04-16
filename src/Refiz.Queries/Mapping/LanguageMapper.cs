#region Info
// FileName:    LanguageMapper.cs
// Author:      Ladislav Filip
// Created:     15.04.2022
#endregion

namespace Refiz.Queries.Mapping;

public class LanguageMapper : Profile
{
    public LanguageMapper()
    {
        CreateMap<Language, LanguageItem>()
            .ForCtorParam(nameof(LanguageItem.Id), opt => opt.MapFrom(src => src.Id));
    }
}