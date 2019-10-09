using System.Data;
using System.Linq;
using IvanovBand.Domain.Abstract;
using IvanovBand.Domain.Entities;


namespace IvanovBand.Domain.Concrete
{
    public class EFArticleRepository : IArticlesRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Article> Articles
        {
            get { return context.Articles; }
        }

        public void SaveArticle(Article article)
        {
            if (article.ArticleID == 0)
            {
                context.Articles.Add(article);
            }
            else
            {
                context.Entry(article).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteArticle(Article article)
        {
            context.Articles.Remove(article);
            context.SaveChanges();
        }
    }
}
