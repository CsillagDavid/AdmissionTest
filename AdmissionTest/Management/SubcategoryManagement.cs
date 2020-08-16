using AdmissionTest.management.iManagement;
using AdmissionTest.model.context;
using AdmissionTest.model.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AdmissionTest.management {
    public class SubcategoryManagement : ISubcategoryManagement {
        private readonly SubcategoryContext subcategoryContext;
        public SubcategoryManagement(SubcategoryContext subcategoryContext)
        {
            this.subcategoryContext = subcategoryContext;
        }

        public void Delete(Subcategory subcategory)
        {
            using (SqlConnection conn = new SqlConnection(Environment.GetEnvironmentVariable("ConnectionString")))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    conn.Open();
                    //Begin transaction to avoid update failures
                    SqlTransaction transaction = conn.BeginTransaction();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.Transaction.Save("Save");

                    try
                    {
                        cmd.CommandText = @"UPDATE subcategory SET archived = 1 where id=@id";
                        cmd.Parameters.AddWithValue("@id", subcategory.ID);
                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        cmd.Transaction.Rollback("Save");
                        throw;
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Dispose();
                    }
                }
            }
        }

        public Subcategory FindById(int id)
        {
            return subcategoryContext.Subcategories.FirstOrDefault(s => s.ID == id);
        }

        public IList<Subcategory> GetAll()
        {
            return subcategoryContext.Subcategories.ToList();
        }

        public void Save(Subcategory subcategory)
        {
            subcategoryContext.Subcategories.Add(subcategory);
            subcategoryContext.SaveChanges();
        }

        public void Update(Subcategory subcategory)
        {
            throw new System.NotImplementedException();
        }
    }
}
