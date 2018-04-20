using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewsApp.DAL;
using NewsApp.Models;
using Newtonsoft.Json;

namespace NewsApp.Controllers
{
    public class DisplayArticlesController : Controller
    {
        private EfDbContext db = new EfDbContext();
        private DisplayArticle displayArticle = new DisplayArticle();

        [Authorize(Roles = "Admin")]
        public ActionResult UpdateDatabase()
        {
            ResponseNewsAppModels jsonModel = new ResponseNewsAppModels();
            List<DisplayArticle> articleList = new List<DisplayArticle>();
            List<Category> categoryList = db.Categories.ToList();
            foreach (var category in categoryList)
            {
                string jsonObject = jsonModel.TransportJsonNewsWithApp(category.name);
                IEnumerable<NewArticle> listArticle = JsonConvert.DeserializeObject<IEnumerable<NewArticle>>(jsonObject) as IEnumerable<NewArticle>;

                foreach (var article in listArticle)
                {
                    displayArticle = new DisplayArticle
                    {
                        author = article.newAuthor,
                        title = article.newTitle,
                        description = article.newDescription,
                        url = article.newUrl,
                        urlToImage = article.newUrlToImage,
                        publishetAt = article.newPublishetAt,
                        source = article.newSource.newName,
                        idCateogry = category.idCategory
                    };

                    articleList.Add(displayArticle);
                }
            }
            db.Articles.AddRange(articleList);
            db.SaveChanges();
            var message = "Zaktualizowano wszystkie artykuły ";
            return RedirectToAction("ControlPanel", new { information = message });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ClearDatabase()
        {
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE [DisplayArticle]");
            db.SaveChanges();

            var message = " Usunięto wszystkie artykuły";
            return RedirectToAction("ControlPanel", new { information = message });
        }

        private int selectCategory(string category)
        {
            var searchCategoryId = from categories in db.Categories
                                   where categories.name == category
                                   select categories.idCategory;

            return searchCategoryId.FirstOrDefault();
        }

        [Authorize(Roles = "User, Admin")]
        public ActionResult Show()
        {
            string category = Request.QueryString["category"];
            int idCategory = 0;
            if (selectCategory(category) == 0)
                idCategory = 1;
            else idCategory = selectCategory(category);

            var selectCategoryArticles = db.Articles
              .Where(x => x.idCateogry == idCategory).ToList();
            return View(selectCategoryArticles);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ControlPanel()
        {
            string category = Request.QueryString["category"];
            ResponseNewsAppModels jsonModel = new ResponseNewsAppModels();
            int idCategory = selectCategory(category);
            if (selectCategory(category) != 0)
            {
                var searchCategoryName = from categories in db.Categories
                                         where categories.idCategory == idCategory
                                         select categories.name;

                db.Articles.RemoveRange(db.Articles.Where(x => x.idCateogry == idCategory));
                db.SaveChanges();

                string jsonObject = jsonModel.TransportJsonNewsWithApp(Request.QueryString["category"]);
                IEnumerable<NewArticle> listArticle = JsonConvert.DeserializeObject<IEnumerable<NewArticle>>(jsonObject) as IEnumerable<NewArticle>;

                foreach (var article in listArticle)
                {
                    displayArticle.author = article.newAuthor;
                    displayArticle.title = article.newTitle;
                    displayArticle.description = article.newDescription;
                    displayArticle.url = article.newUrl;
                    displayArticle.urlToImage = article.newUrlToImage;
                    displayArticle.publishetAt = article.newPublishetAt;
                    displayArticle.source = article.newSource.newName;
                    displayArticle.idCateogry = idCategory;

                    db.Articles.Add(displayArticle);
                    db.SaveChanges();
                    db.Database.Connection.Close();
                }
            }
            return View(db.Articles.ToList());
        }
    }
}
