using Microsoft.EntityFrameworkCore;
using MyStore.Business.LocNT;
using MyStore.DataAccess.LocNT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Repositories.LocNT
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyStoreContext _context;

        public ProductRepository(MyStoreContext context)
        {
            _context = context;
        }



        // 2. Lấy danh sách (Kèm theo thông tin Category)
        public List<Product> GetProducts()
        {
            // .Include(p => p.Category): Để lấy luôn tên danh mục, nếu không vào trang Index sẽ bị trống cột Category
            return _context.Products.Include(p => p.Category).ToList();
        }

        // 3. Lấy 1 sản phẩm theo ID
        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        // 4. Thêm mới
        public void SaveProduct(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges(); // Lưu vào DB
        }

        // 5. Cập nhật
        public void UpdateProduct(Product p)
        {
            _context.Products.Update(p);
            _context.SaveChanges();
        }

        // 6. Xóa
        public void DeleteProduct(Product p)
        {
            _context.Products.Remove(p);
            _context.SaveChanges();
        }
    }
}
