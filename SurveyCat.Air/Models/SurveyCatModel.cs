
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

    public class SurveyCatModel : INotifyPropertyChanged
    {
        private List<Brand> brands;
        private List<Product> products;
        private string comment;
        private int rating;
        private Brand selectedBrand;
        private Product selectedProduct;
        private bool refreshBtnEnable;
        
        public ICommand LoadBrandsCommand { get; set; }
        public ICommand SelectedBrandCommand { get; set; }
        public ICommand SendSurveyCommand { get; set; }
        public SurveyCatModel()
        {
            this.comment = "";
            this.rating = 3;
            refreshBtnEnable = false;
            ApiHelper.Instance.InitializeClient();


            this.LoadBrandsCommand = new RelayCommand(async () => 
            {
                try
                {
                    await LoadBrands();
                }
                catch (Exception)
                {
                    MessageBox.Show("No DataSource!!!");
                    this.refreshBtnEnable = true;
                }         
            }, true);
            this.SendSurveyCommand = new RelayCommand(() => { SendSurvey(); }, true);

            this.LoadBrandsCaller();
        }
        public bool RefreshBtnEnable
        {
            get
            {
                return this.refreshBtnEnable;
            }
            set
            {
                this.refreshBtnEnable = value;
                NotifyPropertyChanged(nameof(RefreshBtnEnable));
            }
        }
        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                selectedBrand = value;              
                NotifyPropertyChanged(nameof(SelectedBrand));
                SelectedBrandChange();
            }
        }
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                NotifyPropertyChanged(nameof(SelectedProduct));
            }
        }
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
        public string Comment
        {
            get
            {
                return this.comment;
            }

            set
            {
                if (value != "")
                {
                    this.comment = value;
                    this.NotifyPropertyChanged(nameof(this.Comment));
                }           
            }
        }
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private Task LoadBrands()
        {
            return Task.Run(async () =>
            {
                this.Brands = await ApiHelper.instance.GetBrands();
            });
        }
        private Task LoadProducts(Guid brandId)
        {
            return Task.Run(async () =>
            {
                this.Products = await ApiHelper.instance.GetProducts(brandId);
            });
        }
        private async void SendSurvey()
        {
            if (SendSurveyCheck())
            {
                Survey survey = new Survey(Rating, Comment, SelectedProduct.Id);
                await ApiHelper.instance.PostSurvey(survey);
                ClearAllFields();
            }
        }
        private void SelectedBrandChange()
        {
            this.LoadProducts(this.SelectedBrand.Id);
        }
        private bool SendSurveyCheck()
        {
            if (SelectedBrand==null)
            {
                MessageBox.Show("Select 'Brand'!!!!");
                return false;
            }
            if (SelectedProduct == null)
            {
                MessageBox.Show("Select 'Product'!!!!");
                return false;
            }
            if (Comment.Trim() == "")
            {
                MessageBox.Show("Fill 'Comment' field!!!!");
                return false;
            }
            return true;
        }
        private void ClearAllFields()
        {
            this.Comment = " ";
            this.Comment.Trim();
            this.Rating = 3;
            this.SelectedBrand = new Brand();
            this.SelectedProduct = new Product();
            
        }
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

    }
}
