using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
//using DataAccess.Models;

namespace DataAccess
{
    class SqlDataAccess
    {
        //public void AddProduct(ProductModel _productModel)
        //{
        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection())
        //    {
        //        connection.Query($@"INSERT INTO [Product] (ProductName,FK_BrandId) VALUES('{_productModel.ProductName}',
        //                        (Select[Id] From[Brand] Where[Brand].[BrandName] = {_productModel.Fk_BradnId})); ").ToList();
        //    }
        //}
        //public void AddBrand(BrandModel _brandModel)
        //{
        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection())
        //    {
        //        connection.Query($@"INSERT INTO [Brand] (BrandName) VALUES({_brandModel.BrandName})").ToList();
        //    }
        //}
        //public List<SurveyModel> AddSurvey(SurveyModel _surveyModel)
        //{
        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection())
        //    {
        //        return connection.Query<SurveyModel>($"Select * From [Product] Where [FK_BrandId]={_surveyModel.Fk_ProductId}").ToList();
        //    }
        //}
        //public List<ProductModel> GetProducts(BrandModel _brandModel)
        //{
        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection())
        //    {
        //        return connection.Query<ProductModel>($"Select * From [Product] Where [FK_BrandId]={_brandModel.UId}").ToList();
        //    }
        //}

    }
}
