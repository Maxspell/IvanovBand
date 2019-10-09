using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IvanovBand.Domain.Entities;

namespace IvanovBand.Domain.Abstract
{
    public interface IArticlesRepository
    {
        IQueryable<Article> Articles { get; }
        void SaveArticle(Article article);
        void DeleteArticle(Article article);
    }
}
