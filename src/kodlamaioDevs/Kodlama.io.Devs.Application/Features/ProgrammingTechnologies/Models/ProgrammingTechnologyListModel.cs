using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models;

/// <summary>
/// Programlama teknolojileri için kullanılan model
/// </summary>
public class ProgrammingTechnologyListModel : BasePageableModel
{
    public IList<ProgrammingTechnologyListDto> Items { get; set; }
}