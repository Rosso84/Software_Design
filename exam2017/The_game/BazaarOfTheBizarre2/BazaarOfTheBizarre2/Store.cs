using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BazaarOfTheBizarre2 {
    class Store {

        //***********Fields*************
        private List<IProduct> _productList;
        private Object _lock;
      
        private string _storeName;
	    private bool _isRunning = true;
  
	    
        //***********Constructors*************
        public Store(string storename) {
            _storeName = storename;
            _productList = new List<IProduct>();
            _lock = new Object();

        }

		//***********Accessor and Mutator Methods*************
		public List<IProduct> ProductList {
			get => _productList;
			set => _productList = value;
		}

		public bool IsRunning {
			get => _isRunning;
			set => _isRunning = value; 
		}
	    
	    public string StoreName
	    {
		    get => _storeName;
	    }


		//***********Methods*************
        public void Start()
        {
          
             while (_isRunning)
                {
                    ProductList.Add(ProductFactory.CreateProduct());
                    Thread.Sleep(500);
                }
        }

        public IProduct SellItem() {
            lock (_lock) {
                if (ProductList.Count < 1) {
                    return null;
                }
                IProduct currentProduct = ProductList[0];
                ProductList.RemoveAt(0);
                return currentProduct;
            }
        }
	}
}
