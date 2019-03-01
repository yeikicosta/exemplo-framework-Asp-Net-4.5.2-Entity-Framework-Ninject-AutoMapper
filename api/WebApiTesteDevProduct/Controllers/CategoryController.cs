using ApplicationProduct;
using ApplicationProduct.Interfaces;
using DomainProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiTesteDevProduct.Controllers
{
    [RoutePrefix("categories")]
    public class CategoryController : ApiController
    {
        readonly private IAppCategory App;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppCategory"></param>
        public CategoryController(IAppCategory AppCategory)
        {
            this.App = AppCategory;
        }
        /// <summary>
        /// Consultar por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<Category> GetById(int id)
        {
            return await this.App.GetById(id);
        }

        /// <summary>
        /// Adicionar novo
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [Route]
        public async Task<int> Add(Category category)
        {
            return await App.Add(category);
        }

        /// <summary>
        /// Listar todos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route]
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await App.GetAll();
        }

        /// <summary>
        /// Atualizar
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPut]
        [Route]
        public async Task Update(Category category)
        {
            await App.Update(category);
        }

        /// <summary>
        /// Remover
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task Remove(int id)
        {
            await App.Remove(new Category() { Id = id });
        }
    }
}
