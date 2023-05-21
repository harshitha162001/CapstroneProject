using CapstoneProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using System.Web.Http.Results;
using System.Web.Http;

namespace CapstoneProject.DAL
{
    public class MidicineService:IMedicineService
    {
        private readonly ApplicationDbContext _context;
        public MidicineService()
        {
            _context = new ApplicationDbContext();
        }

        public async  Task<int> AddMedicineAsync(Medicine medicine)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@MedicineName", medicine.MedicineName));
            parameter.Add(new SqlParameter("@Price", medicine.Price));
            parameter.Add(new SqlParameter("@Image", medicine.Image));
            parameter.Add(new SqlParameter("@Seller", medicine.Seller));
            parameter.Add(new SqlParameter("@MedicineDescription", medicine.Description));
            parameter.Add(new SqlParameter("@CategoryId", medicine.CategoryId));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec AddMedicine @MedicineName, @Price, @Image, @Seller, @MedicineDescription, @CategoryId", parameter.ToArray()));
            return result;
        }

        public async  Task<int> DeleteMedicineAsync(int Id)
        {
            var parameter = new SqlParameter("@MedicineId", Id);

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec DeleteMedicine @MedicineId", parameter));
            return result;
        }

        public  async Task<IEnumerable<Medicine>> GetMedicineByIdAsync(int Id)
        {
            var parameter = new SqlParameter("@MedicineId", Id);

            var result = await Task.Run(() => _context.Medicines
            .FromSqlRaw(@"exec GetMedicineById @MedicineId", parameter).ToListAsync());
            return result;
        }

        public  async Task<List<Medicine>> GetMedicineListAsync()
        {
            return await _context.Medicines
                .FromSqlRaw<Medicine>("GetListOfMedicines")
                .ToListAsync();
        }

        public async  Task<int> UpdateMedicineAsync(int Id, Medicine medicine)
        {
            //var param = new SqlParameter("@MedicineId", Id);
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("MedicineId", Id));
            parameter.Add(new SqlParameter("@MedicineName", medicine.MedicineName));
            parameter.Add(new SqlParameter("@Price", medicine.Price));
            parameter.Add(new SqlParameter("@Image", medicine.Image));
            parameter.Add(new SqlParameter("@Seller", medicine.Seller));
            parameter.Add(new SqlParameter("@MedicineDescription", medicine.Description));
            parameter.Add(new SqlParameter("@CategoryId", medicine.CategoryId));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec EditMedicine @MedicineId, @MedicineName, @Price, @Image, @Seller, @MedicineDescription, @CategoryId", parameter.ToArray()));
            return result;
        }
    }
}
