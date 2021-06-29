using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeyahatRehberi.Business.Abstract;
using SeyahatRehberi.Business.BusinessAspects.Autofac;
using SeyahatRehberi.Business.Constants;
using SeyahatRehberi.Business.ValidationRules.FluentValidation;
using SeyahatRehberi.Core.Aspects.Autofac.Validation;
using SeyahatRehberi.Core.Utilities.Business;
using SeyahatRehberi.Core.Utilities.Results;
using SeyahatRehberi.DataAccess.Abstract;
using SeyahatRehberi.Entities.Concrete;
using SeyahatRehberi.Entities.DTOs;

namespace SeyahatRehberi.Business.Concrete
{
    public class ArticleManager:IArticleService
    {
        private IArticleRepository _articleRepository;

        public ArticleManager(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IDataResult<List<Article>> GetAll()
        {
            return new SuccessDataResult<List<Article>>(_articleRepository.GetAll(), Messages.ArticlesListed);
        }

        public IDataResult<List<Article>> GetAllByCityId(int id)
        {
            return new SuccessDataResult<List<Article>>(_articleRepository.GetAll(p => p.CityId == id));
            
        }
        

        public IDataResult<List<ArticleDetailDto>> GetArticleDetails()
        {
            return new SuccessDataResult<List<ArticleDetailDto>>(_articleRepository.GetArticleDetails());
        }

        public IDataResult<Article> GetById(int articleId)
        {
            return new SuccessDataResult<Article>(_articleRepository.Get(p => p.ArticleId == articleId));
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ArticleValidator))]
        public IResult Add(Article article)
        {
            IResult result = BusinessRules.Run(CheckIfArticleNameExists(article.ArticleName));

            if (result != null)
            {
                return result;
            }

            _articleRepository.Add(article);

            return new SuccessResult(Messages.ArticleAdded);
        }


        [SecuredOperation("admin")]
        public IResult Update(Article article)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _articleRepository.Update(article);

            return new SuccessResult(Messages.ArticleUpdated);
        }


        [SecuredOperation("admin")]
        public IResult Delete(Article article)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _articleRepository.Delete(article);

            return new SuccessResult(Messages.ArticleDeleted);
        }




        private IResult CheckIfArticleNameExists(string articleName)
        {
            var result = _articleRepository.GetAll(p => p.ArticleName == articleName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ArticleNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
