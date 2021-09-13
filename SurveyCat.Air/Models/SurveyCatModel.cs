//-------------------------------------------------------------------------------
// <copyright file="SurveyCatModel.cs" company="SoftLab">
//     Copyright (c) www.softlab.rs. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SurveyCat.Air.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using SurveyCat.Air.Entities;
    using SurveyCat.Air.Service;

    /// <summary>
    /// The SurveyCatModel
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class SurveyCatModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The brands
        /// </summary>
        private List<Brand> brands;

        /// <summary>
        /// The products
        /// </summary>
        private List<Product> products;

        /// <summary>
        /// The comment
        /// </summary>
        private string comment;

        /// <summary>
        /// The rating
        /// </summary>
        private int rating;

        /// <summary>
        /// The selected brand
        /// </summary>
        private Brand selectedBrand;

        /// <summary>
        /// The selected product
        /// </summary>
        private Product selectedProduct;

        /// <summary>
        /// The refresh BTN enable
        /// </summary>
        private bool refreshBtnEnable;

        /// <summary>
        /// Initializes a new instance of the <see cref="SurveyCatModel"/> class.
        /// </summary>
        public SurveyCatModel()
        {
            this.comment = string.Empty;
            this.rating = 3;
            this.refreshBtnEnable = false;
            ApiHelper.Instance.InitializeClient();

            this.LoadBrandsCommand = new RelayCommand(() => { BrandCommandLoader(); }, true);
            this.SendSurveyCommand = new RelayCommand(() => { SendSurvey(); }, true);

            this.LoadBrandsCaller();
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the load brands command.
        /// </summary>
        /// <value>
        /// The load brands command.
        /// </value>
        public ICommand LoadBrandsCommand { get; set; }

        /// <summary>
        /// Gets or sets the selected brand command.
        /// </summary>
        /// <value>
        /// The selected brand command.
        /// </value>
        public ICommand SelectedBrandCommand { get; set; }

        /// <summary>
        /// Gets or sets the send survey command.
        /// </summary>
        /// <value>
        /// The send survey command.
        /// </value>
        public ICommand SendSurveyCommand { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [refresh BTN enable].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [refresh BTN enable]; otherwise, <c>false</c>.
        /// </value>
        public bool RefreshBtnEnable 
        {
            get
            {
                return this.refreshBtnEnable;
            }

            set
            {
                this.refreshBtnEnable = value;
                this.NotifyPropertyChanged(nameof(this.RefreshBtnEnable));
            }
        }

        /// <summary>
        /// Gets or sets the selected brand.
        /// </summary>
        /// <value>
        /// The selected brand.
        /// </value>
        public Brand SelectedBrand
        {
            get 
            { 
                return this.selectedBrand; 
            }

            set
            {
                this.selectedBrand = value;              
                this.NotifyPropertyChanged(nameof(this.SelectedBrand));
                this.SelectedBrandChange();
            }
        }

        /// <summary>
        /// Gets or sets the selected product.
        /// </summary>
        /// <value>
        /// The selected product.
        /// </value>
        public Product SelectedProduct
        {
            get 
            { 
                return this.selectedProduct; 
            }

            set
            {
                this.selectedProduct = value;
                this.NotifyPropertyChanged(nameof(this.SelectedProduct));
            }
        }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public int Rating
        {
            get
            {
                return this.rating;
            }

            set
            {
                this.rating = value;
                this.NotifyPropertyChanged(nameof(this.Rating));
            }
        }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment
        {
            get
            {
                return this.comment;
            }

            set
            {
                if (value != string.Empty)
                {
                    this.comment = value;
                    this.NotifyPropertyChanged(nameof(this.Comment));
                }           
            }
        }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public List<Product> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                this.products = value;
                this.NotifyPropertyChanged(nameof(this.Products));
            }
        }

        /// <summary>
        /// Gets or sets the brands.
        /// </summary>
        /// <value>
        /// The brands.
        /// </value>
        public List<Brand> Brands
        {
            get
            {
                return this.brands;
            }

            set
            {
                this.brands = value;
                this.NotifyPropertyChanged(nameof(this.Brands));
            }
        }

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Loads the brands.
        /// </summary>
        /// <returns> Set Brands </returns>
        private Task LoadBrands()
        {
            return Task.Run(async () =>
            {
                this.Brands = await ApiHelper.Instance.GetBrands();
            });
        }

        /// <summary>
        /// Loads the products.
        /// </summary>
        /// <param name="brandId">The brand identifier.</param>
        /// <returns> Set Products </returns>
        private Task LoadProducts(Guid brandId)
        {
            return Task.Run(async () =>
            {
                this.Products = await ApiHelper.Instance.GetProducts(brandId);
            });
        }

        /// <summary>
        /// Sends the survey.
        /// </summary>
        private async void SendSurvey()
        {
            if (this.SendSurveyCheck())
            {
                Survey survey = new Survey(this.Rating, this.Comment, this.SelectedProduct.Id);
                await ApiHelper.Instance.PostSurvey(survey);
                this.ClearAllFields();
            }
        }

        /// <summary>
        /// Selected the brand change.
        /// </summary>
        private void SelectedBrandChange()
        {
            this.LoadProducts(this.SelectedBrand.Id);
        }

        /// <summary>
        /// Sends the survey check.
        /// </summary>
        /// <returns> Allow sending survey </returns>
        private bool SendSurveyCheck()
        {
            if (this.SelectedBrand == null)
            {
                MessageBox.Show("Select 'Brand'!!!!");
                return false;
            }

            if (this.SelectedProduct == null)
            {
                MessageBox.Show("Select 'Product'!!!!");
                return false;
            }

            if (this.Comment.Trim() == string.Empty)
            {
                MessageBox.Show("Fill 'Comment' field!!!!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Clears all fields.
        /// </summary>
        private void ClearAllFields()
        {
            this.Comment = " ";
            this.Comment.Trim();
            this.Rating = 3;
            this.SelectedBrand = new Brand();
            this.SelectedProduct = new Product();
        }

        /// <summary>
        /// Loads the brands caller.
        /// </summary>
        private void LoadBrandsCaller()
        {
            try
            {
                this.LoadBrandsCommand.Execute(null);
                return;
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("No DataSource!!!" + ex); 
            }
        }

        /// <summary>
        /// Brand the command loader.
        /// </summary>
        private async void BrandCommandLoader()
        {
            try
            {
                await this.LoadBrands();
            }
            catch (Exception)
            {
                MessageBox.Show("No DataSource!!!");
                this.refreshBtnEnable = true;
            }
        }
    }
}
