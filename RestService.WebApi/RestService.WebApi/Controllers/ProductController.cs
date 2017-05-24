using RestService.WebApi.Controllers.Base;
using RestService.WebApi.RequestIdentity;
using RestService.Service.Services;
using AutoMapper;
using System.Web.Http;
using System.Threading.Tasks;
using RestService.WebApi.Dto.Products.Dto.In;
using RestService.Domain.Models;

namespace RestService.WebApi.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : BaseController
    {
        IProductService productService;
        IMapper mapper;
        public ProductController(IMapper mapper,IProductService productService,IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]ProductDtoIn product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await productService.InsertProductAsync(mapper.Map<ProductModel>(product));
            return Ok(created);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Udate([FromBody]ProductDtoUpdateIn product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await productService.UpdateProductAsync(mapper.Map<ProductModel>(product));
            return Ok(created);
        }

    }
}