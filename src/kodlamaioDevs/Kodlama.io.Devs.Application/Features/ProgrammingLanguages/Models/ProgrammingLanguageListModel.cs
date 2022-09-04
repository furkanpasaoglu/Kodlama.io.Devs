using Core.Persistence.Paging;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;

/// <summary>
/// Programlama dili için geriye dönen sayfalanmış veri modeli
/// </summary>
public class ProgrammingLanguageListModel : BasePageableModel
{
    public IList<ProgrammingLanguageListDto> Items { get; set; }
}