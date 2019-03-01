using ApplicationProduct.Interfaces;
using DomainProduct;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiTesteDevProduct.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("products")]
    public class ProductController : ApiController
    {
        readonly private IAppProduct App;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppProduct"></param>
        public ProductController(IAppProduct AppProduct)
        {
            this.App = AppProduct;
        }
        /// <summary>
        /// Consultar por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<Product> GetById(int id)
        {
            return await App.GetById(id);
        }

        /// <summary>
        /// Adicionar novo
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [Route]
        public async Task<int> Add([FromBody]Product product)
        {
            return await App.Add(product);
        }

        /// <summary>
        /// Listar todos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route]
        public async Task<IEnumerable<Product>> GetAll()
        {

            return await App.GetAll();
        }

        /// <summary>
        /// Atualizar
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        [Route]
        public async Task Update([FromBody]Product product)
        {
            await App.Update(product);
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
            await App.Remove(new Product() {Id = id });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("find")]
        public async Task<IEnumerable<Product>> FindByName([FromBody]string name)
        {
            return await App.FindByName(name);
        }
    }
}
