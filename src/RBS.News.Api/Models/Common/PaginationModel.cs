using System.ComponentModel.DataAnnotations;

namespace RBS.News.Api.Models.Common;

public class PaginationModel
{
    public int Page { get; set; }
    
    public int Limit { get; set; }
}