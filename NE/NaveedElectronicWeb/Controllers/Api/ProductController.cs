using NaveedElectronicWeb.NEModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NaveedElectronicWeb.Controllers.Api
{
    [Authorize]
    public class ProductController : ApiController
    {
        NEDataBaseEntities Db = new NEDataBaseEntities();


        public IEnumerable<Category> Get()
        {
            List<Category> list = new List<Category>();

            var categories = Db.Categories.OrderByDescending(c => c.Id).ToList();

            foreach (var cat in categories)
            {
                list.Add(new Category()
                {
                    Id = cat.Id,
                    CategoryName = cat.CategoryName
                });
            }

            return list;
        }


        public IEnumerable<Product> Get(int id)
        {
            List<Product> list = new List<Product>();

            var products = Db.Products.Where(p => p.CategoryId == id).OrderByDescending(prd => prd.Id);


            foreach (var product in products)
            {
                list.Add(new Product()
                {

                    Id = product.Id,
                    CategoryId = product.CategoryId,
                    Category = new Category() { Id= product.Category.Id,CategoryName=product.Category.CategoryName}, 
                    Model = product.Model,
                    PurchasePrice = product.PurchasePrice,
                    SalePrice = product.SalePrice,
                    GuaranteeWarranty = product.GuaranteeWarranty,
                    Quantity = product.Quantity,
                    InstallmentPrice = product.InstallmentPrice,
                    InstallmentRatio = product.InstallmentRatio,
                    FirstPayment = product.FirstPayment,
                    FirstPaymentRatio = product.FirstPaymentRatio,
                    NoOfMonths = product.NoOfMonths,
                    MonthlyPayment = product.MonthlyPayment
                });
            }

            return list;
        }

        [HttpGet]
        [Route("api/Product/Detail/{id}")]
        public Product Detail(int id)
        {
           
            Product _productInDb = Db.Products.Find(id);
            Product product = new Product()
            {
                Id = _productInDb.Id,
          
            CategoryId = _productInDb.CategoryId,
            Model = _productInDb.Model,
            Quantity = _productInDb.Quantity,
            PurchasePrice = _productInDb.PurchasePrice,
            SalePrice = _productInDb.SalePrice,
            InstallmentPrice = _productInDb.InstallmentPrice,
            NoOfMonths = _productInDb.NoOfMonths,
            GuaranteeWarranty = _productInDb.GuaranteeWarranty,
            MonthlyPayment = _productInDb.MonthlyPayment
        };
            Category category = new Category();
            category.CategoryName= _productInDb.Category.CategoryName;
            category.Id = _productInDb.Category.Id;
            product.Category = category;
            return product;

        }
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
